Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Namespace SGA_test
    Public Class FrmLicenciaController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /FrmLicencia

        Function Index() As ActionResult
            Return View()
        End Function

        Function getFormLicencia() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim arrayFrmLicencia As New ArrayList
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            Dim Rut = Request("ruta")
            If String.IsNullOrEmpty(Rut) Then
                ds = New Mensajes("error", "Debe ingresar el numero de Rut")
            Else
                ds = objConn.getFrmLicencia(Rut)
            End If

            'Añadir elementos del ds a un arreglo de objetos tipo formlicencia

            For i = 0 To ds.Tables(0).Rows.Count - 1
                arrayFrmLicencia.Add(New FormLicencia(ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(1), ds.Tables(0).Rows(i).Item(2).ToString, ds.Tables(0).Rows(i).Item(3), ds.Tables(0).Rows(i).Item(4).ToString, ds.Tables(0).Rows(i).Item(5), ds.Tables(0).Rows(i).Item(6)))
            Next

            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            'retornas el arreglo no ds
            Return Json(arrayFrmLicencia, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function insertFrmLicencia() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            Dim resp_rut = Request("resp_rut")
            Dim fl_licencia = Request("fl_licencia")
            Dim lg_reposo = Request("lg_reposo")
            Dim tp_licencia = Request("tp_licencia")
            If String.IsNullOrEmpty(resp_rut) Then
                ds = New Mensajes("error", "Debe ingresar una descripcion")
            Else
                ds = objConn.insertFrmLicencia(resp_rut, fl_licencia, lg_reposo, tp_licencia)
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function
        Function obtenerLugares() As JsonResult
            'GET: /Licencias/GetLicencias
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            ds = objConn.getLugares()
            Dim arrayCiudades As New ArrayList
            If ds.GetType Is GetType(String) Then
                'arrayCiudades.Add(ds.ToString)
                arrayCiudades = Nothing
            Else
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    arrayCiudades.Add(New Lugares(ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(1)))
                Next
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(arrayCiudades, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json

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
    End Class
End Namespace