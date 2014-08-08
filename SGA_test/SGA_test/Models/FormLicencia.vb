Public Class FormLicencia
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

#Region "Rut"
    Private objRut As String
    Public Property Rut() As String
        Get
            Return objRut
        End Get
        Set(ByVal value As String)
            objRut = value
        End Set
    End Property
#End Region

#Region "DV"
    Private objDV As String
    Public Property DV() As String
        Get
            Return objDV
        End Get
        Set(ByVal value As String)
            objDV = value
        End Set
    End Property
#End Region

#Region "CdIsapre"
    Private objCdIsapre As String
    Public Property CdIsapre() As String
        Get
            Return objCdIsapre
        End Get
        Set(ByVal value As String)
            objCdIsapre = value
        End Set
    End Property
#End Region

#Region "NmIsapre"
    Private objNmIsapre As String
    Public Property NmIsapre() As String
        Get
            Return objNmIsapre
        End Get
        Set(ByVal value As String)
            objNmIsapre = value
        End Set
    End Property
#End Region

#Region "TpConvenio"
    Private objTpConvenio As String
    Public Property TpConvenio() As String
        Get
            Return objTpConvenio
        End Get
        Set(ByVal value As String)
            objTpConvenio = value
        End Set
    End Property
#End Region

#Region "FcIniContrato"
    Public objFcIniContrato As String
    Private Property FcIniContrato() As String
        Get
            Return objFcIniContrato
        End Get
        Set(ByVal value As String)
            objFcIniContrato = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal Nombre As String, ByVal Rut As String, ByVal DV As String, ByVal CdIsapre As String, ByVal NmIsapre As String, ByVal TpConvenio As String, ByVal FcIniContrato As String)
        objNombre = Nombre
        objRut = Rut
        objDV = DV
        objCdIsapre = CdIsapre
        objNmIsapre = NmIsapre
        objTpConvenio = TpConvenio
        objFcIniContrato = FcIniContrato
    End Sub
End Class
