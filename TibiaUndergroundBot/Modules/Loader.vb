Imports Crownwood.Magic.Docking
Imports Crownwood.Magic.Menus
Public Module Loader
    Public Sub LoadTUGBotForms(ByVal l As System.Windows.Forms.Form)
        Dim LoadText As String = "Loading Forms... [{0}]"

        Forms.Add(New FormInfo("Walker", CavebotWalker))
        Forms.Add(New FormInfo("Attacker", CaveBotAttacker))
        Forms.Add(New FormInfo("Looter", CavebotLooter))
        Forms.Add(New FormInfo("HUD", HeadsUpDisplay))
        Forms.Add(New FormInfo("Hotkeys", HotkeysForm))
        Forms.Add(New FormInfo("Icons", Icons))
        Forms.Add(New FormInfo("Tools", Tools))
        Forms.Add(New FormInfo("Support", Support))
        Forms.Add(New FormInfo("Magic", Magic))
        Forms.Add(New FormInfo("War", War))
        'Forms.Add(New FormInfo("Walker", Profile))
        Forms.Add(New FormInfo("Alarms", Alarms))
        Forms.Add(New FormInfo("Trainer", Trainer))

        For Each fi As FormInfo In Forms
            CType(l, Load).LoadLabel.Text = System.String.Format(LoadText, fi.Name)
            CType(l, Load).LoadLabel.Refresh()
            fi.Form.Show()
            fi.Form.Hide()
            fi.Form.TopMost = True
        Next
    End Sub
End Module
