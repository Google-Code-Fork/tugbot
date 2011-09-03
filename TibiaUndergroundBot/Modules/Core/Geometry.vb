Public Class geoPoint
    Implements ICloneable

    Private m_x As Double 'Keeps track of the X coordinate of the point
    Private m_y As Double 'Keeps track of the Y coordinate of the point

    'Creates a point at 0,0
    Public Sub New()
        m_x = 0.0
        m_y = 0.0
    End Sub

    'Creates a point at xx,yy
    Public Sub New(ByVal xx As Double, ByVal yy As Double)
        m_x = xx
        m_y = yy
    End Sub

    'Clones the point
    Public Function Clone() As Object Implements ICloneable.Clone
        Return New geoPoint(m_x, m_y)
    End Function

    'Returns the CrossProduct of P1 and P2 with the current Point being the Vertex
    Public Function CrossProduct(ByRef P1 As geoPoint, ByRef P2 As geoPoint) As Double
        'Ax * By - Bx * Ay
        Return (P1.m_x - m_x) * (P2.m_y - m_y) - (P2.m_x - m_x) * (P1.m_y - m_y)
    End Function

    'Returns the DotProduct of P1 and P2 with the current Point being the Vertex
    Public Function DotProduct(ByRef P1 As geoPoint, ByRef P2 As geoPoint) As Double
        'Ax * Bx + Ay * Cy
        Return (P1.m_x - m_x) * (P2.m_x - m_x) + (P1.m_y - m_y) * (P2.m_y - m_y)
    End Function

    'Rotates point around Axis
    Public Function Rotate(ByVal Degrees As Double, Optional ByRef Axis As geoPoint = Nothing) As geoPoint
        If Axis Is Nothing Then
            'Rotate around (0, 0)
            Return New geoPoint( _
                m_x * Math.Cos(Degrees / 180.0 * Math.PI) - m_y * Math.Sin(Degrees / 180.0 * Math.PI), _
                m_x * Math.Sin(Degrees / 180.0 * Math.PI) + Math.Cos(Degrees / 180.0 * Math.PI) * m_y)
        Else
            'Rotate around Axis
            Return New geoPoint( _
                (m_x - Axis.m_x) * Math.Cos(Degrees / 180.0 * Math.PI) - (m_y - Axis.m_y) * Math.Sin(Degrees / 180.0 * Math.PI) + Axis.m_x, _
                (m_x - Axis.m_x) * Math.Sin(Degrees / 180.0 * Math.PI) + Math.Cos(Degrees / 180.0 * Math.PI) * (m_y - Axis.m_y) + Axis.m_y)
        End If
    End Function

    'Accessor to the X property
    Public Property X() As Double
        Get
            X = m_x
        End Get
        Set(ByVal Value As Double)
            m_x = Value
        End Set
    End Property

    'Accessor to the Y property
    Public Property Y() As Double
        Get
            Y = m_y
        End Get
        Set(ByVal Value As Double)
            m_y = Value
        End Set
    End Property
End Class

