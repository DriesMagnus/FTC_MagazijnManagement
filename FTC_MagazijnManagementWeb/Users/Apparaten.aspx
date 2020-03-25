<%@ Page Title="" Language="C#" MasterPageFile="~/MagazijnManagement.Master" AutoEventWireup="true" CodeBehind="Apparaten.aspx.cs" Inherits="FTC_MagazijnManagementWeb.Users.Apparaten" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Apparaten - Magazijn Management</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="nav" runat="server">
    <ul class="navbar-nav ml-auto my-2 my-lg-0">
        <li class="nav-item pdt"><a class="nav-link nav-active" href="Apparaten.aspx">Apparaten</a></li>
        <li class="nav-item pdt"><a class="nav-link" href="Leveringen.aspx">Leveringen</a></li>
        <li class="nav-item"><asp:Button class="btn btn-primary btn-sm" href="#" runat="server" Text="Log uit"></asp:Button></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body1" runat="server">
    <img src="/assets/img/bg-masthead.jpg"/>
</asp:Content>
