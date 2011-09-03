Public Class Load

    Private Sub Load_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserName.Text = System.String.Format(UserName.Text, CUser)
        SerialKey.Text = System.String.Format(SerialKey.Text, CSerial)
    End Sub
End Class