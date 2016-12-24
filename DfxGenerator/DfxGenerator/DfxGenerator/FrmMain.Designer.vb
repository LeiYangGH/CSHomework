<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGen
        '
        Me.btnGen.Location = New System.Drawing.Point(659, 459)
        Me.btnGen.Name = "btnGen"
        Me.btnGen.Size = New System.Drawing.Size(114, 53)
        Me.btnGen.TabIndex = 0
        Me.btnGen.Text = "Generate"
        Me.btnGen.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 557)
        Me.Controls.Add(Me.btnGen)
        Me.Name = "FrmMain"
        Me.Text = "FrmMain"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGen As System.Windows.Forms.Button
End Class
