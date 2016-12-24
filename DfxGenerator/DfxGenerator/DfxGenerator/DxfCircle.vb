Public Class DxfCircle
    Inherits DxfShape
    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal r As Double)
        Dim f As String = <a>0
CIRCLE
100
AcDbCircle
10
{0}
20
{1}
40
{2}</a>.Value
        Me.mText = String.Format(f, x, y, r)
    End Sub
End Class
