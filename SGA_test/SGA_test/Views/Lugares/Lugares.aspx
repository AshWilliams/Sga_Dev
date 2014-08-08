<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lugares

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type ="text/javascript" src="../Scripts/jquery-1.8.3.js" ></script>
<script type="text/javascript" src="../Scripts/jquery.validate.min.js"></script>
<script type="text/javascript" src="../Scripts/additional-methods.js"></script>
<script type ="text/javascript" src="../Scripts/jquery-ui.js"></script>
<script type ="text/javascript" src="../Scripts/jquery.dataTables.js"></script>

    <h2>Lugares</h2>
<form id="form1" runat="server">

    <input type="button" name="nuevo" ID="nuevo"  value="Nuevo" />
    <input type="button" name="imprime" ID="imprime"  value="Imprimir" />
 </form>

<form id="myForm">
<div id="dialog" title="Nuevo Lugar">

Ingrese descripcion: <input type="text" id="describe" name="describe" /> <input type="submit" value ="Grabar" id="guarda" />

</div>

</form>

<form id="Form2">
<div id="Div1" title="Modificar Lugar">
<input type="hidden" value="" id="codigo" name="codigo" />
Ingrese nueva descripcion: <input type="text" id="actual" name="actual" /> <input type="submit" value ="Actualizar" id="actualiza" />

</div>

</form>

<div style="width:800px;">   
<table id="Tabla" width="100%">
    
</table>
</div> 
<div id="dialog-confirm" title="">
  <p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>Esta Lugar de reposo será eliminado permanentement. Desea Eliminar?</p>
</div>

<script type="text/javascript" src="../Scripts/scriptLugar.js" ></script>
</asp:Content>
