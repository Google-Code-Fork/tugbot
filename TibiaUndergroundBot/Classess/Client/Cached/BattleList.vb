Public Class BattleList
    Public Client As Client
    Public BattleListCache() As Byte

    Public Sub New(ByVal c As Client)
        Me.Client = c
        ReDim BattleListCache(Client.Addresses.Battlelist.Step * (Client.Addresses.Battlelist.Characters + 1))
    End Sub

    Public Sub Cache()
        SyncLock BattleListCache
            BattleListCache = Client.ReadBytes(Client.Addresses.Battlelist.Start - Client.Addresses.Battlelist.Step, _
                                   Client.Addresses.Battlelist.Step * (Client.Addresses.Battlelist.Characters + 1))
        End SyncLock
    End Sub

    Public ReadOnly Property Length() As Integer
        Get
            Return Client.Addresses.Battlelist.Characters
        End Get
    End Property

#Region "Get"
    Private Function GetBytes(ByVal start As Integer, ByVal length As Integer) As Byte()
        Dim BArray(length) As Byte
        SyncLock BattleListCache
            Array.Copy(BattleListCache, start, BArray, 0, length)
        End SyncLock
        Return BArray
    End Function

    Private Function GetBl(ByVal name As String) As Integer
        For i = 1 To Length
            If name Is Nothing Then Return 0
            If Me.Name(i).ToLower = name.ToLower Then
                Return i
            End If
        Next
    End Function
#End Region

#Region "Properties by BL address"
#Region "Name and ID"
    Public Function Name(ByVal BlPos As Integer) As String
        Dim strTemp As String = String.Empty
        Dim StringArray(32) As Byte
        Dim x As Integer
        StringArray = GetBytes(BlPos * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.Name, 32)

        For x = LBound(StringArray) To UBound(StringArray)
            If StringArray(x) = 0 Or StringArray(x) = &HF Then
                Exit For
            End If
            strTemp = strTemp + Chr(StringArray(x))
        Next x

        Return strTemp
    End Function

    Public Function ID(ByVal BlPos As Integer) As Integer
        Dim IdArray(0 To 3) As Byte
        If BlPos = 0 Then Return 0 : Exit Function
        Array.Copy(BattleListCache, BlPos * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.Id, IdArray, 0, 4)
        Return BitConverter.ToInt32(IdArray, 0)
    End Function
#End Region

#Region "Position"
    Public Function X(ByVal BlPos As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(BlPos * Client.Addresses.Battlelist.Step + TClient.Addresses.Battlelist.X, 4), 0)
    End Function

    Public Function Y(ByVal BlPos As Integer) As Integer
        Dim Ty As Integer = BitConverter.ToInt32(GetBytes(BlPos * Client.Addresses.Battlelist.Step + TClient.Addresses.Battlelist.Y, 4), 0)
        Return Ty
    End Function

    Public Function Z(ByVal BlPos As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(BlPos * Client.Addresses.Battlelist.Step + TClient.Addresses.Battlelist.Z, 4), 0)
    End Function
#End Region

#Region "Outfit, BlackSquare, Skull"
    Public Function Outfit(ByVal BlPos As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(BlPos * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.Outfit, 4), 0)
    End Function

    Public Function BlackSquare(ByVal BlPos As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(BlPos * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.BlackSquare + Client.Addresses.Player.extraOffset, 4), 0)
    End Function

    Public Function Skull(ByVal BlPos As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(BlPos * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.Skull + Client.Addresses.Player.extraOffset, 4), 0)
    End Function
#End Region

#Region "Health, Visible, Speed"
    Public Function Health(ByVal Bl As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(Bl * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.HpBar + Client.Addresses.Player.extraOffset, 4), 0)
    End Function

    Public Function Speed(ByVal Bl As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(Bl * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.Walkspeed + Client.Addresses.Player.extraOffset, 4), 0)
    End Function

    Public Function Visible(ByVal Blist As Integer) As Boolean
        Dim visibles As Integer = BitConverter.ToInt32(GetBytes(Blist * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.Visible + Client.Addresses.Player.extraOffset, 4), 0)
        If visibles = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Direction(ByVal Bl As Integer) As Byte
        Return GetBytes(Bl * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.Direction, 1)(0)
    End Function
#End Region

