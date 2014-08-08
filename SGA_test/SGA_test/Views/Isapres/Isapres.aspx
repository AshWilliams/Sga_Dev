<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Isapres
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function guarda_onclick() {

        }

// ]]>
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type ="text/javascript" src="../Scripts/jquery-1.8.3.js" ></script>
<script type ="text/javascript" src="../Scripts/jquery-ui.js"></script>
<script type ="text/javascript" src="../Scripts/jquery.dataTables.js"></script>
    <form id="form1" runat="server">
    <h2>Isapres</h2>
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

Ingrese nombre de Isapre: <input type="text" id="isapre" name="isapre" /> <br />
Ingrese RUT Isapre: <input type="text" id="rutisapre1" name="rutisapre1" /><input type="submit" value ="Grabar" id="guarda" onclick="return guarda_onclick()" />

</div>

</form>

<form id="Form2">
<div id="Div1" title="Modificar Tipo">
<input type="hidden" value="" id="Isa" name="Isa" />
Ingrese nueva isapre: <input type="text" id="actual" name="actual" /> <br />
Ingrese RUT isapre: <input type="text" id="rutisapre" name="rutisapre" /><input type="submit" value ="Actualizar" id="actualiza" />

</div>

</form>

<div id="dialog-confirm" title="">
  <p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>Esta Isapre será eliminada permanentement. Desea Eliminar?</p>
</div>

<script type="text/javascript" src="../Scripts/scriptIsapre.js"></script>
</asp:Content>
