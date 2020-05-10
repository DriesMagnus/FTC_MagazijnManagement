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
            <div style="width: 220px;" class="mx-auto center">
                <asp:Label class="title-black" runat="server" Text="Leveringen" />
            </div>
            <div style="width: 220px;" class="mx-auto center">
                <asp:DropDownList ID="ddlApparaten" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApparaten_SelectedIndexChanged" />
            </div>
            <br />
            <asp:GridView ID="grvLeveringen" CssClass="col-sm-12 center" Style="width: 25%;" runat="server" EnableViewState="False" AutoGenerateColumns="False" OnPageIndexChanging="grvLeveringen_PageIndexChanging" OnRowDeleting="grvLeveringen_RowDeleting" OnRowEditing="grvLeveringen_RowEditing" OnRowCancelingEdit="grvLeveringen_RowCancelingEdit" OnRowUpdating="grvLeveringen_RowUpdating">
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
            <div style="width: 250px;" class="mx-auto center">
                <asp:Label ID="lblTotaal" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </div>
            <div class="input-group mb-3 center" style="width: 800px;">
                <div class="input-group-prepend">
                    <label class="input-group-text ml-3">Apparaat</label>
                </div>
                <div>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSelectApparaat" />
                </div>
                <div class="input-group-prepend">
                    <label class="input-group-text ml-3">Aantal</label>
                </div>
                <input type="text" runat="server" class="form-control" id="iptAantal" maxlength="10" />
                <div class="input-group-prepend">
                    <label class="input-group-text ml-3">Rij</label>
                </div>
                <input type="text" runat="server" class="form-control" id="iptRij" maxlength="10" />
                <div class="input-group-prepend">
                    <label class="input-group-text ml-3">Vak</label>
                </div>
                <input type="text" runat="server" class="form-control" id="iptVak" maxlength="10"/>
                <div class="input-group-append ml-3">
                    <asp:LinkButton ID="btnAddLevering" CssClass="btn btn-outline-primary rounded-circle" runat="server" OnClick="btnAddLevering_OnClick" Text="<i class='fas fa-plus'> </i>" />
                </div>
            </div>
            <asp:Label runat="server" ID="foutboodschap" EnableViewState="False" Visible="False" CssClass="alert alert-danger center" />
        </div>
    </div>
</asp:Content>
