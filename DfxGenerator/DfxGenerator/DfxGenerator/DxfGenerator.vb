Imports System.IO
Imports System.Text
''' <summary>
''' Dxf生成器，原理是拼接手写文本中的固定部分，和各种形状根据参数组合的变化部分
''' </summary>
''' <remarks></remarks>
Public Class DxfGenerator
    Public LstShapes As List(Of DxfShape)
    Private mDxfFixedPartString As String

    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <param name="CADDxfHeader">CAD dxf文件固定部分的内容，到时用cad随便做一个最简单的图，另存为dxf</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal CADDxfHeader As String)
        'Me.mDxfFixedPartString = File.ReadAllText(dxfFixedPartFileName)
        Me.mDxfFixedPartString = CADDxfHeader
        Me.LstShapes = New List(Of DxfShape)
    End Sub

    ''' <summary>
    ''' 保存为dxf
    ''' </summary>
    ''' <param name="dxfFileName">保存的文件名</param>
    ''' <remarks>写法死记硬背，看上去有点怪异</remarks>
    Public Sub SaveDxf(ByVal dxfFileName As String)
        Dim shapesText = Me.LstShapes.Select(Function(x)
                                                 Return x.Text
                                             End Function
                                            ).ToArray
        Dim all As String = String.Format(Me.mDxfFixedPartString,
                                          String.Join(Environment.NewLine, shapesText))
        File.WriteAllText(dxfFileName, all, Encoding.ASCII)
    End Sub
End Class
