<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipWeb.Models.Parameters>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Model.nombre %></h2>    
    
    <form id="frmParametros" method="post" action="">
        <div class="columns-container">
            <div class="two-columns">
                <% int i = 0; %>
                <% foreach(var item in Model) { %>
                    <div class="leftColumn">
                        <div>
                            <label><%= item.text %></label>
                        </div>
                        <div>
                            <%= Html.TextBox("itemValue") %>
                        </div>
                    </div>
                <% } %>
            </div>
        </div>
    </form>
</asp:Content>

<asp:Content ID="indexBotonera" ContentPlaceHolderID="Botonera" runat="server">
    <a href="#" class="submit" data-formid="frmParametros">Aceptar</a>
    <%= Html.ActionLink("Ir al Inicio", "Index") %>
</asp:Content>