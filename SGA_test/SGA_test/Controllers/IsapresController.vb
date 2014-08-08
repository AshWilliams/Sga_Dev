Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Namespace SGA_test
    Public Class IsapresController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Isapres

        Function Isapres() As ActionResult
            Return View()
        End Function

        Function GetIsapres() As JsonResult
            'GET: /Isapres/GetIsapres
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            'ds = objConn.getTipoLicencias()
            ds = objConn.getIsapres()
            Dim arrayIsapres As New ArrayList
            If ds.GetType Is GetType(String) Then
                'arrayCiudades = Nothing
                arrayIsapres.ToString()
            Else
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    arrayIsapres.Add(New Isapres(ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(1), ds.Tables(0).Rows(i).Item(2).ToString))
                    'arrayIsapres = ds
                Next
            End If
            'arrayIsapres = ds
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(arrayIsapres, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function insertIsapre() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            Dim descripcion = Request("isapre")
            Dim Rut = Request("RutIsapre")
            If String.IsNullOrEmpty(descripcion) Then
                ds = New Mensajes("error", "Debe ingresar una descripcion")
            Else
                ds = objConn.insertIsapre(descripcion, Rut)
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function deleteIsapres() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")

            Dim Isapre = Request("Isapre")

            ds = objConn.deleteIsapre(Isapre)

            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function updateIsapre() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")

            Dim Isapre = Request("Isapre")
            Dim descripcion = Request("describe")
            Dim RutIsapre = Request("RutIsapre")

            If String.IsNullOrEmpty(descripcion) Or String.IsNullOrEmpty(Isapre) Or String.IsNullOrEmpty(RutIsapre) Then
                ds = New Mensajes("error", "Falta un argumento")
            Else
                ds = objConn.updateIsapre(Isapre, descripcion, RutIsapre)
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

    End Class
End Namespace