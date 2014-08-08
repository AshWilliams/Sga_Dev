Public Class Mensajes
    Private objStatus As String
    Public Property Status() As String
        Get
            Return objStatus
        End Get
        Set(ByVal value As String)
            objStatus = value
        End Set
    End Property

    Private objMensaje As String
    Public Property Mensaje() As String
        Get
            Return objMensaje
        End Get
        Set(ByVal value As String)
            objMensaje = value
        End Set
    End Property

    Public Sub New(ByVal status As String, ByVal mensaje As String)
        objStatus = status
        objMensaje = mensaje
    End Sub
End Class
