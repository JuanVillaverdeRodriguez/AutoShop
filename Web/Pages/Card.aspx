<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Card.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.AddCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form1" runat="server">
        <asp:Label ID="LabelIntroduceNuevaTarjeta" runat="server" Text="Introduce la nueva tarjeta"></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxNumeroTarjeta" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelIntroduceCSV" runat="server" Text="Introduce CSV"></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxCSV" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelTIPO" runat="server" Text="Introduce TIPO"></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxTIPO" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelDATE" runat="server" Text="Introduce la fecha de expiracion"></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxFECHA" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Dale pa lante" OnClick="Button1_Click" />

        <asp:Label ID="LabelTarjetaCreada" runat="server" Text="Tarjeta correctamente creada" Visible="false"></asp:Label>
        <br />

        <asp:Label ID="LabelTarjetaNoCreada" runat="server" Text="Error al crear tarjeta" Visible="false"></asp:Label>
        <br />



    </form>
    
</asp:Content>
