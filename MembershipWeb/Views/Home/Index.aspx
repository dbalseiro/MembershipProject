<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipWeb.Models.Menu>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Menu principal</h2>
    
    <div>
        <ul>
            <% foreach (var menu in Model) { %>
                <li><%= Html.ActionLink(menu.text, "Result", new { menu.id })%></li>
            <% } %>
        </ul>
    </div>
</asp:Content>
