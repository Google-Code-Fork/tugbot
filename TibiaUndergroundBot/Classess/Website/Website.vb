Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web
Public Class Website

    Public Shared Function GetHTML(ByVal ar As IAsyncResult) As String
        Dim request As HttpWebRequest = DirectCast(ar.AsyncState, HttpWebRequest)
        Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(ar), HttpWebResponse)
        Dim respStream As Stream = response.GetResponseStream()
        Dim respBody As String = String.Empty
        Dim buf As Byte() = New Byte(8191) {}
        Dim count As Integer = 0
        Do
            count = respStream.Read(buf, 0, buf.Length)
            If count <> 0 Then
                respBody += Encoding.ASCII.GetString(buf, 0, count)
            End If
        Loop While count > 0
        Return respBody
    End Function

    Public Shared Function Match(ByVal html As String, ByVal pattern As String) As String
        Return Prepare(Regex.Match(html, pattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline).Groups(1).Value)
    End Function

    Public Shared Function Prepare(ByVal text As String) As String
        ' Decode html character entities
        ' Replace non-breaking spaces
        Return HttpUtility.HtmlDecode(text).Replace(Microsoft.VisualBasic.ChrW(&HA0), " "c)
    End Function

#Region "Look Up Players"
    Public Delegate Sub LookupReceived(ByVal info As CharInfo)

    Public Shared Sub LookupPlayer(ByVal playername As String, ByVal callback As LookupReceived)
        playername = playername.Replace(" "c, "+"c)
        playername = playername.Replace(Microsoft.VisualBasic.ChrW(&HA0), "+"c)
        ' Non-breaking space
        Try
            Dim url As String = "http://www.tibia.com/community/?subtopic=characters&name=" & playername

            Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
            Dim response As WebResponse = request.GetResponse()
            Dim SR As New StreamReader(response.GetResponseStream)
            callback(CharInfo.Parse(SR.ReadToEnd))
        Catch
        End Try
    End Sub

    Public Class CharInfo
        Public Name As String
        Public Sex As String
        Public Profession As String
        Public Level As Integer
        Public World As String
        Public Residence As String
        'public string House;
        'public DateTime HousePaidUntil;
        Public GuildName As String
        Public GuildTitle As String
        'public DateTime LastLogin;
        Public Comment As String
        Public AccountStatus As String

        Public Death As New List(Of CharDeath)

        Public RealName As String
        Public Location As String
        'public DateTime Created;

        'public CharInfo[] Characters;

        'public string Status;
        Public D As String
        'public DateTime GuildJoin;
        Public GuildNickName As String

        Public Shared Function Parse(ByVal html As String) As CharInfo
            Dim i As New CharInfo
            Try

                i.Name = Match(html, "Name:</td><td>([^<]*)</td>")
                i.Sex = Match(html, "Sex:</td><td>([^<]*)</td>")
                i.Profession = Match(html, "Profession:</td><td>([^<]*)</td>")
                i.Level = Integer.Parse(Match(html, "Level:</td><td>([^<]*)</td>"))
                i.World = Match(html, "World:</td><td>([^<]*)<\/td>")
                i.Residence = Match(html, "Residence:</td><td>([^<]*)</td>")
                Dim guildDetails As String = Match(html, "membership:</td><td>(.*?)</td>")
                i.GuildTitle = Match(guildDetails, "(.*) of the <a href")
                i.GuildName = Match(guildDetails, ">([^<]*)</a>")

                ' Requires more complex parsing
                'i.LastLogin = DateTime.Parse(HttpUtility.HtmlDecode(Regex.Match(html, @"Last Login:<\/TD><TD>([^<]*)<\/TD>").Groups[1].Value));
                i.Comment = Match(html, "Comment:</td><td>(.*?)</td>").Replace("<br />", String.Empty)
                i.AccountStatus = Match(html, "Account Status:</td><td>([^<]*)</td>")


                i.RealName = Match(html, "Real name:</td><td>([^<]*)</td>")
                i.Location = Match(html, "Location:</td><td>([^<]*)</td>")
                ' Requires more complex parsing
                'i.Created = DateTime.Parse(HttpUtility.HtmlDecode(Regex.Match(html, @"Created:<\/TD><TD>([^<]*)<\/TD>").Groups[1].Value));
                ' TODO finish this
                Dim m As MatchCollection = Regex.Matches(html, "<tr bgcolor=(?:#D4C0A1|#F1E0C6)><td width=25%>(.*?)?</td><td>((?:Died|Killed) at Level ([^ ]*)|and) by (?:<[^>]*>)?([^<]*)", RegexOptions.IgnoreCase)

                For Each n As Match In m
                    Dim D As New CharDeath
                    D.Time = Prepare(n.Groups(1).Value)
                    D.AtLevel = Prepare(n.Groups(3).Value)
                    D.KilledBy = Prepare(n.Groups(4).Value)
                    If D.Time = "" Then
                        i.Death.Last.KilledBy = Prepare(n.Groups(4).Value)
                    Else
                        i.Death.Add(D)
                    End If
                Next

            Catch
                Return i
            End Try
            Return i
        End Function
    End Class

    Public Class CharDeath
        Public Time As String
        Public AtLevel As String
        Public KilledBy As String
    End Class
