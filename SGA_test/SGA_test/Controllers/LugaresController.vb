Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Web.Script.Serialization
Namespace SGA
    Public Class LugaresController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Lugares

        Function Lugares() As ActionResult
            Return View()
        End Function

        Function GetLugares() As JsonResult
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

        Function deleteLugar() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")

            Dim codigo = Request("codigo")

            ds = objConn.deleteLugar(codigo)

            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function insertLugar() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")
            Dim descripcion = Request("describe")
            If String.IsNullOrEmpty(descripcion) Then
                ds = New Mensajes("error", "Debe ingresar una descripcion")
            Else
                ds = objConn.insertLugar(descripcion)
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function updateLugar() As JsonResult
            Dim objConn As Object 'Creo Objeto por default de VB
            Dim ds
            objConn = Server.CreateObject("sgaLicencia.sgaLicencia")

            Dim codigo = Request("codigo")
            Dim descripcion = Request("describe")

            If String.IsNullOrEmpty(descripcion) Or String.IsNullOrEmpty(codigo) Then
                ds = New Mensajes("error", "Falta un argumento")
            Else
                ds = objConn.updateLugar(codigo, descripcion)
            End If
            'Importante incluir JsonRequestBehavior.AllowGet, sino tira error 500....para debuguear errores tipo 500, F12 en Chrome y fijarse en la response
            Return Json(ds, JsonRequestBehavior.AllowGet) 'Retorno respuesta de tipo Json
        End Function

        Function getReporte()
            Dim document As New Document()
            'Get the PDF Writer with the document and the path to save the PDF
            Dim test = Request("test")
            Dim jason As String = Request("jsonT")

            Dim serializer As New JavaScriptSerializer()
            Dim deJson = serializer.Deserialize(Of IEnumerable(Of jsLugar))(jason)
            PdfWriter.GetInstance(document, New FileStream("ReporteUVM.pdf", FileMode.Create))
            'Open the document
            document.Open()
            'Add paragraph with helloworld text

            Dim oTabla As New Table(2)
            Dim cell1 As New Cell("Tipo")
            Dim cell2 As New Cell("Nombre")
            cell1.GrayFill = 0.5F
            cell2.GrayFill = 0.5F
            oTabla.AddCell(cell1)
            oTabla.AddCell(cell2)

            For Each Json As jsLugar In deJson.ToList
                oTabla.AddCell(Json.Id)
                oTabla.AddCell(Json.Nombre)
            Next

            oTabla.Cellpadding = 2
            '& deJson.Count.ToString & deJson(0).Nombre
            document.Add(New Paragraph("Saludos ReporteUVM"))
            document.Add(oTabla)
            'close the document
            document.Close()
            'open the document from code
            Return System.Diagnostics.Process.Start("ReporteUVM.pdf")
        End Function

    End Class
End Namespace