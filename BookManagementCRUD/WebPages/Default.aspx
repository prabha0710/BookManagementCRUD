<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookManagementCRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="..\Asset\CSS\Main.css" type="text/css" />
    <div class="row Container">
        <h1 class="heading">Book Management System</h1>
        <div class="nav-link">
            <a class="nav-link1" runat="server" href="~/WebPages/FirstPage.aspx">ADD BOOK</a>
            <a class="nav-link1" runat="server" href="~/WebPages/GridViewPage.aspx">VIEW BOOK</a>
        </div>
    </div>
</asp:Content>