''' <summary>
''' 形状的基类，如果有更多的通用属性可以放这里，比如颜色
''' </summary>
''' <remarks>写法死记硬背</remarks>
Public MustInherit Class DxfShape
    Protected mText As String

    Public ReadOnly Property Text() As String
        Get
            Return Me.mText
        End Get
    End Property
End Class
