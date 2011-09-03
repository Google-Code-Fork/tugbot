Class WaterMarkTextBox
    Inherits TextBox
    Private waterMarkTextEnabled As [Boolean] = False

#Region "Attributes"
    Private _waterMarkColor As Color = Color.Gray
    Public Property WaterMarkColor() As Color
        Get
            Return _waterMarkColor
        End Get
        Set(ByVal value As Color)
            _waterMarkColor = value
            'thanks to Bernhard Elbl
            '                                                              for Invalidate()
            Invalidate()
        End Set
    End Property

    Private _waterMarkText As String = "Water Mark"
    Public Property WaterMarkText() As String
        Get
            Return _waterMarkText
        End Get
        Set(ByVal value As String)
            _waterMarkText = value
            Invalidate()
        End Set
    End Property
#End Region

    'Default constructor
    Public Sub New()
        JoinEvents(True)
    End Sub

    'Override OnCreateControl ... thanks to  "lpgray .. codeproject guy"
    Protected Overloads Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        WaterMark_Toggel(Nothing, Nothing)
    End Sub

    'Override OnPaint
    Protected Overloads Overrides Sub OnPaint(ByVal args As PaintEventArgs)
        ' Use the same font that was defined in base class
        'Create new brush with gray color or 
        Dim drawBrush As New SolidBrush(WaterMarkColor)
        Dim sf As New StringFormat
        'use Water mark color
        'Draw Text or WaterMark

        Select Case Me.TextAlign
            Case HorizontalAlignment.Center
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
            Case HorizontalAlignment.Left
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Near
            Case HorizontalAlignment.Right
                sf.Alignment = StringAlignment.Far
                sf.LineAlignment = StringAlignment.Far
        End Select

        args.Graphics.DrawString((If(waterMarkTextEnabled, WaterMarkText, Text)), Font, drawBrush, New RectangleF(Me.DisplayRectangle.X, Me.DisplayRectangle.Y, Me.DisplayRectangle.Width, Me.DisplayRectangle.Height), sf)
        MyBase.OnPaint(args)
    End Sub

    Private Sub JoinEvents(ByVal join As [Boolean])
        If join Then
            AddHandler Me.TextChanged, AddressOf Me.WaterMark_Toggel
            AddHandler Me.LostFocus, AddressOf Me.WaterMark_Toggel
            'No one of the above events will start immeddiatlly 
            'TextBox control still in constructing, so,
            'Font object (for example) couldn't be catched from within
            'WaterMark_Toggle
            'So, call WaterMark_Toggel through OnCreateControl after TextBox
            'is totally created
            'No doupt, it will be only one time call
        End If
    End Sub

    Private Sub WaterMark_Toggel(ByVal sender As Object, ByVal args As EventArgs)
        If Me.Text.Length <= 0 Then
            EnableWaterMark()
        Else
            DisbaleWaterMark()
        End If
    End Sub

    Private Sub EnableWaterMark()
        'Save current font until returning the UserPaint style to false (NOTE:
        'It is a try and error advice)
        'Enable OnPaint event handler
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.waterMarkTextEnabled = True
        'Triger OnPaint immediatly
        Refresh()
    End Sub

    Private Sub DisbaleWaterMark()
        'Disbale OnPaint event handler
        Me.waterMarkTextEnabled = False
        Me.SetStyle(ControlStyles.UserPaint, False)
        'Return back oldFont if existed
    End Sub

End Class
