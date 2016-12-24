Imports System.Xml
Imports System.Xml.Linq
''' <summary>
''' dxf线条
''' </summary>
''' <remarks>最关键是里面那个字符串，不能多一个或少一个回车，否则生成的dxf文件打不开</remarks>
Public Class DxfLine
    Inherits DxfShape
    Public Sub New(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
        Dim f As String = <a>0
LINE
100
AcDbLine
10
{0}
20
{1}
30
0
11
{2}
21
{3}
31
0</a>.Value
        Me.mText = String.Format(f, x1, y1, x2, y2)
    End Sub
End Class
