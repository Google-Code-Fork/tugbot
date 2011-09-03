Public Class AdrClient
    'Basic
    Public DatPointer As Integer
    Public Map As Integer
    Public Connection As Integer
    Public NameSpy1 As Integer
    Public NameSpy2 As Integer
    'Proxy Related
    Public XTea As Integer
    'Level Spy
    Public LevelSpy1 As Integer
    Public LevelSpy2 As Integer
    Public LevelSpy3 As Integer
    Public LevelSpyPtr As Integer
    Public LevelSpyAdd
    'Status Bar
    Public StatusText As Integer
    Public StatusTime As Integer
    'Light
    Public LightNop As Integer
    Public LightAmount As Integer
    'Screen
    Public ScreenRect As Integer
    Public ScreenBar As Integer
    'Framerate
    Public FrameratePoint As Integer
    'Dialogs
    Public DialogBegin As Integer

    Public Starttime As Integer

    Public FollowMode As Integer

    Public DialogLeft As Integer = &H14
    Public DialogTop As Integer = &H18
    Public DialogWidth As Integer = &H1C
    Public DialogHeight As Integer = &H20
    Public DialogCaption As Integer = &H50


    Public FramerateCurrent As Integer = &H60
    Public FramerateLimit As Integer = &H58


    Public ScreenX As Integer = &H14
    Public ScreenY As Integer = &H18
    Public ScreenHeight As Integer = &H20
    Public ScreenWidth As Integer = &H1C
End Class
