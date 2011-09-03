Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing

Public Class AStarPathFinder
#Region "Variables Declaration"

    Private mGrid As Byte(,) = Nothing
    Private direction As SByte(,) = New SByte(7, 1) {{0, -1}, {1, 0}, {0, 1}, {-1, 0}, {1, -1}, {1, 1}, _
     {-1, 1}, {-1, -1}}
    Private mOpen As New PriorityQueueB(Of PathFinderNode)(New ComparePFNode())
    Private mClose As New List(Of PathFinderNode)()
    Private mStop As Boolean = False
    Private mStopped As Boolean = True
    Private mHEstimate As Integer = 4
    Private m_modifiedItems As New Dictionary(Of UInteger, Byte)()
#End Region

#Region "Constructors"
    Public Sub New()
        mGrid = New Byte(17, 13) {}

        For y As Integer = 0 To mGrid.GetUpperBound(1) - 1
            For x As Integer = 0 To mGrid.GetUpperBound(0) - 1
                mGrid(x, y) = 0
            Next
        Next
    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property ModifiedItems() As Dictionary(Of UInteger, Byte)
        Get
            Return m_modifiedItems
        End Get
    End Property

    Public Property Grid() As Byte(,)
        Get
            Return mGrid
        End Get
        Set(ByVal value As Byte(,))
            mGrid = value
        End Set
    End Property

    Public ReadOnly Property Stopped() As Boolean
        Get
            Return mStopped
        End Get
    End Property

    Public Property HeuristicEstimate() As Integer
        Get
            Return mHEstimate
        End Get
        Set(ByVal value As Integer)
            mHEstimate = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub FindPathStop()
        mStop = True
    End Sub

    Public Function FindPath(ByVal start As Location, ByVal [end] As Location) As Boolean
        SyncLock Me
            Dim parentNode As PathFinderNode
            Dim found As Boolean = False
            Dim gridX As Integer = mGrid.GetUpperBound(0)
            Dim gridY As Integer = mGrid.GetUpperBound(1)

            mStop = False
            mStopped = False
            mOpen.Clear()
            mClose.Clear()

            parentNode.G = 0
            parentNode.H = mHEstimate
            parentNode.F = parentNode.G + parentNode.H
            parentNode.X = start.x
            parentNode.Y = start.y
            parentNode.PX = parentNode.X
            parentNode.PY = parentNode.Y
            mOpen.Push(parentNode)

            While mOpen.Count > 0 AndAlso Not mStop
                parentNode = mOpen.Pop()

                If parentNode.X = [end].x AndAlso parentNode.Y = [end].y Then
                    mClose.Add(parentNode)
                    found = True
                    Exit While
                End If

                'Lets calculate each successors
                For i As Integer = 0 To 7
                    Dim newNode As PathFinderNode
                    newNode.X = parentNode.X + direction(i, 0)
                    newNode.Y = parentNode.Y + direction(i, 1)

                    If newNode.X < 0 OrElse newNode.Y < 0 OrElse newNode.X >= gridX OrElse newNode.Y >= gridY Then
                        Continue For
                    End If

                    Dim newG As Integer = parentNode.G + mGrid(newNode.X, newNode.Y)

                    If newG = parentNode.G Then
                        'Unbrekeable
                        Continue For
                    End If

                    Dim foundInOpenIndex As Integer = -1
                    For j As Integer = 0 To mOpen.Count - 1
                        If mOpen(j).X = newNode.X AndAlso mOpen(j).Y = newNode.Y Then
                            foundInOpenIndex = j
                            Exit For
                        End If
                    Next
                    If foundInOpenIndex <> -1 AndAlso mOpen(foundInOpenIndex).G <= newG Then
                        Continue For
                    End If

                    Dim foundInCloseIndex As Integer = -1
                    For j As Integer = 0 To mClose.Count - 1
                        If mClose(j).X = newNode.X AndAlso mClose(j).Y = newNode.Y Then
                            foundInCloseIndex = j
                            Exit For
                        End If
                    Next
                    If foundInCloseIndex <> -1 AndAlso mClose(foundInCloseIndex).G <= newG Then
                        Continue For
                    End If

                    newNode.PX = parentNode.X
                    newNode.PY = parentNode.Y
                    newNode.G = newG
                    newNode.H = mHEstimate * (Math.Max(Math.Abs(start.x - [end].x), Math.Abs(start.y - [end].y)))
                    newNode.F = newNode.G + newNode.H
                    mOpen.Push(newNode)
                Next


                mClose.Add(parentNode)
            End While

            If found Then
                mStopped = True
                Return True
            End If

            mStopped = True
            Return False
        End SyncLock
    End Function
#End Region

#Region "Enum"

    Friend Enum PathFinderNodeType
        Start = 1
        [End] = 2
        Open = 4
        Close = 8
        Current = 16
        Path = 32
    End Enum

    Friend Enum HeuristicFormula
        Manhattan = 1
        MaxDXDY = 2
        DiagonalShortCut = 3
        Euclidean = 4
        EuclideanNoSQR = 5
        Custom1 = 6
    End Enum

#End Region

#Region "Interfaces"
    Friend Interface IPriorityQueue(Of T)
#Region "Methods"
        Function Push(ByVal item As T) As Integer
        Function Pop() As T
        Function Peek() As T
        Sub Update(ByVal i As Integer)
#End Region
    End Interface
#End Region


#Region "Structs"

    Friend Structure PathFinderNode
#Region "Variables Declaration"
        Public F As Integer
        Public G As Integer
        Public H As Integer
        ' f = gone + heuristic
        Public X As Integer
        Public Y As Integer
        Public PX As Integer
        ' Parent
        Public PY As Integer
