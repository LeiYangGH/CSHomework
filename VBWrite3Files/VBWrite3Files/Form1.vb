Imports System.IO
Public Class Form1
    Private Sub WriteFile(ByVal Dir As String, ByVal FileName As String)
        Dim FullName As String = Path.Combine(Dir, FileName & ".txt")
        Try
            File.WriteAllText(FullName, FileName & "123" & FileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dlg As New FolderBrowserDialog
        If dlg.ShowDialog = DialogResult.OK Then
            Dim Dir As String = dlg.SelectedPath
            'MsgBox(Dir)
            If Not Directory.Exists(Dir) Then
                Directory.CreateDirectory(Dir)
            End If
            WriteFile(Dir, Me.TextBox1.Text.Trim)
            WriteFile(Dir, Me.TextBox2.Text.Trim)
            WriteFile(Dir, Me.TextBox3.Text.Trim)
            MsgBox("ok")
        End If
    End Sub
End Class
