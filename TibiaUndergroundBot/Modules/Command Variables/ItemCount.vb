Module ItemCount
    Private ItemCounts As New Dictionary(Of String, Integer)

    Public Function GetItemCount(ByVal Name As String) As Integer
        If ItemCounts.ContainsKey(Name.ToLower) Then
            Return ItemCounts(Name.ToLower)
        Else
            Return 0
        End If
    End Function

    Public Sub SetItemCount(ByVal Name As String, ByVal Count As Integer)
        If ItemCounts.ContainsKey(Name.ToLower) Then
            ItemCounts(Name.ToLower) = Count
        Else
            ItemCounts.Add(Name.ToLower, Count)
        End If
    End Sub
End Module
