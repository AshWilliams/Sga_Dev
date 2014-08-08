Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Namespace SGA

    Public Class LicenciasController
        Inherits System.Web.Mvc.Controller
        ' GET: /Licencias
        Function Licencias() As ActionResult
            Return View()
        End Function


        Function GetLicencias() As JsonResult
            'GET: /Licencias/GetLicencias
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            ds = objConn.getTipoLicencias()
            Dim arrayCiudades As New ArrayList
            If ds.GetType Is GetType(String) Then
                'arrayCiudades = Nothing
                arrayCiudades.ToString()
            Else
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    arrayCiudades.Add(New Licencia(ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(1), ds.Tables(0).Rows(i).Item(2)))
                Next
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(arrayCiudades, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json

        End Function

        Function insertLicencia() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            Dim descripcion = Request("describe")
            If String.IsNullOrEmpty(descripcion) Then
                ds = New Mensajes("error", "Debe ingresar una descripcion")
            Else
                ds = objConn.insertLicencia(descripcion)
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function deleteLicencia() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")

            Dim licencia = Request("licencia")

            ds = objConn.deleteLicencia(licencia)

            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function updateLicencia() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")

            Dim licencia = Request("licencia")
            Dim descripcion = Request("describe")

            If String.IsNullOrEmpty(descripcion) Or String.IsNullOrEmpty(licencia) Then
                ds = New Mensajes("error", "Falta un argumento")
            Else
                ds = objConn.updateLicencia(licencia, descripcion)
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

    End Class
End Namespace