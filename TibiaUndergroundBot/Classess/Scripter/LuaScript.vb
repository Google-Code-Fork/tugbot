'Imports LuaInterface
Imports System.Threading
Public Class LuaScript
    '    ' Lua interpreter
    '    ' Private lua As Lua
    '    'Threading and variables
    '    Private LuaThread As New Thread(AddressOf RunScript)
    '    Public ID As Integer
    '    Private Name As String
    '    Private Script As String
    '    Private Aborted As Boolean = False
    '    'Delegates for error handling/finishing
    '    Public Delegate Sub ErrorFunc(ByVal TiD As Integer, ByVal ScriptName As String, ByVal Er As String)
    '    Public Delegate Sub FinishedFunc(ByVal TiD As Integer)
    '    Public ErrorOccured As ErrorFunc
    '    Public Finished As FinishedFunc
    '    ' function pointers to functions in Lua
    '    Public Delegate Function CreatureSay(ByVal Name As String, ByVal Text As String)
    '    Public Delegate Sub CustomEventDelegate(ByVal args As String())

    '    Public RaiseCreatureSay As CreatureSay

    '#Region "Construct"
    '    Public Sub New(ByVal Scrpt As String, ByVal ThreadID As Integer, ByVal Sname As String)
    '        Me.ID = ThreadID
    '        Me.Script = Scrpt
    '        Me.Name = Sname


    '        lua = New Lua()
    '        For Each K As String In ItemShortcuts.Keys
    '            lua(K) = ItemShortcuts(K)
    '        Next

    '        For Each K As String In SpellShortcuts.Keys
    '            lua(K) = SpellShortcuts(K)
    '        Next
    '        lua("Self") = TClient.Self
    '        LuaThread.Start()
    '    End Sub
    '#End Region

    '#Region "Run and handle errors"
    '    Public ReadOnly Property Code()
    '        Get
    '            Return Script
    '        End Get
    '    End Property

    '    Public Sub KillScript()
    '        Try
    '            Aborted = True
    '            LuaThread.Abort()
    '            lua.Dispose()
    '            lua.Close()
    '            Finished(ID)
    '            lua = Nothing
    '            LuaThread = Nothing
    '        Catch
    '        End Try
    '    End Sub

    '    Private Sub RunScript()
    '        Try
    '            lua.DoString(Script)
    '        Catch ex As LuaException
    '            If Aborted Then Exit Try
    '            Try
    '                ErrorOccured(ID, ex.Message, Name) : GoTo Exits
    '                'ErrorOccured(ID, ParseLuaError(ex.ToString), Name)
    '            Catch e As Exception
    '                ErrorOccured(ID, "Unknown LUA Error Occured", Name) : GoTo Exits
    '            End Try
    '        Catch ex As Exception
    '            If Aborted Then Exit Try
    '            ErrorOccured(ID, "Unknown LUA Error Occured", Name) : GoTo Exits
    '        End Try

    'Exits:
    '        If Finished IsNot Nothing Then
    '            Finished(ID)
    '        End If
    '    End Sub
    '#End Region

    '#Region "Events"
    '    Public Sub CreatureSayEvent(ByVal name As String, ByVal text As String)
    '        Try
    '            RaiseCreatureSay = TryCast(lua.GetFunction(GetType(CreatureSay), "onCreatureSay"), CreatureSay)
    '            RaiseCreatureSay(name, text)
    '        Catch
    '        End Try
    '    End Sub

    '    Public Sub CustomEvent(ByVal EventFunction As String, ByVal args As String())
    '        Try
    '            Dim CustomEventAction As CustomEventDelegate = _
    '            TryCast(lua.GetFunction(GetType(CustomEventDelegate), EventFunction), CustomEventDelegate)
    '            CustomEventAction(args)
    '            CustomEventAction = Nothing
    '        Catch
    '        End Try
    '    End Sub
    '#End Region

End Class
