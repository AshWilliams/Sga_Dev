﻿<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Página principal
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData("Message") %></h2>
    <p>
        Para obtener más información sobre ASP.NET MVC, visite el sitio web de <a href="http://asp.net/mvc" title="ASP.NET MVC">http://asp.net/mvc</a>.
    </p>
</asp:Content>
