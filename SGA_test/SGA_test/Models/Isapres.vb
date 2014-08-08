Public Class Isapres
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

#Region "RutIsa"
    Private objRutIsa As String
    Public Property RutIsa() As String
        Get
            Return objRutIsa
        End Get
        Set(ByVal value As String)
            objRutIsa = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal id As String, ByVal Nombre As String, ByVal RutIsa As String)
        objID = id
        objNombre = Nombre
        objRutIsa = RutIsa
    End Sub
End Class
