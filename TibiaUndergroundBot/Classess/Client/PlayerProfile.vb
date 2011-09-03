Public Class PlayerProfile
    '    'Exp/Magic
    '    Public InitialExp As UInt32
    '    Public InitialMagic As UShort

    '    'Client
    '    Private Client As Client

    '    'Validation
    '    Private _ValidProfile As Boolean = False
    '    Private ValidationThread As New TimedThread(100, New TimedThread.RunThreadDelegate(AddressOf ValidateProfile), False)

    '    'Options
    '    Public AutoSave As Boolean = True
    '    Public AutoLoad As Boolean = True
    '    Public PauseLoad As Boolean = True

    '    'Skills
    '    Public InitialAxe As UShort
    '    Public InitialSword As UShort
    '    Public InitialClub As UShort
    '    Public InitialDist As UShort
    '    Public InitialShield As UShort
    '    Public InitialFist As UShort
    '    Public InitialFish As UShort

    '    'World/Name
    '    Public Name As String
    '    Public World As String

    '    'Favorite spell
    '    Private UsedSpells As New Dictionary(Of String, UInt32)

    '    Public Sub New(ByVal c As Client)
    '        Me.Client = c
    '    End Sub

    '#Region "Validate"
    '    Private Sub ValidateProfile()
    '        ValidCriticalSection.Enter()
    '        If Me.Client.Self.Name <> Name OrElse Client.Self.Name = "Logged out" Then
    '            _ValidProfile = False
    '            ValidationThread.Pause()
    '        Else
    '            _ValidProfile = True
    '        End If
    '        ValidCriticalSection.Leave()
    '    End Sub

    '    Public ReadOnly Property ValidProfile() As Boolean
    '        Get
    '            ValidCriticalSection.Enter()
    '            Dim ret As Boolean = _ValidProfile
    '            ValidCriticalSection.Leave()
    '            Return ret
    '        End Get
    '    End Property

    '    Private Function ValidName() As Boolean
    '        If Me.Client.Self.Name = "Loggout out" Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End Function
    '#End Region

    '#Region "Favorite Spell"
    '    Public Sub IncremetSpell(ByVal spell As String)
    '        If UsedSpells.ContainsKey(spell.ToLower) Then
    '            UsedSpells(spell.ToLower) += 1
    '        Else
    '            UsedSpells.Add(spell.ToLower, 1)
    '        End If
    '    End Sub

    '    Public Function GetFavoriteSpell() As String
    '        Dim HighSpell As String = "Undefined"
    '        Dim HighCount As UInt32 = 0

    '        For Each i As String In UsedSpells.Keys
    '            If UsedSpells(i) > HighCount Then
    '                HighSpell = i
    '                HighCount = UsedSpells(i)
    '            End If
    '        Next

    '        Return HighSpell
    '    End Function
    '#End Region


    '#Region "Create Profile/Save Profile"
    '    Public Sub Create(ByVal filename As String)
    '        If filename <> "Default" Then
    '            If System.IO.File.Exists(Application.StartupPath & "\Profiles\" & filename & ".ini") Then
    '                System.IO.File.Copy(Application.StartupPath & "\Profiles\Default.ini", _
    '                    Application.StartupPath & "\Profiles\" & filename & ".ini")
    '            Else
    '                Create("Default")
    '                Create(filename)
    '            End If
    '        Else
    '            System.IO.File.Create(Application.StartupPath & "\Profiles\" & _
    '                             filename & ".ini")
    '        End If
    '    End Sub

    '    Public Sub SaveDefault()
    '        Save(False, "Default")
    '    End Sub

    '    Public Sub AutoSaveCurrent()
    '        Save(True, Me.Client.Self.Name & "-" & Me.Client.Self.World)
    '    End Sub

    '    Public Sub SaveCurrent()
    '        Save(False, Me.Client.Self.Name & "-" & Me.Client.Self.World)
    '    End Sub

    '    Private Sub Save(ByVal IsAuto As Boolean, ByVal Filename As String)
    '        If (Not ValidProfile AndAlso Filename <> "Default") _
    '        OrElse (IsAuto And Not AutoSave) Then Exit Sub

    '        If Not System.IO.File.Exists(Application.StartupPath & "\Profiles\" & _
    '        Filename & ".ini") Then Create(Filename)

    '        Dim Ini As New iniFile((Application.StartupPath & "\Profiles\" & _
    '                                     Filename & ".ini"))

    '        Ini.WriteString("ProfileDecription", "Name", Me.Client.Self.Name)
    '        Ini.WriteString("ProfileDecription", "World", Me.Client.Self.World)


    '        Ini.WriteBoolean("SavingAndLoading", "AutoSave", Me.AutoSave)
    '        Ini.WriteBoolean("SavingAndLoading", "AutoLoad", Me.AutoLoad)
    '        Ini.WriteBoolean("SavingAndLoading", "PauseLoad", Me.PauseLoad)


    '        Ini.WriteInteger("InitialValues", "Exp", Me.InitialExp)
    '        Ini.WriteInteger("InitialValues", "Magic", Me.InitialMagic)


    '        Ini.WriteShort("InitialValues", "Axe", Me.InitialAxe)
    '        Ini.WriteShort("InitialValues", "Sword", Me.InitialSword)
    '        Ini.WriteShort("InitialValues", "Club", Me.InitialClub)
    '        Ini.WriteShort("InitialValues", "Distance", Me.InitialDist)
    '        Ini.WriteShort("InitialValues", "Shield", Me.InitialShield)
    '        Ini.WriteShort("InitialValues", "Fist", Me.InitialFist)
    '        Ini.WriteShort("InitialValues", "Fish", Me.InitialFish)


    '        SaveControls("Attacker", CaveBotAttacker.Controls, Ini)
    '        SaveControls("Walker", CavebotWalker.Controls, Ini)
    '        SaveControls("HUD", HeadsUpDisplay.Controls, Ini)
    '        SaveControls("Hotkeys", HotkeysForm.Controls, Ini)
    '        'SaveControls("Icons", Icons.Controls, Ini)
    '        SaveControls("Magic", Magic.Controls, Ini)
    '        'SaveControls("Scripter", Scripter.Controls, Ini)


    '        SaveControls("Support", Support.Controls, Ini)
    '        SaveControls("Tools", Tools.Controls, Ini)
    '        'SaveControls("War", War.Controls, Ini)

    '    End Sub


    '    Private Sub SaveControls(ByVal name As String, ByVal Contc As Control.ControlCollection, ByVal ini As iniFile)
    '        For Each C As Control In Contc
    '            Select Case C.GetType.Name
    '                Case "TextBox"
    '                    ini.WriteString(name, C.Name, CType(C, TextBox).Text)
    '                Case "ComboBox"
    '                    ini.WriteShort(name, C.Name, CType(C, ComboBox).SelectedIndex)
    '                Case "CheckBox"
    '                    ini.WriteBoolean(name, C.Name, CType(C, CheckBox).Checked)
    '                Case "RadioButton"
    '                    ini.WriteBoolean(name, C.Name, CType(C, RadioButton).Checked)
    '                Case "NumericUpDown"
    '                    ini.WriteShort(name, C.Name, CType(C, NumericUpDown).Value)
    '            End Select

    '            SaveControls(name, C.Controls, ini)
    '        Next
    '    End Sub
    '#End Region

    '#Region "Load Profile"
    '    Public Sub LoadCurrent()
    '        If ValidName() Then
    '            Load(Me.Client.Self.Name & "-" & Me.Client.Self.World)
    '        End If
    '    End Sub

    '    Public Sub AutoLoadCurrent()
    '        If ValidName() Then
    '            Load(Me.Client.Self.Name & "-" & Me.Client.Self.World)
    '        End If
    '    End Sub

    '    Public Sub LoadDefault()
    '        Load("Default")
    '    End Sub

    '    Private Sub Load(ByVal Filename As String)
    '        ValidCriticalSection.Enter() : _ValidProfile = False : ValidCriticalSection.Leave()
    '        If Not System.IO.File.Exists(Application.StartupPath & "\Profiles\" & _
    '        Filename & ".ini") Then Create(Filename)

    '        Dim Ini As New iniFile((Application.StartupPath & "\Profiles\" & _
    '                                     Filename & ".ini"))

    '        'Lets make sure its okay to load it
    '        Me.AutoLoad = Ini.GetBoolean("SavingAndLoading", "AutoLoad", True)

    '        If Not Me.AutoLoad Then
    '            Exit Sub
    '        End If

    '        'Lets load it now
    '        Me.AutoSave = Ini.GetBoolean("SavingAndLoading", "AutoSave", True)
    '        Me.PauseLoad = Ini.GetBoolean("SavingAndLoading", "PauseLoad", True)

    '        Me.Name = Ini.GetString("ProfileDescription", "Name", "")
    '        Me.World = Ini.GetString("ProfileDescription", "World", "")

    '        If Me.World = "" OrElse Me.Name = "" Then
    '            Me.World = Me.Client.Self.World
    '            Me.Name = Me.Client.Self.Name

    '            Ini.WriteString("ProfileDescription", "Name", Me.Name)
    '            Ini.WriteString("ProfileDescription", "World", Me.World)
    '        End If


    '        Me.InitialExp = Ini.GetInteger("InitialValues", "Exp", Me.Client.Self.Level)
    '        Me.InitialMagic = Ini.GetInteger("InitialValues", "Magic", Me.Client.Self.MagicLevel)


    '        Me.InitialAxe = Ini.GetShort("InitialValues", "Axe", Me.Client.Self.Skills.Axe)
    '        Me.InitialSword = Ini.GetShort("InitialValues", "Sword", Me.Client.Self.Skills.Sword)
    '        Me.InitialClub = Ini.GetShort("InitialValues", "Club", Me.Client.Self.Skills.Club)
    '        Me.InitialDist = Ini.GetShort("InitialValues", "Distance", Me.Client.Self.Skills.Distance)
    '        Me.InitialShield = Ini.GetShort("InitialValues", "Shield", Me.Client.Self.Skills.Shield)
    '        Me.InitialFist = Ini.GetShort("InitialValues", "Fist", Me.Client.Self.Skills.Fist)
    '        Me.InitialFish = Ini.GetShort("InitialValues", "Fish", Me.Client.Self.Skills.Fishing)


    '        LoadControls("Support", Support.Controls, Ini)

    '        ValidationThread.Start()
    '    End Sub

    '    Private Sub LoadControls(ByVal name As String, ByVal Contc As Control.ControlCollection, ByVal ini As iniFile)
    '        For Each C As Control In Contc
    '            Select Case C.GetType.Name
    '                Case "TextBox"
    '                    CType(C, TextBox).Text = _
    '                    ini.GetString(name, C.Name, "")
    '                Case "ComboBox"
    '                    Try
    '                        CType(C, ComboBox).SelectedIndex = _
    '                       ini.GetShort(name, C.Name, 0)
    '                    Catch
    '                    End Try
    '                Case "CheckBox"
    '                    CType(C, CheckBox).Checked = _
    '                       ini.GetBoolean(name, C.Name, False)
    '                Case "RadioButton"
    '                    CType(C, RadioButton).Checked = _
    '                       ini.GetBoolean(name, C.Name, False)
    '                Case "NumericUpDown"
    '                    CType(C, NumericUpDown).Value = _
    '                       ini.GetShort(name, C.Name, CType(C, NumericUpDown).Minimum)
    '            End Select

    '            LoadControls(name, C.Controls, ini)
    '        Next
    '    End Sub

    '#End Region

End Class


