Public Class DxfText
    Inherits DxfShape
    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal t As String)
        Dim f As String = <a>0
Text
100
AcDbText
 10
{0}
 20
{1}
 30
0
 40
1
1
{2}
100
AcDbText</a>.Value
        Me.mText = String.Format(f, x, y, t)
    End Sub
End Class