#End Region
    End Structure

#End Region

#Region "Classes"

    Friend Class ComparePFNode
        Implements IComparer(Of PathFinderNode)
        Public Function Compare(ByVal x As PathFinderNode, ByVal y As PathFinderNode) As Integer Implements System.Collections.Generic.IComparer(Of TUGBot.AStarPathFinder.PathFinderNode).Compare
            If x.F > y.F Then
                Return 1
            ElseIf x.F < y.F Then
                Return -1
            End If
            Return 0
        End Function
    End Class

    Friend Class PriorityQueueB(Of T)
        Implements IPriorityQueue(Of T)
        Private InnerList As New List(Of T)()
        Private mComparer As IComparer(Of T)

#Region "Contructors"
        Public Sub New()
            mComparer = Comparer(Of T).[Default]
        End Sub

        Public Sub New(ByVal comparer As IComparer(Of T))
            mComparer = comparer
        End Sub

        Public Sub New(ByVal comparer As IComparer(Of T), ByVal capacity As Integer)
            mComparer = comparer
            InnerList.Capacity = capacity
        End Sub
#End Region

        Private Sub SwitchElements(ByVal i As Integer, ByVal j As Integer)
            Dim h As T = InnerList(i)
            InnerList(i) = InnerList(j)
            InnerList(j) = h
        End Sub

        Protected Overridable Function OnCompare(ByVal i As Integer, ByVal j As Integer) As Integer
            Return mComparer.Compare(InnerList(i), InnerList(j))
        End Function

        ''' <summary>
        ''' Push an object onto the PQ
        ''' </summary>
        ''' <param name="O">The new object</param>
        ''' <returns>The index in the list where the object is _now_. This will change when objects are taken from or put onto the PQ.</returns>
        Public Function Push(ByVal item As T) As Integer Implements IPriorityQueue(Of T).Push
            Dim p As Integer = InnerList.Count, p2 As Integer
            InnerList.Add(item)
            ' E[p] = O
            Do
                If p = 0 Then
                    Exit Do
                End If
                p2 = (p - 1) / 2
                If OnCompare(p, p2) < 0 Then
                    SwitchElements(p, p2)
                    p = p2
                Else
                    Exit Do
                End If
            Loop While True
            Return p
        End Function

        ''' <summary>
        ''' Get the smallest object and remove it.
        ''' </summary>
        ''' <returns>The smallest object</returns>
        Public Function Pop() As T Implements IPriorityQueue(Of T).Pop
            Dim result As T = InnerList(0)
            Dim p As Integer = 0, p1 As Integer, p2 As Integer, pn As Integer
            InnerList(0) = InnerList(InnerList.Count - 1)
            InnerList.RemoveAt(InnerList.Count - 1)
            Do
                pn = p
                p1 = 2 * p + 1
                p2 = 2 * p + 2
                If InnerList.Count > p1 AndAlso OnCompare(p, p1) > 0 Then
                    ' links kleiner
                    p = p1
                End If
                If InnerList.Count > p2 AndAlso OnCompare(p, p2) > 0 Then
                    ' rechts noch kleiner
                    p = p2
                End If

                If p = pn Then
                    Exit Do
                End If
                SwitchElements(p, pn)
            Loop While True

            Return result
        End Function

        ''' <summary>
        ''' Notify the PQ that the object at position i has changed
        ''' and the PQ needs to restore order.
        ''' Since you dont have access to any indexes (except by using the
        ''' explicit IList.this) you should not call this function without knowing exactly
        ''' what you do.
        ''' </summary>
        ''' <param name="i">The index of the changed object.</param>
        Public Sub Update(ByVal i As Integer) Implements IPriorityQueue(Of T).Update
            Dim p As Integer = i, pn As Integer
            Dim p1 As Integer, p2 As Integer
            Do
                ' aufsteigen
                If p = 0 Then
                    Exit Do
                End If
                p2 = (p - 1) / 2
                If OnCompare(p, p2) < 0 Then
                    SwitchElements(p, p2)
                    p = p2
                Else
                    Exit Do
                End If
            Loop While True
            If p < i Then
                Exit Sub
            End If
            Do
                ' absteigen
                pn = p
                p1 = 2 * p + 1
                p2 = 2 * p + 2
                If InnerList.Count > p1 AndAlso OnCompare(p, p1) > 0 Then
                    ' links kleiner
                    p = p1
                End If
                If InnerList.Count > p2 AndAlso OnCompare(p, p2) > 0 Then
                    ' rechts noch kleiner
                    p = p2
                End If

                If p = pn Then
                    Exit Do
                End If
                SwitchElements(p, pn)
            Loop While True
        End Sub

        ''' <summary>
        ''' Get the smallest object without removing it.
        ''' </summary>
        ''' <returns>The smallest object</returns>
        Public Function Peek() As T Implements IPriorityQueue(Of T).Peek
            If InnerList.Count > 0 Then
                Return InnerList(0)
            End If
            Return Nothing
        End Function

        Public Sub Clear()
            InnerList.Clear()
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                Return InnerList.Count
            End Get
        End Property

        Public Sub RemoveLocation(ByVal item As T)
            Dim index As Integer = -1
            For i As Integer = 0 To InnerList.Count - 1

                If mComparer.Compare(InnerList(i), item) = 0 Then
                    index = i
                End If
            Next

            If index <> -1 Then
                InnerList.RemoveAt(index)
            End If
        End Sub


        Default Public Property Item(ByVal index As Integer) As T
            Get
                Return InnerList(index)
            End Get
            Set(ByVal value As T)
                InnerList(index) = value
                Update(index)
            End Set
        End Property
    End Class

#End Region
End Class

