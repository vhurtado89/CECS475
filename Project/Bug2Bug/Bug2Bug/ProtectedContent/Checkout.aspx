<%@ Page Title="Checkout Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Bug2Bug.ProtectedContent.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>SUP.</h1>
    
    <asp:ListBox ID="checkoutListBox" runat="server" DataTextField="Title1" DataValueField="ISBN" CssClass="form-select" >
    </asp:ListBox>

    <fieldset>
        <legend>Finalize Order</legend>
        <ol>
            <li>
                <asp:Label ID="CreditCardLabel" runat="server" AssociatedControlID="CreditCard">Credit Card Number</asp:Label>
                <asp:TextBox runat="server" ID="CreditCard" TextMode="Phone"/>
                <asp:RequiredFieldValidator ID="CreditCardLengthValidator" runat="server" ControlToValidate="CreditCard"
                    CssClass="field-validation-error" ErrorMessage="A credit card number is required." Display="Dynamic" />
                <asp:RegularExpressionValidator ID="CreditCardNumberValidator" runat="server" ControlToValidate="CreditCard" ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14})$"
                    CssClass="field-validation-error" ErrorMessage="Sorry, we only accept Visa or MasterCard." Display="Dynamic" />
            </li>
        </ol>
    </fieldset>

    <div class="page-container">
        <div class="div-25">
            <asp:Button ID="editCart" runat="server" Text="Edit Shopping Cart" CssClass="button button-default" OnClick="ReturnToCart" />
        </div>
        <div class="div-25">
            <asp:Button ID="continueShopping" runat="server" Text="Continue Shopping" CssClass="button button-default" OnClick="ContinueShopping" />
        </div>
        <div class="div-25">
            <asp:Button ID="finalizeOrder" runat="server" Text="Finalize Order" CssClass="button button-advance" OnClick="FinalizeOrder" />
        </div>
        <div class="div-25">
            <p>&nbsp;</p>
        </div>
    </div>

</asp:Content>
