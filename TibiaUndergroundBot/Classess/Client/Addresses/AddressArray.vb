
Public Class AddressArray
    Private ArrayDic As New Dictionary(Of String, Integer)

    Default Public Property Value(ByVal version As String)
        Get
            If ArrayDic.ContainsKey(version) Then
                Return ArrayDic(version)
            Else
                Return 0
            End If
        End Get
        Set(ByVal value)
            If Not ArrayDic.ContainsKey(version) Then
                ArrayDic.Add(version, value)
            End If
        End Set
    End Property
End Class