<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.cs" Inherits="Bug2Bug.Api._default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script> 
  
    <asp:UpdatePanel ID="Update" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID ="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:GridView runat="server" ID="Authors_GridView">

            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
   

    <h2>Add Author</h2>

    <table>

   
        <tr>
            <td>FirstName</td>
            <td><asp:TextBox runat="server" ID="fname" /></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td><asp:TextBox runat="server" ID="lname" /></td>
        </tr>
        <tr>
            <td><asp:Button Text="Save" runat="server" ID="btnSave" OnClick="SaveButton_Click"/></td>
        </tr>
    </table>
    <br />
    <h2>Search Author by last name</h2>
    <asp:TextBox ID="authorSearch" runat="server" />
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="SearchButton_Click" />
    

     <br />

    <h2>Delete Author</h2>
    <asp:TextBox ID="authorDelete" runat="server" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="DeleteButton_Click" />

 



</asp:Content>
