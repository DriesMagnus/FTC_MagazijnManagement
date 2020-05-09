<%@ Page Title="" Language="C#" MasterPageFile="~/MagazijnManagement.Master" AutoEventWireup="true" CodeBehind="Apparaten.aspx.cs" Inherits="FTC_MagazijnManagementWeb.Users.Apparaten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Apparaten - Magazijn Management</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="nav" runat="server">
    <a class="navbar-brand navbar-alt" href="../Default.aspx">Magazijn Management</a>
    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav navbar-alt ml-auto my-2 my-lg-0">
            <li class="nav-item pdt"><a class="nav-link nav-active" href="Apparaten.aspx">Apparaten</a></li>
            <li class="nav-item pdt"><a class="nav-link navbar-alt" href="Leveringen.aspx">Leveringen</a></li>
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
                <asp:Label class="title-black" runat="server" Text="Apparaten" />
            </div>
            <br />
            <asp:GridView ID="grvLeveringen" DataKeyNames="Id" CssClass="col-sm-12 center" Style="width: 25%;" runat="server" EnableViewState="False" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grvLeveringen_PageIndexChanging" PageSize="4" OnSelectedIndexChanged="grvLeveringen_SelectedIndexChanged" OnRowDeleting="grvLeveringen_RowDeleting" OnRowEditing="grvLeveringen_RowEditing" OnRowCancelingEdit="grvLeveringen_RowCancelingEdit" OnRowUpdating="grvLeveringen_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Naam" HeaderText="Naam">
                        <HeaderStyle CssClass="center" />
                        <ItemStyle Width="500px" HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Type" HeaderText="Type">
                        <HeaderStyle CssClass="center" />
                        <ItemStyle Width="25%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LeveringAmount" HeaderText="Aantal leveringen" ReadOnly="True">
                        <HeaderStyle CssClass="center" />
                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True">
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                    </asp:CommandField>
                </Columns>
                <EmptyDataTemplate>
                    Er zijn geen apparaten aanwezig.
                </EmptyDataTemplate>
                <PagerSettings Mode="NextPreviousFirstLast" />
            </asp:GridView>
            <br />
            <div style="width: 250px;" class="mx-auto center">
                <asp:Label ID="lblTotaal" runat="server" Text="" />
                <br />
                <br />
            </div>
            <div class="input-group mb-3 center" style="width: 700px;">
                <div class="input-group-prepend">
                    <label class="input-group-text">Naam</label>
                </div>
                <input type="text" runat="server" class="form-control" id="iptNaam" />
                <div class="input-group-prepend">
                    <label class="input-group-text ml-3">Type</label>
                </div>
                <input type="text" runat="server" class="form-control" id="iptType" />
                <div class="input-group-append ml-3">
                    <asp:LinkButton ID="btnAddApparaat" CssClass="btn btn-outline-primary rounded-circle" runat="server" Text="<i class='fas fa-plus'> </i>" OnClick="btnAddApparaat_Click"></asp:LinkButton>
                </div>
            </div>
            <asp:Label runat="server" ID="foutboodschap" EnableViewState="False" Visible="False" CssClass="alert alert-danger center" />
        </div>
    </div>
</asp:Content>
