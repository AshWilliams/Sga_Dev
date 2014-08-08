<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type ="text/javascript" src="../Scripts/jquery-1.8.3.js" ></script>
<script type ="text/javascript" src="../Scripts/jquery-ui.js" ></script>
<script type ="text/javascript" src="../Scripts/jquery.dataTables.js" ></script>
    <h2>Form</h2>
<form id="myForm">
<div id="dialog" title="Nuevo Tipo">

Ingrese RUT: <input type="text" id="Rut" name="Rut" /> <input type="submit" value ="Buscar" id="buscar" />

</div>

</form>
<form id="Form2">
<div id="Div1" title="Formulario Licencia">



<div id="col1">
  <div class="campo">RUT: <br />
  <input type="text" id="resp_rut" name="resp_rut" maxlength="12" size="12" /> 
    - 
    <input type="text" id="dv" name="dv" maxlength="12" size="12"/>
  </div>
  <div class="campo">Inicio contrato: <br />
    <input type="text" id="inicio_contrato" name="inicio_contrato" maxlength="12" size="15" />
  </div>
  <div class="campo">Mes: <input type="text" id="mes" name="mes" maxlength="10" size="15" /> </div> 
  <div class="campo">Fecha recepción: <input type="text" id="fc_recepcion" name="fc_recepcion" maxlength="10" size="15" /></div>
  <div class="campo">Folio licencia: <input type="text" id="fl_licencia" name="fl_licencia" maxlength="10" size="15" /></div>
  <div class="campo"><input id="Checkbox1" type="checkbox" />Continuación<br />
<select id="continuacion" name="D1">
  <option>Seleccion continuacion</option>
        <option>13154543</option>
        <option>150065</option>
  </select></div>
  <div class="campo">Fecha hasta: <input type="text" id="fc_hasta" name="fc_hasta" maxlength="10" size="15" /></div>
  <div class="campo">Tipo licencia: 
<select id="tp_licencia" name="D1"></select></div>
  <div class="campo">Lugar reposo:
<select id="lg_reposo" name="D1"></select></div>
</div>




<div id="col2">
  <div class="campo">Nombre Completo:
    <br />
    <input type="text" id="nombres" name="nombres" maxlength="150" size="150" />
  </div>
  <div class="campo">Isapre: <br />
 <input type="text" id="isapre" name="isapre" maxlength="10" size="15" /></div>
  <div class="campo">Año: <input type="text" id="anho" name="anho" maxlength="10" size="15" /> </div>
  <div class="campo">Hora recepción: <input type="text" id="hr_recepcion" name="hr_recepcion" maxlength="10" size="15" /></div>
  <div class="campo">Fecha emisión: <input type="text" id="emi_licencia" name="emi_licencia" maxlength="10" size="15" /> </div>
  <div class="campo">Fecha desde: <input type="text" id="fc_desde" name="fc_desde" maxlength="10" size="15" /></div>
  <div class="campo">N° días: <input type="text" id="nr_dias" name="nr_dias" maxlength="10" size="15" /></div>
  <div class="campo">Concepción (MM/AAAA): <br />
    <input type="text" id="mm_concepcion" name="mm_concepcion" maxlength="2"/> 
    <input type="text" id="aaaa_concepcion" name="aaaa_concepcion" maxlength="4"/></div>
  <div class="campo">Dirección: <input type="text" id="direccion_rep" name="direccion_rep" maxlength="10" size="15" /></div>
  
</div>
<div id="next"><input type="submit" value ="Cancelar" id="cancelar" /><input type="submit" value ="Guardar" id="guardar" />  </div>

<br />
<br /><br />
<br />
  <br /><br />

  
 <br />
    <br />
&nbsp;
       <br />


     <br /><br />


</div>

</form>


<script type="text/javascript">
    var limpia;

    $(document).ready(function () {
        limpia = function (texto) {
            var limpio = $.trim(texto.val());
            texto.val(limpio);
            return texto.val().length;
        }


        $.ajax({
            type: "POST",
            url: "FrmLicencia/obtenerLugares",
            data: {},
            success: function (respuesta) {
                $('#lg_reposo').append("<option>Seleccione lugar de reposo</option>");
                $.each(respuesta, function (i, item) {
                    $('#lg_reposo').append("<option value='" + item.ID + "'>"+item.Nombre+"</option>");
                });
            }
        });

        $.ajax({
            type: "POST",
            url: "FrmLicencia/GetLicencias",
            data: {},
            success: function (respuesta) {
                $('#tp_licencia').append("<option>Seleccione Tipo Licencia</option>");
                $.each(respuesta, function (i, item) {
                    $('#tp_licencia').append("<option value='" + item.ID + "'>" + item.Nombre + "</option>");
                });
            }
        });


        $("#buscar").click(function (event) {
            event.preventDefault();
            //alert("test");
            var rutBusca = $("#Rut");
            var flag = limpia(rutBusca);
            console.log(flag);
            if (flag > 0) {

                $.ajax({
                    type: "POST",
                    url: "FrmLicencia/getFormLicencia",
                    data: { ruta: rutBusca.val() },
                    success: function (respuesta) {
                        var forma = respuesta[0];
                        $("#isapre").val(forma.NmIsapre);
                        $("#resp_rut").val(forma.Rut);
                        $("#dv").val(forma.DV);
                        $("#nombres").val(forma.Nombre);
                        // $("#inicio_contrato").val(forma.FcIniContrato);
                    }
                });

                //alert('hola');

            }
            else {

                alert("Ingrese rut");
                rutBusca.focus();
            }

        });
    });

    $("#guardar").click(function (event) {
        event.preventDefault();
        var resp_rut = $("#resp_rut").val();
        var fl_licencia = $("#fl_licencia").val();
        var tp_licencia = $("#tp_licencia").val();
        var lg_reposo = $("#lg_reposo").val();
        alert("Hola 2");
        if (fl_licencia == "") {
            alert("Debe ingresar un valor");
        }
        else {
            //$("#dialog").dialog('close');
            //alert("Hola 3");
            $.ajax({
                type: "POST",
                url: "FrmLicencia/insertFrmLicencia",
                data: { resp_rut: resp_rut, fl_licencia: fl_licencia, lg_reposo: lg_reposo, tp_licencia: tp_licencia},
                success: function (respuesta) {
                    //table = $("#Tabla").dataTable().fnDraw();
                    //table.fnClearTable();
                    //showTable();
                    //alert(respuesta);
                    //alert("Hola");
                }
            });
        }
    });

</script>
</asp:Content>
