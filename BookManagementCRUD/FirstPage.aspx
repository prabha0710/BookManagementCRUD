<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FirstPage.aspx.cs" Inherits="BookManagementCRUD.AddBooks" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="./Asset/CSS/firstpage.css" type="text/css" />
   

    <main>
       
        <div class="bookdetails">
            <div class="input-group">
                <label class="label" for="txtBookName">Book Name</label><br />
                <asp:TextBox class="textbox" ID="txtBookName" runat="server"></asp:TextBox><br />
            </div>

            <div class="input-group">
                <label class="label" for="txtAuthorName">Author Name</label><br />
                <asp:TextBox class="textbox" ID="txtAuthorName" runat="server"></asp:TextBox><br />
            </div>

            <div class="input-group">
                <label class="label" for="txtBookCount">Book Count</label><br />
                <asp:TextBox class="textbox" ID="txtBookCount" runat="server"></asp:TextBox><br />
            </div>

            <div class="input-group">
                <label class="label" for="txtPublicationYear">Publication Year</label><br />
                <asp:TextBox class="textbox" ID="txtPublicationYear" runat="server"></asp:TextBox><br />
            </div>

            <div class="input-group">
                <label class="label" for="txtISBN">ISBN</label><br />
                <asp:TextBox class="textbox" ID="txtISBN" runat="server"></asp:TextBox><br />
            </div>

            <div class="input-group">
                <label class="label" for="txtLanguage">Language</label><br />
                <asp:TextBox class="textbox" ID="txtLanguage" runat="server"></asp:TextBox><br />
            </div>
            <div class="button-save"> 
                 <asp:Button ID="btnSave"  class=buttonsave runat="server" Text="Save" OnClick="btnSave_Click" />
 <asp:Button ID="btnUpdate"  class=buttonsave runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 <asp:Button ID="btnViewBooks" class=buttonsave runat="server" Text="View Books" OnClick="btnViewBooks_Click" />
                <div class="message">
                    <asp:Label ID="Label1" runat="server" />
                </div>
                
            </div>
           
        </div>
    </main>
</asp:Content>
