Public Class DxfArc
    Inherits DxfShape
    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal r As Double, ByVal a As Double, ByVal b As Double)
        Dim f As String = <a>0
ARC
100
AcDbCircle
10
{0}
20
{1}
30
0
40
{2}
100
AcDbArc
50
{3}
51
{4}</a>.Value
        Me.mText = String.Format(f, x, y, r, a, b)
    End Sub
End Class
