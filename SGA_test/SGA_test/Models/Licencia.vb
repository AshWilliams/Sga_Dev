Public Class Licencia
#Region "ID"
    Private objID As String
    Public Property ID() As String
        Get
            Return objID
        End Get
        Set(ByVal value As String)
            objID = value
        End Set
    End Property

#End Region


#Region "Nombre"
    Private objNombre As String
    Public Property Nombre() As String
        Get
            Return objNombre
        End Get
        Set(ByVal value As String)
            objNombre = value
        End Set
    End Property
#End Region

#Region "Tipo"
    Private objTipo As String
    Public Property Tipo() As String
        Get
            Return objTipo
        End Get
        Set(ByVal value As String)
            objTipo = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal id As String, ByVal Nombre As String, ByVal Tipo As String)
        objID = id
        objNombre = Nombre
        objTipo = Tipo
    End Sub
End Class
