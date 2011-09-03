Module GUIInvokations
    Public Delegate Sub LoadSkinFromFileDelegate(ByVal Path As String)
    Public LoadSkinFromFile As New LoadSkinFromFileDelegate(AddressOf LoadSkinFromFilePrototype)
    Public Delegate Sub ChangeXRayCheckedDelegate(ByVal index As Integer, ByVal XRayEnabled As Boolean)
    Public ToggleXRayCheckbox As New ChangeXRayCheckedDelegate(AddressOf ToggleXRayPrototype)

    Public Sub ToggleXRayPrototype(ByVal index As Integer, ByVal XRayEnabled As Boolean)
        If Tools.EnableXray.Checked <> XRayEnabled Then
            Tools.EnableXray.Checked = XRayEnabled
        End If
    End Sub
End Module
