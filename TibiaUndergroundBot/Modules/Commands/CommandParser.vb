Imports System.Text.RegularExpressions
Public Class CommandParser
    Private _Actions As New List(Of Action)

    Public Property Actions() As List(Of Action)
        Get
            Return _Actions
        End Get
        Set(ByVal value As List(Of Action))
            _Actions = value
        End Set
    End Property

    Public Shared Function ParseCommand(ByVal Input As String) As CommandParser
        Dim Ret As New CommandParser
        Dim TempAction As New Action

        'Split commands, sperated with ||
        Dim Commands As MatchCollection = Regex.Matches(Input, "([^|]*)|([|]{2})")

        For Each S As Match In Commands
            If S.Value.Trim = String.Empty Then Continue For
            Dim cmd As String = S.Value.Trim 'This is the entire command
            TempAction = New Action 'the action representing this command
            TempAction.fullString = cmd
            TempAction.Command = cmd.Trim.Split(" ")(0) 'this is the command, not including args and flags
            cmd = cmd.Remove(0, TempAction.Command.Length).Trim 'remove the command so we now have all the args

            'Get all the args from the command
            Dim Args As MatchCollection = Regex.Matches(cmd, "(-{0,1}[a-zA-Z]+)|((?:[^\\]|^)""([^""]*|\\"")*[^\\]"")|([0-9]+)|({[a-zA-Z]+})")


            For acount As Integer = 0 To Args.Count - 1
                Dim a As Match = Args(acount)
                Dim TempArg As String = String.Empty
                TempArg = a.Value.TrimStart(New Char() {"""", " "}).TrimEnd(New Char() {"""", " "})

                'if this arg isnt blank
                If TempArg.Trim <> String.Empty Then
                    'Here we will format the display strings
                    'add when in bot

                    'is this a flag?
                    If TempArg.StartsWith("-") Then
                        Dim tempflag As New Flag(TempArg)
                        'if so, lets get args for it.
                        Dim LookAtArg As Integer = acount + 1
                        Do While LookAtArg < Args.Count AndAlso Not Args(LookAtArg).Value.StartsWith("-")
                            Dim tempFlagArg As String = Args(LookAtArg).Value.TrimStart(New Char() {"""", " "}).TrimEnd(New Char() {"""", " "})
                            If tempFlagArg <> String.Empty Then
                                'Here we will format the display strings
                                'add when in bot
                                tempflag.Args.Add(tempFlagArg.Trim.Replace("\""", """"))
                            End If
                            LookAtArg += 1
                        Loop

                        TempAction.Flags.Add(tempflag)
                        If LookAtArg - 1 < Args.Count Then
                            acount = LookAtArg - 1
                            Continue For
                        Else
                            Exit For
                        End If
                    End If


                    'Make the \" (delimited quotes) into just "
                    TempAction.Args.Add(TempArg.Trim.Replace("\""", """"))
                End If
            Next

            Ret.Actions.Add(TempAction)
        Next

        Return Ret
    End Function


End Class

Public Class Flag
    Private _Args As New List(Of String)
    Public Sub New(ByVal Command As String)
        Me.Command = Command
    End Sub

    Public Command As String
    Public Property Args() As List(Of String)
        Get
            Return _Args
        End Get
        Set(ByVal value As List(Of String))
            _Args = value
        End Set
    End Property
End Class

Public Class Action
    Private _Args As New List(Of String)
    Public Command As String
    Public fullString As String
    Public bname As String
    Public Property Args() As List(Of String)
        Get
            Return _Args
        End Get
        Set(ByVal value As List(Of String))
            _Args = value
        End Set
    End Property

    Private _Flags As New List(Of Flag)
    Public Property Flags() As List(Of Flag)
        Get
            Return _Flags
        End Get
        Set(ByVal value As List(Of Flag))
            _Flags = value
        End Set
    End Property
End Class