Public Class geoLine
    Implements ICloneable

    'End points of the line
    Private m_P1 As geoPoint
    Private m_P2 As geoPoint

    'Standard Form - AX + BY = C
    Private m_A As Double
    Private m_B As Double
    Private m_C As Double

    'Sets up the standard form variables from the two points P1 and P2
    Private Sub SetUpABC()
        m_A = m_P2.Y - m_P1.Y
        m_B = m_P1.X - m_P2.X
        m_C = m_A * m_P1.X + m_B * m_P1.Y
    End Sub

    'Creates an invalid line
    Public Sub New()
        m_P1 = New geoPoint()
        m_P2 = New geoPoint()
        SetUpABC()
    End Sub

    'Creates a line going through the two points
    Public Sub New(ByRef P1 As geoPoint, ByRef P2 As geoPoint)
        m_P1 = P1.Clone
        m_P2 = P2.Clone
        SetUpABC()
    End Sub

    'Returns the point that the lines cross and stores into LinesCross if the lines do in fact cross
    Public Function Intersect(ByRef Ln As geoLine, ByRef LinesCross As Boolean) As geoPoint
        Try
            'Calculate Denominator
            Dim Det As Double = Ln.m_A * m_B - Ln.m_B * m_A
            Dim Res As geoPoint = New geoPoint((Ln.m_C * m_B - Ln.m_B * m_C) / Det, (Ln.m_A * m_C - m_A * Ln.m_C) / Det)
            LinesCross = True
            Return Res
        Catch
            'Lines are parallel (or do not intersect within the range of a double)
            LinesCross = False
            Return New geoPoint()
        End Try
    End Function

    'Returns if the point is on the line
    Public Function OnLine(ByRef Pt As geoPoint) As Boolean
        'A * PtX + B * PtY = C
        Return Math.Abs(m_A * Pt.X + m_B * Pt.Y - m_C) < 0.000000001
    End Function

    'Returns if the point is on the line segment
    Public Function OnSegment(ByRef Pt As geoPoint) As Boolean
        If Not OnLine(Pt) Then Return False
        'See if Pt is within the rectangle created by m_P1 and m_P2 inclusive
        Return Math.Min(m_P1.X, m_P2.X) <= Pt.X And Math.Max(m_P1.X, m_P2.X) >= Pt.X And Math.Min(m_P1.Y, m_P2.Y) <= Pt.Y And Math.Max(m_P1.Y, m_P2.Y) >= Pt.Y
    End Function

    'Returns if the point is on the line segment excluding the endpoints
    Public Function OnSegmentExclusive(ByRef Pt As geoPoint) As Boolean
        If Not OnSegment(Pt) Then Return False
        'See if Pt is equal to an endpoint
        Return Not ((Pt.X = m_P1.X And Pt.Y = m_P1.Y) Or (Pt.X = m_P2.X And Pt.Y = m_P2.Y))
    End Function

    'Rotates the polygon around Axis by Degrees
    Public Function Rotate(ByVal Degrees As Double, Optional ByRef Axis As geoPoint = Nothing) As geoLine
        Return New geoLine(m_P1.Rotate(Degrees, Axis), _
                        m_P2.Rotate(Degrees, Axis))
    End Function

    'Clones the line
    Public Function Clone() As Object Implements ICloneable.Clone
        Return New geoLine(m_P1, m_P2)
    End Function

    'End point accessors
    Public Property P1() As geoPoint
        Get
            Return m_P1
        End Get
        Set(ByVal Value As geoPoint)
            m_P1 = Value.Clone
            SetUpABC()
        End Set
    End Property

    Public Property P2() As geoPoint
        Get
            Return m_P2
        End Get
        Set(ByVal Value As geoPoint)
            m_P2 = Value.Clone
            SetUpABC()
        End Set
    End Property

    'Standard form variable accessors
    Public ReadOnly Property A() As Double
        Get
            Return m_A
        End Get
    End Property

    Public ReadOnly Property B() As Double
        Get
            Return m_B
        End Get
    End Property

    Public ReadOnly Property C() As Double
        Get
            Return m_C
        End Get
    End Property
End Class

