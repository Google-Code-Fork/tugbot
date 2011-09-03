Imports System.Text
Public Class PacketBuilder

    Public Const MaxLength As Integer = 15360
    Private m_data() As Byte
    Private m_type As Byte
    Private m_index As Integer = 0

#Region "Properties"
    ''' <summary>
    ''' Get/Set the unencrypted bytes associated with this packetbuilder object.
    ''' </summary>
    Public Property Data() As Byte()
        Get
            Return m_data
        End Get
        Set(ByVal value As Byte())
            m_data = value
        End Set
    End Property

    ''' <summary>
    ''' Get/Set the type of the packet (specified in the third byte of the data).
    ''' </summary>
    Public Property Type() As Byte
        Get
            Return m_type
        End Get
        Set(ByVal value As Byte)
            m_type = value
            If m_data IsNot Nothing AndAlso m_data.Length > 3 Then
                m_data(0) = CByte(m_type)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Get/Set the current index in this packet. Set is the same as Seek(int).
    ''' </summary>
    Public Property Index() As Integer
        Get
            Return m_index
        End Get
        Set(ByVal value As Integer)
            m_index = value
        End Set
    End Property
#End Region

#Region "Constructors"
    Public Sub New()
        m_data = New Byte(MaxLength - 1) {}
    End Sub

    Public Sub New(ByVal type__1 As Byte)
        Me.New()
        Type = type__1
        m_index += 1
    End Sub


    Public Sub New(ByVal packet As Byte())
        Me.New(packet, 0, packet.Length)
    End Sub

    Public Sub New(ByVal packet As Byte(), ByVal start As Integer)
        Me.New(packet, start, packet.Length - start)
    End Sub

    Public Sub New(ByVal packet As Byte(), ByVal start As Integer, ByVal length As Integer)
        ReDim m_data(packet.Length)
        Array.Copy(packet, start, m_data, 0, length)
    End Sub
#End Region

#Region "Add"
    Public Function AddByte(ByVal b As Byte) As Integer
        Return AddBytes(New Byte() {b})
    End Function

    Public Function AddBytes(ByVal b As Byte()) As Integer
        Return AddBytes(b, b.Length)
    End Function

    Public Function AddBytes(ByVal b As Byte(), ByVal length As Integer) As Integer
        Return AddBytes(b, 0, length)
    End Function

    Public Function AddBytes(ByVal b As Byte(), ByVal sourceIndex As Integer, ByVal length As Integer) As Integer
        Array.Copy(b, sourceIndex, m_data, m_index, length)
        m_index += length
        Return length
    End Function

    Public Function AddInt(ByVal i As Integer) As Integer
        Return AddBytes(BitConverter.GetBytes(CUShort(i)))
    End Function

    Public Function AddShort(ByVal i As Short) As Integer
        Return AddBytes(BitConverter.GetBytes(CShort(i)))
    End Function

    Public Function AddUShort(ByVal i As UShort) As Integer
        Return AddBytes(BitConverter.GetBytes(CUShort(i)))
    End Function

    Public Function AddLong(ByVal l As Integer) As Integer
        Return AddBytes(BitConverter.GetBytes(l))
    End Function

    Public Function AddString(ByVal s As String) As Integer
        AddInt(s.Length)
        Return AddBytes(Encoding.ASCII.GetBytes(s))
    End Function

#End Region

#Region "Get"
    Public Function GetByte() As Byte
        Return m_data(System.Math.Max(System.Threading.Interlocked.Increment(m_index), m_index - 1))
    End Function

    Public Function GetBytes(ByVal length As Integer) As Byte()
        Dim b As Byte() = New Byte(length - 1) {}
        Array.Copy(m_data, m_index, b, 0, length)
        m_index += length
        Return b
    End Function

    Public Function GetInt() As UShort
        Dim i As UShort = BitConverter.ToUInt16(m_data, m_index)
        m_index += 2
        Return i
    End Function

    Public Function GetShort() As Short
        Dim i As Short = BitConverter.ToInt16(m_data, m_index)
        m_index += 2
        Return i
    End Function

    Public Function GetLong() As Integer
        Dim l As Integer = BitConverter.ToInt32(m_data, m_index)
        m_index += 4
        Return l
    End Function

    Public Function GetString() As String
        Dim length As Integer = GetInt()
        Dim s As String = Encoding.ASCII.GetString(m_data, m_index, length)
        m_index += length
        Return s
    End Function

    Public Function GetString(ByVal length As Integer) As String
        Dim s As String = Encoding.ASCII.GetString(m_data, m_index, length)
        m_index += length
        Return s
    End Function

    Public Function GetData() As Byte()
        Dim b As Byte() = New Byte(m_index - 1) {}
        Array.Copy(m_data, 0, b, 0, m_index)
        Return b
    End Function

    Public Function GetPacket() As Byte()
        Dim b As Byte() = New Byte(m_index + 1) {}
        Array.Copy(BitConverter.GetBytes(CShort(m_index)), b, 2)
        Array.Copy(m_data, 0, b, 2, m_index)
        Return b
    End Function
#End Region

#Region "Peek"
    Public Function PeekByte() As Byte
        Return m_data(System.Math.Max(System.Threading.Interlocked.Increment(m_index), m_index - 1))
    End Function

    Public Function PeekBytes(ByVal length As Integer) As Byte()
        Dim b As Byte() = New Byte(length - 1) {}
        Array.Copy(m_data, m_index, b, 0, length)
        Return b
    End Function

    Public Function PeekInt() As UShort
        Dim i As UShort = BitConverter.ToUInt16(m_data, m_index)
        Return i
    End Function
    Public Function PeekLong() As Integer
        Dim l As Integer = BitConverter.ToInt32(m_data, m_index)
        Return l
    End Function

    Public Function PeekString(ByVal length As Integer) As String
        Dim s As String = Encoding.ASCII.GetString(m_data, m_index, length)
        Return s
    End Function
#End Region

#Region "Control"
    Public Function Seek(ByVal index As Integer) As Integer
        Me.m_index = index
        Return index
    End Function

    Public Function Skip(ByVal length As Integer) As Integer
        m_index += length
        Return m_index
    End Function
#End Region

End Class
