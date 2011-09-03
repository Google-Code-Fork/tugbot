Imports System.Collections, System.Xml
Public Module Shortcuts
    Public SpellShortcuts As New Dictionary(Of String, String)
    Public ItemShortcuts As New Dictionary(Of String, Integer)

    Public Function FormatItem(ByVal shortcut As String) As Short
        If shortcut = Nothing Then Return Nothing
        If Not shortcut.StartsWith("{") Or Not shortcut.EndsWith("}") Then Return ParseShort(shortcut)
        Dim ShortC As String = shortcut.Replace("{", "").Replace("}", "").ToLower

        If ItemShortcuts.ContainsKey(ShortC) Then
            Return ItemShortcuts(ShortC)
        End If

        Try
            Return ParseShort(shortcut)
        Catch
            Return 0
        End Try
    End Function

    Public Function FormatSpell(ByVal shortcut As String) As String
        If Not shortcut.StartsWith("{") Or Not shortcut.EndsWith("}") Then Return shortcut
        Dim ShortC As String = shortcut.Replace("{", "").Replace("}", "").ToLower

        If SpellShortcuts.ContainsKey(ShortC) Then
            Return SpellShortcuts(ShortC)
        End If

        Return shortcut
    End Function

    Public Sub LoadShortcuts()
        Dim TempItem As ItemShortcut
        Dim TempSpell As SpellShortcut

        Dim Document As New XmlDocument

        If Not IO.File.Exists(Application.StartupPath & "\Data\Shortcuts.xml") Then MsgBox("Shortcuts.xml was not found!") : End : Application.Exit()

        Try
            SpellShortcuts.Clear()
            ItemShortcuts.Clear()
            Document.Load(Application.StartupPath & "\Data\Shortcuts.xml")

            Dim Items As XmlNodeList = Document.GetElementsByTagName("Item")
            Dim Spells As XmlNodeList = Document.GetElementsByTagName("Spell")

            For Each Node As XmlElement In Items
                TempItem = New ItemShortcut(ParseInteger(Node.GetAttribute("ID")), Node.GetAttribute("Shortcuts").ToLower)

                For Each K As String In TempItem.Shortcuts
                    If ItemShortcuts.ContainsKey(K) Then
                        MsgBox("Could not load Shortcuts.xml! The shortcut """ & K & """ Occured on two different items!")
                        End
                        Application.Exit()
                    End If
                Next

                For Each K As String In TempItem.Shortcuts
                    ItemShortcuts.Add(K, TempItem.ItemID)
                Next
            Next

            For Each Node As XmlElement In Spells
                TempSpell = New SpellShortcut(Node.GetAttribute("Words"), Node.GetAttribute("Shortcuts").ToLower)

                For Each ke As String In ItemShortcuts.Keys
                    For Each K As String In TempSpell.Shortcuts
                        If K = ke Then
                            MsgBox("Could not load Shortcuts.xml!" & vbNewLine & "The shortcut """ & K & """ Occured on the item " _
                                           & ItemShortcuts(ke) & " and on the spell """ & TempSpell.Spell & """.")
                            End
                            Application.Exit()
                        End If
                    Next
                Next

                For Each K As String In TempSpell.Shortcuts
                    If SpellShortcuts.ContainsKey(K) Then
                        MsgBox("Could not load Shortcuts.xml! The shortcut """ & K & """ Occured on two different spells!")
                        End
                        Application.Exit()
                    End If
                Next

                For Each K As String In TempSpell.Shortcuts
                    SpellShortcuts.Add(K, TempSpell.Spell)
                Next
            Next

        Catch Ex As Exception
            MsgBox("An unknown error occured when loading Shortcuts.xml!")
            End
            Application.Exit()
        End Try
    End Sub

End Module

Public Class SpellShortcut
    Public Spell As String
    Public Shortcuts As String()

    Public Sub New(ByVal Spell As String, ByVal Shortcuts As String)
        Me.Spell = Spell
        Me.Shortcuts = Shortcuts.Replace(" ", "").Split(",")
    End Sub
End Class

Public Class ItemShortcut
    Public ItemID As Integer
    Public Shortcuts As String()

    Public Sub New(ByVal ID As Integer, ByVal Shortcuts As String)
        Me.ItemID = ID
        Me.Shortcuts = Shortcuts.Replace(" ", "").Split(",")
    End Sub
End Class
