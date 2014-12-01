<%@ Page Title="Order Page Contents" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Bug2Bug.ProtectedContent.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>Your shopping cart contents:</p>

    <asp:ListBox ID="orderListBox" runat="server" DataTextField="Title1" DataValueField="ISBN" OnSelectedIndexChanged="ListBox1_GetISBN" SelectionMode="Single" CssClass="form-select" >

    </asp:ListBox>

    <div class="page-container">
        <div class="div-25">
            <asp:Button ID="removeitems" runat="server" Text="Remove from Cart" OnClick="ListBox1_RemoveFromCart" CssClass="button button-default" />
        </div>
        <div class="div-25">
            <asp:Button ID="emptyitems" runat="server" Text="Empty Cart" OnClick="ListBox1_EmptyCart" CssClass="button button-default" />
        </div>
        <div class="div-25">
            <asp:Button ID="continueShopping" runat="server" Text="Continue Shopping" OnClick="GoToBooks" CssClass="button button-default" />
        </div>
        <div class="div-25">
            <asp:Button ID="checkOut" runat="server" Text="Check Out" OnClick="CheckOutOrder" CssClass="button button-advance" />
        </div>
    </div>
</asp:Content>