#Region "Is __"
    Public ReadOnly Property IsAttacking(ByVal bl As Integer)
        Get
            If ((GetTickCount - Client.ReadInt(Client.Addresses.Client.Starttime)) - BlackSquare(bl)) < 1000 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property IsPlayer(ByVal bl As Integer) As Boolean
        Get
            If ID(bl) < &H40000000 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Function isWalking(ByVal bl As Integer) As Integer
        Return BitConverter.ToInt32(GetBytes(bl * Client.Addresses.Battlelist.Step + Client.Addresses.Battlelist.IsWalking, 4), 0)
    End Function

    Public Function IsVisible(ByVal Blist As Integer) As Boolean
        Dim hp As Integer = Health(Blist)
        Dim vis As Boolean = Visible(Blist)
        If hp > 0 And vis Then
            Dim dx As Integer = Math.Abs(TClient.Self.X - X(Blist))
            Dim dy As Integer = Math.Abs(TClient.Self.Y - Y(Blist))
            If dx < 7 AndAlso dy < 5 Then
                If TClient.Self.Z = Z(Blist) Then
                    Return True
                End If
            End If
        End If

        Return False
    End Function

    Public Function IsVisible(ByVal Blist As Integer, ByVal Range As Short) As Boolean
        If Visible(Blist) Then
            If Health(Blist) > 0 Then
                If Math.Abs(Client.Self.X - X(Blist)) <= Range Then
                    If Math.Abs(Client.Self.Y - Y(Blist)) <= Range Then
                        If Client.Self.Z = Z(Blist) Then
                            Return True
                        End If
                    End If
                End If
            End If
        End If
        Return False
    End Function

    Public Function IsVisibleNoZ(ByVal Blist As Integer, ByVal Range As Short) As Boolean
        If Visible(Blist) Then
            If Health(Blist) > 0 Then
                If Math.Abs(Client.Self.X - X(Blist)) <= Range Then
                    If Math.Abs(Client.Self.Y - Y(Blist)) <= Range Then
                        Return True
                    End If
                End If
            End If
        End If
        Return False
    End Function

    Public Function IsVisibleNoZ(ByVal Blist As Integer) As Boolean
        If Visible(Blist) Then
            If Health(Blist) > 0 Then
                If Math.Abs(Client.Self.X - X(Blist)) <= 7 Then
                    If Math.Abs(Client.Self.Y - Y(Blist)) <= 5 Then
                        Return True
                    End If
                End If
            End If
        End If
        Return False
    End Function
#End Region
#End Region

#Region "Properties by NAME"
#Region "Name and ID"

    Public Function ID(ByVal Name As String) As Integer
        Return ID(GetBl(Name))
    End Function
#End Region

#Region "Position"
    Public Function X(ByVal Name As String) As Integer
        Return X(GetBl(Name))
    End Function

    Public Function Y(ByVal Name As String) As Integer
        Return Y(GetBl(Name))
    End Function

    Public Function Z(ByVal Name As String) As Integer
        Return Z(GetBl(Name))
    End Function
#End Region

#Region "Outfit, BlackSquare, Skull"
    Public Function Outfit(ByVal Name As String) As Integer
        Return Outfit(GetBl(Name))
    End Function

    Public Function BlackSquare(ByVal Name As String) As Integer
        Return BlackSquare(GetBl(Name))
    End Function

    Public Function Skull(ByVal Name As String) As Integer
        Return Skull(GetBl(Name))
    End Function
#End Region

#Region "Health, Visible"
    Public Function Health(ByVal Name As String) As Integer
        Return Z(Health(Name))
    End Function

    Public Function Visible(ByVal Name As String) As Boolean
        Return Visible(GetBl(Name))
    End Function

    Public Function Direction(ByVal Name As String) As Boolean
        Return Direction(GetBl(Name))
    End Function
#End Region

#Region "Is __"
    Public ReadOnly Property IsPlayer(ByVal Name As String) As Boolean
        Get
            Return IsPlayer(GetBl(Name))
        End Get
    End Property

    Public Function isWalking(ByVal Name As String) As Integer
        Return isWalking(GetBl(Name))
    End Function

    Public Function IsVisible(ByVal Name As String) As Boolean
        Return IsVisible(GetBl(Name))
    End Function

    Public Function IsVisibleNoZ(ByVal Name As String) As Boolean
        Return IsVisibleNoZ(GetBl(Name))
    End Function
#End Region

#End Region


    Public Function PosByID(ByVal id As Integer)
        For i = 1 To Length
            If Me.ID(i) = id Then
                Return i
            End If
        Next

        Return 0
    End Function
End Class
