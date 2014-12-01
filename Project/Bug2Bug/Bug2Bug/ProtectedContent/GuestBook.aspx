<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GuestBook.aspx.cs" Inherits="Bug2Bug.ProtectedContent.GuestBook" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="Content1" runat="server" >

    <asp:Label ID="NameLabel" runat="server" AssociatedControlID="Name">Name</asp:Label>
    <asp:TextBox ID="Name" runat="server" />

    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email</asp:Label>
    <asp:TextBox runat="server" ID="Email" TextMode="Email"/>
<!--    <asp:RegularExpressionValidator ID="emailValidator" runat="server" ControlToValidate="Email" 
        ValidationExpression="/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i" 
        CssClass="field-validation-error" ErrorMessage="Invalid email address" Display="Dynamic"/> -->

    <asp:Label ID="MessageLabel" runat="server" AssociatedControlID="Message">Message</asp:Label>
    <asp:TextBox ID="Message" runat="server" />
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateButton1" EventName="Click" />
        </Triggers>
            <ContentTemplate>
                
                <asp:GridView runat="server" ID="GuessBook_GridView">

                </asp:GridView>               
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button runat="server" ID="UpdateButton1" OnClick="UpdateButton_Click" Text="Update" />

</asp:Content>