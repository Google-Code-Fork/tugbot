/* 
   Socket.cpp

   Copyright (C) 2002-2004 René Nyffenegger

   This source code is provided 'as-is', without any express or implied
   warranty. In no event will the author be held liable for any damages
   arising from the use of this software.

   Permission is granted to anyone to use this software for any purpose,
   including commercial applications, and to alter it and redistribute it
   freely, subject to the following restrictions:

   1. The origin of this source code must not be misrepresented; you must not
      claim that you wrote the original source code. If you use this source code
      in a product, an acknowledgment in the product documentation would be
      appreciated but is not required.

   2. Altered source versions must be plainly marked as such, and must not be
      misrepresented as being the original source code.

   3. This notice may not be removed or altered from any source distribution.

   René Nyffenegger rene.nyffenegger@adp-gmbh.ch
*/

#include "stdafx.h"
#include <iostream>
#include <WinSock2.h>
#include <string>
#include "Socket.h"
#pragma comment(lib,  "ws2_32.lib")

using namespace std;

int Socket::nofSockets_= 0;

void Socket::Start() {
	if (!nofSockets_) {
		WSADATA info;
		if (WSAStartup(MAKEWORD(2,0), &info))
		{
			throw "Could not start WSA";
		}
	}
	++nofSockets_;
}

void Socket::End()
{
	WSACleanup();
}

Socket::Socket() : s_(0)
{
	Start();
	s_ = socket(AF_INET,SOCK_STREAM,0);

	if (s_ == INVALID_SOCKET)
	{
		throw "INVALID_SOCKET";
	}
	refCounter_ = new int(1);
}

Socket::Socket(SOCKET s) : s_(s)
{
	Start();
	refCounter_ = new int(1);
};

Socket::~Socket() {
	if (! --(*refCounter_))
	{
		Close();
		delete refCounter_;
	}

	--nofSockets_;
	if (!nofSockets_) End();
}

Socket::Socket(const Socket& o)
{
	refCounter_=o.refCounter_;
	(*refCounter_)++;
	s_ = o.s_;

	nofSockets_++;
}

Socket& Socket::operator=(Socket& o) {
	(*o.refCounter_)++;

	refCounter_=o.refCounter_;
	s_ = o.s_;

	nofSockets_++;
	return *this;
}

void Socket::Close() {
	closesocket(s_);
}


BYTE* Socket::ReceiveBytes(int &len)
{

	unsigned long size = 0;
	unsigned long overallSize = 0;
	BYTE tret[10000];

	while (true)
	{
		if(ioctlsocket(s_, FIONREAD, &size) == SOCKET_ERROR)
			break;

		if (size == 0) break;
		
		char* buf = new char[size];
		if (recv(s_, buf, size, 0) == size)
		{
			for (int i = 0; i < size; i++)
				tret[i+overallSize] = buf[i];
			overallSize += size;
		}
		else
			break;
	}

	len = overallSize;
	if (len == 0) return NULL;
	BYTE* ret = new BYTE[len];

	for (int i = 0; i < len; i++)
			ret[i] = tret[i];

	return ret;

	//u_long waitSize = 0;
	//if (ioctlsocket(s_, FIONREAD, &waitSize) != 0)
	//	return NULL;

	//if (waitSize == 0)
	//	return NULL;

	//char* buf = new char[waitSize];
	//BYTE* ret = new BYTE[waitSize];

	//len = (int)waitSize;
	//recv(s_, buf, len, 0);

	//for (int i = 0; i < waitSize; i++)
	//	ret[i] = buf[i];
	//return ret;



	//char buf[1024];
	//BYTE ret[1024];
	//len = recv(s_, buf, 1024, 0);
	//for (int i = 0; i < 1024; i++) //crappy way of char* to byte* but temporary
	//	ret[i] = buf[i];
	//return ret;
}



void Socket::SendBytes(BYTE* s, int len) {
	char buf[1024];
	memcpy(buf, s, 1024);
	send(s_, buf, len, 0);
}

SocketServer::SocketServer(int port, int connections, TypeSocket type) {
	sockaddr_in sa;

	memset(&sa, 0, sizeof(sa));

	sa.sin_family = PF_INET;             
	sa.sin_port = htons(port);          
	s_ = socket(AF_INET, SOCK_STREAM, 0);
	if (s_ == INVALID_SOCKET) {
		throw "INVALID_SOCKET";
	}

	if(type==NonBlockingSocket)
	{
		u_long arg = 1;
		ioctlsocket(s_, FIONBIO, &arg);
	}

	/* bind the socket to the internet address */
	if (bind(s_, (sockaddr *)&sa, sizeof(sockaddr_in)) == SOCKET_ERROR)
	{
		closesocket(s_);
		throw "INVALID_SOCKET";
	}
  
	listen(s_, connections);                               
}

Socket* SocketServer::Accept() {
	SOCKET new_sock = accept(s_, 0, 0);
	if (new_sock == INVALID_SOCKET)
	{
		int rc = WSAGetLastError();
		if(rc==WSAEWOULDBLOCK)
		{
			return 0; // non-blocking call, no request pending
		}
		else
		{
			throw "Invalid Socket";
		}
	}

	Socket* r = new Socket(new_sock);
	return r;
}

SocketClient::SocketClient(const std::string& host, int port) : Socket() {
	std::string error;

	hostent *he;
	if ((he = gethostbyname(host.c_str())) == 0)
	{
		error = strerror(errno);
		throw error;
	}

	sockaddr_in addr;
	addr.sin_family = AF_INET;
	addr.sin_port = htons(port);
	addr.sin_addr = *((in_addr *)he->h_addr);
	memset(&(addr.sin_zero), 0, 8); 

	if (::connect(s_, (sockaddr *) &addr, sizeof(sockaddr)))
	{
		error = strerror(WSAGetLastError());
		throw error;
	}
}

SocketSelect::SocketSelect(Socket const * const s1, Socket const * const s2, TypeSocket type) {
	FD_ZERO(&fds_);
	FD_SET(const_cast<Socket*>(s1)->s_,&fds_);
	if(s2)
	{
		FD_SET(const_cast<Socket*>(s2)->s_,&fds_);
	}     

	TIMEVAL tval;
	tval.tv_sec  = 0;
	tval.tv_usec = 1;

	TIMEVAL *ptval;
	if(type==NonBlockingSocket)
	{
		ptval = &tval;
	}
	else
	{ 
		ptval = 0;
	}

	if (select (0, &fds_, (fd_set*) 0, (fd_set*) 0, ptval) == SOCKET_ERROR) 
		throw "Error in select";
}

bool SocketSelect::Readable(Socket const* const s)
{
	if (FD_ISSET(s->s_,&fds_)) return true;
	return false;
}
