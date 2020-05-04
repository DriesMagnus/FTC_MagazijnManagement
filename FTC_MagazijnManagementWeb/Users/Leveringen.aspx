<%@ Page Title="" Language="C#" MasterPageFile="~/MagazijnManagement.Master" AutoEventWireup="true" CodeBehind="Leveringen.aspx.cs" Inherits="FTC_MagazijnManagementWeb.Users.Leveringen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Leveringen - Magazijn Management</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="nav" runat="server">
    <a class="navbar-brand navbar-alt" href="../Default.aspx">Magazijn Management</a>
    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav navbar-alt ml-auto my-2 my-lg-0">
            <li class="nav-item pdt"><a class="nav-link navbar-alt" href="Apparaten.aspx">Apparaten</a></li>
            <li class="nav-item pdt"><a class="nav-link nav-active" href="Leveringen.aspx">Leveringen</a></li>
            <li class="nav-item">
                <asp:LoginStatus class="btn btn-primary btn-sm" runat="server" Text="Log uit" ID="LoginStatus1" OnLoggingOut="LoginStatus1_LoggingOut"></asp:LoginStatus>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body1" runat="server">
    <header>
        <br />
        <br />
        <br />
    </header>
    <div class="bg-gray">
        <div class="table table-borderless table-hover table-responsive table-striped">
            <br />
            <div style="width: 220px;" class="mx-auto">
                <asp:Label class="title-black" runat="server" Text="Leveringen" />
            </div>
            <div style="width: 220px;" class="mx-auto">
                <asp:DropDownList ID="ddlApparaten" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApparaten_SelectedIndexChanged" />
            </div>
            <br />
            <asp:GridView ID="grvLeveringen" CssClass="col-sm-12" Style="margin: auto; width: 25%;" runat="server" EnableViewState="False" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grvLeveringen_PageIndexChanging" PageSize="4" OnRowDeleting="grvLeveringen_RowDeleting" OnRowEditing="grvLeveringen_RowEditing" OnRowCancelingEdit="grvLeveringen_RowCancelingEdit" OnRowUpdating="grvLeveringen_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="Aantal" HeaderText="Aantal">
                        <HeaderStyle CssClass="center" />
                        <ItemStyle Width="500px" HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Locatie" HeaderText="Locatie">
                        <HeaderStyle CssClass="center" />
                        <ItemStyle Width="25%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True">
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                    </asp:CommandField>
                </Columns>
                <EmptyDataTemplate>
                    Er zijn geen leveringen aanwezig.
                </EmptyDataTemplate>
                <PagerSettings Mode="NextPreviousFirstLast" />
            </asp:GridView>
            <br />
            <div style="width: 250px;" class="mx-auto">
                <asp:Label ID="lblTotaal" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
