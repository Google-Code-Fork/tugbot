Module DisplayVars
    Public Variable As New Dictionary(Of String, System.Func(Of String))

#Region "functions"
    Private Function hp() As String
        Return TClient.Self.Health
    End Function
    Private Function maxhp() As String
        Return TClient.Self.MaxHealth
    End Function
    Private Function mana() As String
        Return TClient.Self.Mana
    End Function
    Private Function maxmana() As String
        Return TClient.Self.MaxMana
    End Function
    Private Function level() As String
        Return TClient.Self.Level
    End Function
    Private Function exp() As String
        Return TClient.Self.Exp
    End Function
    Private Function stamina() As String
        Return TClient.Self.Stamina
    End Function
    Private Function name() As String
        Return TClient.Self.Name
    End Function
    Private Function y() As String
        Return TClient.Self.Y
    End Function
    Private Function x() As String
        Return TClient.Self.X
    End Function
    Private Function z() As String
        Return TClient.Self.Z
    End Function
#End Region

    Public Sub InitializeRets()
        Variable.Add("&hp", New System.Func(Of String)(AddressOf hp))
        Variable.Add("&maxhp", New System.Func(Of String)(AddressOf maxhp))

        Variable.Add("&mana", New System.Func(Of String)(AddressOf mana))
        Variable.Add("&maxmana", New System.Func(Of String)(AddressOf maxmana))

        Variable.Add("&level", New System.Func(Of String)(AddressOf level))
        Variable.Add("&exp", New System.Func(Of String)(AddressOf exp))

        Variable.Add("&name", New System.Func(Of String)(AddressOf name))
        Variable.Add("&stamina", New System.Func(Of String)(AddressOf stamina))

        Variable.Add("&x", New System.Func(Of String)(AddressOf x))
        Variable.Add("&y", New System.Func(Of String)(AddressOf y))
        Variable.Add("&z", New System.Func(Of String)(AddressOf z))

        Variable.Add("&light", New System.Func(Of String)(AddressOf TClient.Screen.LightCheck))
        Variable.Add("&xray", New System.Func(Of String)(AddressOf TClient.Screen.XRayCheck))
        Variable.Add("&spy", New System.Func(Of String)(AddressOf TClient.Screen.SpyFloor))

        Variable.Add("&walker", New System.Func(Of String)(AddressOf CavebotWalker.Check))
        Variable.Add("&looter", New System.Func(Of String)(AddressOf CavebotLooter.Check))
        Variable.Add("&attacker", New System.Func(Of String)(AddressOf CaveBotAttacker.Check))

        Variable.Add("&state", New System.Func(Of String)(AddressOf TClient.CheckStatus))
    End Sub

    Public Function FormatDisplayString(ByVal str As String) As String
        Dim Splits As String() = str.Split(" ")
        For i = 0 To UBound(Splits)
            If Variable.ContainsKey(Splits(i).ToLower.Replace("""", "")) Then
                If Splits(i).ToLower.StartsWith("""") Then
                    Splits(i) = """" & Variable(Splits(i).ToLower.Replace("""", "")).DynamicInvoke(Nothing).ToString
                ElseIf Splits(i).ToLower.EndsWith("""") Then
                    Splits(i) = Variable(Splits(i).ToLower.Replace("""", "")).DynamicInvoke(Nothing).ToString & """"
                Else
                    Splits(i) = Variable(Splits(i).ToLower).DynamicInvoke(Nothing).ToString
                End If
            End If
        Next

        str = ""
        For s = 0 To UBound(Splits)
            str = str & Splits(s) & " "
        Next

        Return str.Remove(str.Length - 1, 1)
    End Function


End Module
