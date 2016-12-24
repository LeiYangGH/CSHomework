Imports System.Windows.Forms
Imports System.IO
Imports System.Text.RegularExpressions
Public Class FrmMain

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGen.Click

        Dim cadHeader = Me.GetCADDxfHeader

        Dim dxfGen As New DxfGenerator(cadHeader)

        Dim line As New DxfLine(5, 5, 15, 15)
        Dim circle As New DxfCircle(10, 10, 5)
        Dim arc As New DxfArc(8, 12, 5, 45, 135)
        Dim text As New DxfText(10, 10, "Text")

        dxfGen.LstShapes.Add(line)
        dxfGen.LstShapes.Add(circle)
        dxfGen.LstShapes.Add(arc)
        dxfGen.LstShapes.Add(text)

        dxfGen.SaveDxf("generate4cad.dxf")
        
        MessageBox.Show("ok")
    End Sub

    Private Function GetCADDxfHeader() As String
        Dim cadSample = "个42007红.dxf"
        Dim allInput = File.ReadAllText(cadSample)
        allInput = allInput.Replace("{", "").Replace("}", "")
        Dim entity = "ENTITIES"
        Dim indexEntity = allInput.IndexOf(entity)
        Dim header = allInput.Substring(0, indexEntity)
        header += "ENTITIES" & vbCrLf & "{0}" & vbCrLf & "0" & vbCrLf & "ENDSEC" & vbCrLf & "0" & vbCrLf & "EOF"
        File.WriteAllText("header.txt", header)
        Return header
    End Function
End Class