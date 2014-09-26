<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipWeb.Models.Result>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Model.title %></h2>
    <p><%= Model.result %></p>    
</asp:Content>

<asp:Content ID="indexBotonera" ContentPlaceHolderID="Botonera" runat="server">
    <%= Html.ActionLink("Ir al Inicio", "Index") %>    
</asp:Content>