Public Class geoPolygon
    Implements ICloneable

    Private m_Points As ArrayList 'A Collection of geoPoint objects

    'Creates a blank Polygon
    Public Sub New()
        m_Points = New ArrayList()
    End Sub

    'Creates a Polygon from a Collection of points (copies of the points are made)
    Public Sub New(ByVal Points() As geoPoint)
        m_Points = New ArrayList()
        Dim I As Integer
        For I = 0 To Points.GetUpperBound(0)
            m_Points.Add(CType(Points(I), geoPoint).Clone)
        Next
    End Sub

    'Returns if the polygon is simple
    Public Function IsSimple() As Boolean
        Dim I As Integer

        'Check for any side intersections
        'A side intersection means the polygon is complex
        For I = 0 To PointCount() - 3
            Dim Ln1 As geoLine = New geoLine(GetPoint(I), GetPoint(I + 1))

            Dim J As Integer
            For J = I + 2 To PointCount() - 1 - IIf(I = 0, 1, 0) 'For the first side, we don't need to check it against the last side (because they are adjacent)
                Dim Ln2 As geoLine = New geoLine(GetPoint(J), GetPoint((J + 1) Mod PointCount()))

                Dim LinesCross As Boolean
                Dim IntersectPt As geoPoint = Ln1.Intersect(Ln2, LinesCross)

                If LinesCross Then
                    If Ln1.OnSegmentExclusive(IntersectPt) And Ln2.OnSegmentExclusive(IntersectPt) Then
                        Return False
                    End If
                End If
            Next
        Next
        Return True
    End Function

    'Returns if the polygon is convex
    Public Function IsConvex() As Boolean
        'A polygon must be Simple to be convex
        If Not IsSimple() Then Return False

        'A polygon with 2 or less points will be considered to be convex
        If PointCount() <= 2 Then Return True

        Dim Dir As Integer = 0
        Dim I As Integer

        'Make sure every angle goes the same direction (each cross product should have the same sign
        For I = 0 To PointCount() - 1
            Dim Cross As Double = GetPoint((I + 1) Mod PointCount()).CrossProduct(GetPoint(I), GetPoint((I + 2) Mod PointCount()))
            If Cross <> 0.0 Then
                If Cross > 0.0 Then
                    If Dir = -1 Then Return False
                    Dir = 1
                Else
                    If Dir = 1 Then Return False
                    Dir = -1
                End If
            End If
        Next
        Return True
    End Function

    'Finds the area of the polygon (does not work if sides cross)
    Public Function Area() As Double
        If Not IsSimple() Then
            'Cannot calculate the area of a non-simple polygon
            Return 0.0
        End If

        Dim Res As Double = 0.0
        Dim I As Integer
        For I = 1 To PointCount() - 2
            'Take the Cross Product of each triangle
            Res += GetPoint(0).CrossProduct(GetPoint(I), GetPoint(I + 1))
        Next
        Return Math.Abs(Res) / 2.0
    End Function

    'Sorts the polygon's points and removes any points that would make the polygon concave
    'The resulting polygon is always convex
    Public Function ConvexHull(Optional ByVal OnBorder As Boolean = False) As geoPolygon
        'The Convex Hull will be the current points (unless there are three co-linear points and OnBorder = False... we will ignore this case)
        If PointCount() <= 3 Then Return Me.Clone

        Dim Res As New geoPolygon()
        Dim StartIndex As Integer = 0

        'Find the starting index of the hull by finding the leftmost point in the polygon
        Dim I As Long
        For I = 1 To PointCount() - 1
            If GetPoint(I).X < GetPoint(StartIndex).X Then
                'Point is Left Most
                StartIndex = I
            ElseIf GetPoint(I).X = GetPoint(StartIndex).X Then
                'Point is tied for left most, see if it's higher
                If GetPoint(I).Y < GetPoint(StartIndex).Y Then
                    StartIndex = I
                End If
            End If
        Next

        Dim InHull(PointCount() - 1) As Boolean

        'Sort until we get back to StartIndex
        Dim LastIndex As Integer = StartIndex
        Do
            Dim Selected As Integer = -1
            For I = 0 To PointCount() - 1
                If Not InHull(I) And I <> LastIndex Then
                    If Selected = -1 Then
                        'No point hasbeen selected yet, select this one
                        Selected = I
                    Else
                        Dim Cross As Double = GetPoint(I).CrossProduct(GetPoint(LastIndex), GetPoint(Selected))
                        If Cross = 0.0 Then
                            'On the line
                            If OnBorder Then
                                'Since we want the points on the border, take the one closer to LastIndex
                                If GetPoint(LastIndex).DotProduct(GetPoint(I), GetPoint(I)) < _
                                   GetPoint(LastIndex).DotProduct(GetPoint(Selected), GetPoint(Selected)) Then
                                    Selected = I
                                End If
                                'Since we don't want the points on the border, thak the one further from LastIndex
                            ElseIf GetPoint(LastIndex).DotProduct(GetPoint(I), GetPoint(I)) > _
                                    GetPoint(LastIndex).DotProduct(GetPoint(Selected), GetPoint(Selected)) Then
                                Selected = I
                            End If
                        ElseIf Cross < 0.0 Then
                            'GetPoint(I) is more counter-clockwise
                            Selected = I
                        End If
                    End If
                End If
            Next
            'Set LastIndex to the final Selected point
            LastIndex = Selected

            'Update the InHull array to know this point has been added to the hull
            InHull(LastIndex) = True

            'Add the point
            Res.AddPoint(GetPoint(LastIndex))
        Loop While LastIndex <> StartIndex 'Check if we're back to the starting point

        Return Res
    End Function

    'Checks if a point is in the polygon
    Public Function PtInPolygon(ByVal pt As geoPoint, Optional ByVal OnBorder As Boolean = True) As Boolean
        'The polygon has to  have 3 sides for a point to be inside it
        If PointCount() = 0 Then
            Return False
        ElseIf PointCount() = 1 Then
            If OnBorder Then
                Return pt.X = GetPoint(0).X And pt.Y = GetPoint(0).Y
            Else
                Return False
            End If
        ElseIf PointCount() = 2 Then
            If OnBorder Then
                'See if the Point lies on the line-Polygon
                If New geoLine(GetPoint(0), GetPoint(1)).OnSegment(pt) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If

        If IsConvex() Then
            'Check if the point is on the same side of each side of the polygon
            Dim Dir As Integer = 0
            Dim I As Integer
            For I = 0 To PointCount() - 1
                Dim Cross As Double = pt.CrossProduct(GetPoint(I), GetPoint((I + 1) Mod PointCount()))
                If Cross <> 0.0 Then
                    If Cross > 0.0 Then
                        If Dir = -1 Then Return False
                        Dir = 1
                    Else
                        If Dir = 1 Then Return False
                        Dir = -1
                    End If
                ElseIf Not OnBorder Then
                    Return False
                End If
            Next
            Return True
        Else
            Dim I As Integer, J As Integer

            'Check if the point is on any of the segments
            For i = 0 To PointCount() - 1
                If New geoLine(GetPoint(i), GetPoint((i + 1) Mod PointCount())).OnSegment(pt) Then
                    If OnBorder Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Next

            'Look for Segment-Ray intersections
            Dim Crosses As Integer
            For I = 0 To PointCount() - 1
                J = (I + 1) Mod PointCount()

                If Math.Min(GetPoint(J).Y, GetPoint(i).y) <= pt.Y And Math.Max(GetPoint(J).Y, GetPoint(i).y) >= pt.Y Then
                    'AX + BY = C
                    Dim A As Double = GetPoint(J).Y - GetPoint(i).y
                    Dim B As Double = GetPoint(i).x - GetPoint(J).X
                    Dim C As Double = A * GetPoint(i).x + B * GetPoint(i).y

                    If A <> 0.0 Then
                        'Calculate X coordinate where AX + B * Pty = C
                        Dim CrossX As Double = (C - B * pt.Y) / A

                        'Check if it's on the right of our ray
                        If CrossX >= pt.X Then
                            If GetPoint(i).x = CrossX Then
                                'Ignore, but don't count as a cross
                            ElseIf GetPoint(J).X = CrossX Then
                                'Catch crosses where the sides cross the ray at a point
                                Dim K As Integer = I
                                Dim L As Integer
                                For L = 0 To PointCount() - 2
                                    I = (I + 1) Mod PointCount()
                                    J = (J + 1) Mod PointCount()
                                    If GetPoint(J).Y <> pt.Y Then
                                        If GetPoint(K).Y < pt.Y And GetPoint(J).Y > pt.Y Then
                                            Crosses += 1
                                        ElseIf GetPoint(K).Y > pt.Y And GetPoint(J).Y < pt.Y Then
                                            Crosses += 1
                                        End If
                                        Exit For
                                    End If
                                Next
                                'If we wrapped around then we should stop the loop
                                If I < K Then
                                    Exit For
                                End If
                            Else
                                Crosses += 1
                            End If
                        End If
                    End If
                End If
            Next
            Return Crosses Mod 2 = 1
        End If
    End Function

    'Finds the overlap polygon of the current polygon and the polygon passed
    'Both polygons must be convex
    Public Function Overlap(ByRef PolyTest As geoPolygon) As geoPolygon
        'Make sure both polygons are Convex
        If (IsConvex() And PolyTest.IsConvex) = False Then
            Return New geoPolygon()
        End If

        Dim Res As New geoPolygon()

        'Check for points from this polygon inside PolyTest
        Dim I As Integer, J As Integer
        For I = 0 To PointCount() - 1
            If PolyTest.PtInPolygon(GetPoint(I)) Then
                Res.AddPoint(GetPoint(I).Clone)
            End If
        Next

        'Check for points from PolyTest inside this polygon
        For I = 0 To PolyTest.PointCount() - 1
            If PtInPolygon(PolyTest.GetPoint(I)) Then
                Res.AddPoint(PolyTest.GetPoint(I).Clone)
            End If
        Next

        'Check for side intersections
        For I = 0 To PointCount() - 1
            Dim Ln1 As geoLine = New geoLine(GetPoint(I), GetPoint((I + 1) Mod PointCount()))

            For J = 0 To PolyTest.PointCount() - 1
                Dim Ln2 As geoLine = New geoLine(PolyTest.GetPoint(J), PolyTest.GetPoint((J + 1) Mod PolyTest.PointCount))

                Dim LinesCross As Boolean
                Dim Pt As geoPoint = Ln1.Intersect(Ln2, LinesCross)
                If LinesCross Then
                    If Ln1.OnSegment(Pt) And Ln2.OnSegment(Pt) Then
                        Res.AddPoint(Pt.Clone)
                    End If
                End If
            Next
        Next
        Return Res.ConvexHull
    End Function

    'Offsets all the points X values by Distance
    Public Function OffsetX(ByVal Distance As Double) As geoPolygon
        Dim Res As New geoPolygon()
        Dim I As Integer
        For I = 0 To PointCount() - 1
            Res.AddPoint(New geoPoint(GetPoint(I).X + Distance, GetPoint(I).Y))
        Next
        Return Res
    End Function

    'Offsets all the points Y values by Distance
    Public Function OffsetY(ByVal Distance As Double) As geoPolygon
        Dim Res As New geoPolygon()
        Dim I As Integer
        For I = 0 To PointCount() - 1
            Res.AddPoint(New geoPoint(GetPoint(I).X, GetPoint(I).Y + Distance))
        Next
        Return Res
    End Function

    'Rotates the polygon around Axis by Degrees
    Public Function Rotate(ByVal Degrees As Double, Optional ByRef Axis As geoPoint = Nothing) As geoPolygon
        Dim Res As New geoPolygon()
        Dim I As Integer

        'Loop through each point and add the rotated point to the result
        For I = 0 To PointCount() - 1
            Res.AddPoint(GetPoint(I).Rotate(Degrees, Axis))
        Next
        Return Res
    End Function

    'Clones the Polygon
    Public Function Clone() As Object Implements ICloneable.Clone
        Dim Pts(PointCount() - 1) As geoPoint
        Dim I As Integer
        For I = 0 To PointCount() - 1
            Pts(I) = GetPoint(I)
        Next
        Return New geoPolygon(Pts)
    End Function

    'Point Collection Accessor
    Public Sub AddPoint(ByVal Pt As geoPoint)
        m_Points.Add(Pt)
    End Sub

    Public Sub RemovePoint(ByVal Index As Integer)
        m_Points.Remove(Index)
    End Sub

    Public Function GetPoint(ByVal Index As Integer) As geoPoint
        Return m_Points(Index)
    End Function

    Public Function PointCount() As Integer
        Return m_Points.Count()
    End Function
End Class
