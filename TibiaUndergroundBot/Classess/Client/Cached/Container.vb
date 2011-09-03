Public Class Containers
#Region "Construct and Variables"
    Public Client As Client
    Public ContainerCahce(7872) As Byte

    Public Sub New(ByVal c As Client)
        Me.Client = c
    End Sub

    Public Sub Cache()
        SyncLock ContainerCahce
            ContainerCahce = Client.ReadBytes(Client.Addresses.Container.Start, 7872)
        End SyncLock
    End Sub

    Public Sub Update()
        Cache()
    End Sub
#End Region

    Public Function GetFreeSlot()
        For i = 1 To 16
            If Container(i).IsOpen Then Continue For
            Return i
        Next
        Return 16
    End Function

#Region "Properties"
    Default Public ReadOnly Property Container(ByVal Cont As Byte) As SubContainer
        Get
            Dim ret As SubContainer
            SyncLock ContainerCahce
                If Cont > 16 Then
                    ret = New SubContainer(Client, 16, ContainerCahce)
                ElseIf Cont < 1 Then
                    ret = New SubContainer(Client, 1, ContainerCahce)
                Else
                    ret = New SubContainer(Client, Cont, ContainerCahce)
                End If
            End SyncLock
            Return ret
        End Get
    End Property

    Public ReadOnly Property Count() As Byte
        Get
            Return 16
        End Get
    End Property
#End Region
End Class

Public Class SubContainer
#Region "Construct and Variables"
    Public ContainerNumber As Byte
    Public ContainerCahce(7872) As Byte
    Public Client As Client

    Public Sub New(ByVal client As Client, ByVal Container As Byte, ByVal Cache As Byte())
        Me.ContainerNumber = Container - 1
        Me.ContainerCahce = Cache
        Me.Client = client
    End Sub

    Private Function GetBytes(ByVal start As Integer, ByVal length As Integer) As Byte()
        Dim BArray(length) As Byte
        Array.Copy(ContainerCahce, start, BArray, 0, length)
        Return BArray
    End Function
#End Region

#Region "Static properties"
    Public ReadOnly Property NumberOfItems() As Byte
        Get
            Try
                Return GetBytes(Client.Addresses.Container.NumberofItems + (492 * ContainerNumber), 1)(0)
            Catch
            End Try
        End Get
    End Property

    Public ReadOnly Property Size() As Byte
        Get
            Try
                Return GetBytes(Client.Addresses.Container.ContainerSize + (492 * ContainerNumber), 1)(0)
            Catch
            End Try
        End Get
    End Property

    Public ReadOnly Property IsOpen() As Byte
        Get
            Try
                Return GetBytes(Client.Addresses.Container.IsOpen + (492 * ContainerNumber), 1)(0)
            Catch
            End Try
        End Get
    End Property

    Public ReadOnly Property HasParent() As Byte
        Get
            Try
                Return GetBytes(Client.Addresses.Container.HasParent + (492 * ContainerNumber), 1)(0)
            Catch
            End Try
        End Get
    End Property

    Public ReadOnly Property Id() As Short
        Get
            Try
                Return BitConverter.ToInt16(GetBytes(Client.Addresses.Container.Icon + (492 * ContainerNumber), 2), 0)
            Catch
            End Try
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Try
                Dim strTemp As String = String.Empty
                Dim StringArray(32) As Byte
                Dim x As Integer
                StringArray = GetBytes(ContainerNumber * 492 + Client.Addresses.Container.Name, 32)

                For x = LBound(StringArray) To UBound(StringArray)
                    If StringArray(x) = 0 Or StringArray(x) = &HF Then
                        Exit For
                    End If
                    strTemp = strTemp + Chr(StringArray(x))
                Next x

                Return strTemp
            Catch
                Return ""
            End Try
        End Get
    End Property
#End Region

#Region "Dynamic Properties"
    Public ReadOnly Property Item(ByVal Slot As Byte) As ContainerItem
        Get
            Try
                Slot -= 1
                Dim I As New ContainerItem(Client.Self, _
                BitConverter.ToInt16(GetBytes( _
                (Client.Addresses.Container.Item + (Slot * 12) + (492 * ContainerNumber)), 2), 0), _
                BitConverter.ToInt16(GetBytes( _
                (Client.Addresses.Container.ItemCount + (Slot * 12) + (492 * ContainerNumber)), 2), 0), _
                ContainerNumber, Slot)

                Return I
            Catch
                Return Nothing
            End Try
        End Get
    End Property
#End Region
End Class

Public Class ContainerItem
#Region "Construct and Variables"
    Private cnt As Byte
    Private ids As Short
    Private self As Self
    Private cont As Byte
    Private spot As Byte


    Public Sub New(ByVal self As Self, ByVal id As Short, ByVal count As Short, ByVal contnum As Byte, ByVal spot As Byte)
        Me.self = self
        Me.ids = id
        Me.cnt = count
        Me.cont = contnum
        Me.spot = spot
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property ID() As Short
        Get
            Return ids
        End Get

    End Property

    Public ReadOnly Property Count() As Byte
        Get
            Return cnt
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub MoveToSlot(ByVal slot As Byte)
        If slot > 10 Then slot = 10
        self.MoveFromContainerToSlot(ids, cnt, cont, spot, slot)
    End Sub

    Public Sub MoveToContainer(ByVal contnum As Byte, ByVal slotnum As Byte)
        If contnum > 16 Then contnum = 16
        self.MoveFromContainerToContainer(ids, cnt, cont, spot, contnum - 1, slotnum - 1)
    End Sub

    Public Sub MoveToGround(ByVal Pos As Location)
        self.MoveFromContainerToGround(ids, cnt, cont, spot, 1, Pos)
    End Sub

    Public Sub Use()
        self.UseItemFromInventory(cont, spot, ids)
    End Sub
#End Region
End Class