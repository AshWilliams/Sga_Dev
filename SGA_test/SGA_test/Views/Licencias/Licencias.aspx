<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

	Licencias
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type ="text/javascript" src="../Scripts/jquery-1.8.3.js" ></script>
<script type ="text/javascript" src="../Scripts/jquery-ui.js"></script>
<script type ="text/javascript" src="../Scripts/jquery.dataTables.js"></script>
    <form id="form1" runat="server">

    <h2>Licencias</h2>
    <p>
        <input type="button" name="nuevo" ID="nuevo"  value="Nuevo" />
    </p>
    </form>

<div style="width:800px;">   
<table id="Tabla" width="100%">
    
</table>
</div> 
<form id="myForm">
<div id="dialog" title="Nuevo Tipo">

Ingrese descripcion: <input type="text" id="describe" name="describe" /> <input type="submit" value ="Grabar" id="guarda" />

</div>

</form>

<form id="Form2">
<div id="Div1" title="Modificar Tipo">
<input type="hidden" value="" id="lic" name="lic" />
Ingrese nueva descripcion: <input type="text" id="actual" name="actual" /> <input type="submit" value ="Actualizar" id="actualiza" />

</div>

</form>

<div id="dialog-confirm" title="">
  <p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>Esta Licencia será eliminada permanentement. Desea Eliminar?</p>
</div>

<script type="text/javascript" src="../Scripts/scriptLic.js"></script>
    
</asp:Content>