#End Region

#Region "Get Online players"
    Public Delegate Sub WhoIsOnlineReceived(ByVal chars As List(Of CharOnline))

    Public Shared Sub WhoIsOnline(ByVal worldName As String, ByVal callback As WhoIsOnlineReceived)
        Dim url As String = "http://www.tibia.com/community/?subtopic=whoisonline&world=" & worldName
        Try
            Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
            Dim response As WebResponse = request.GetResponse()
            Dim SR As New StreamReader(response.GetResponseStream)

            callback(GetOnline(SR.ReadToEnd))
        Catch
        End Try
    End Sub

    Public Shared Function GetOnline(ByVal html As String) As List(Of CharOnline)

        Dim matches As MatchCollection = Regex.Matches(html, "<TD WIDTH=70%><[^<]*>([^<]*)</A></TD><TD WIDTH=10%>([^<]*)</TD><TD WIDTH=20%>([^<]*)</TD></TR>")
        Dim chars As New List(Of CharOnline)(matches.Count)
        Dim co As CharOnline

        For i As Integer = 0 To matches.Count - 1
            co = New CharOnline()
            co.Name = Prepare(matches(i).Groups(1).Value)
            co.Level = Integer.Parse(matches(i).Groups(2).Value)
            co.Vocation = Prepare(matches(i).Groups(3).Value)
            chars.Add(co)
        Next
        Return chars
    End Function

    Public Class CharOnline
        Public Name As String
        Public Level As Integer
        Public Vocation As String
    End Class
#End Region

#Region "Get Guild"
    Public Delegate Sub GuildMembersReceived(ByVal members As List(Of String))

    Public Shared Sub GuildMembers(ByVal guildName As String, ByVal callback As GuildMembersReceived)
        Dim url As String = "http://www.tibia.com/community/?subtopic=guilds&page=view&GuildName=" & guildName
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim response As WebResponse = request.GetResponse()
        Dim SR As New StreamReader(response.GetResponseStream)
        callback(ParseGuildPage(SR.ReadToEnd))
    End Sub

    Private Shared Function ParseGuildPage(ByVal html As String) As List(Of String)
        Dim members As New List(Of String)()

        Dim matches As MatchCollection = Regex.Matches(html, """>([^<]+)</a>(\s\(([^\)]+)\))?</td>", RegexOptions.IgnoreCase)
        Dim guildName As String = Match(html, "<h1>([^<]*)</h1>")

        For Each m As Match In matches
            members.Add(m.Value.Remove(0, 2).Replace("&#160;", " ").Split("<")(0).Trim)
        Next
        Return members
    End Function

#End Region



#Region "Get Item"
    Public Delegate Sub ItemInfoReceived(ByVal ItemInfo As ItemInfo)

    Public Class ItemInfo
        Public Attributes As String
        Public LootValue As String
        Public BuyFrom As String
        Public SellTo As String

        Private Shared Function StripLinks(ByVal text As String) As String
            text = text.Replace("</a>", "")
            text = text.Replace("<b>", "")
            text = text.Replace("</b>", "")
Restart:
            Dim link As MatchCollection = Regex.Matches(text, "<a\shref=""[^""]+""\stitle=""[^""]+""\sclass=""[^""]+"">|<a\shref=""[^""]+""\stitle=""[^""]+""\>")
            For Each a As Match In link
                text = text.Replace(a.Value, "")
                GoTo restart
            Next

            Return text
        End Function

        Public Shared Function Parse(ByVal html As String) As ItemInfo
            Dim i As New ItemInfo
            'html = html.Replace(vbNewLine & "<a href=", "<a href=")
            'html = html.Replace(vbNewLine & "<a href=", "<a href=")
            'html = html.Replace("</a><br />" & vbNewLine, "</a><br />")
            html = StripLinks(html)
            Try
                Dim Temp As String
                Dim Count As Integer = 0
                Dim inf As MatchCollection = Regex.Matches(html, "(?<=<td\sstyle=""text-align:left;vertical-align:bottom;"">).+(?=</td>)")
                For Each a As Match In inf
                    Count += 1

                    Temp = Prepare(a.Value)
                    If Count = 1 Then
                        i.Attributes = StripLinks(Temp)
                    ElseIf Count = 3 Then
                        i.LootValue = StripLinks(Temp)
                    ElseIf Count = 5 Then
                        i.BuyFrom = StripLinks(Temp)
                    ElseIf Count = 6 Then
                        i.SellTo = StripLinks(Temp)
                    End If
                Next
            Catch
                Return i
            End Try
            Return i
        End Function
    End Class

    Public Shared Sub LookupItem(ByVal itemname As String, ByVal callback As ItemInfoReceived)
        itemname = itemname.Replace(" "c, "_"c)
        itemname = itemname.Replace(Microsoft.VisualBasic.ChrW(&HA0), "_"c)
        ' Non-breaking space
        Try
            Dim url As String = "http://tibia.wikia.com/wiki/" & itemname

            Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
            Dim response As WebResponse = request.GetResponse()
            Dim SR As New StreamReader(response.GetResponseStream)
            callback(ItemInfo.Parse(SR.ReadToEnd))
        Catch
        End Try
    End Sub

#End Region
End Class
