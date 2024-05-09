<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegisterWorkshop.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.RegisterWorkshop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form1" runat="server">
        <asp:Label ID="Labelwshopname" runat="server" Text="Introduce el nombre del taller" Style="margin-left: 20px"></asp:Label>
        <br />

        <asp:TextBox ID="TxtBoxWorkshopName" runat="server" Style="margin-left: 20px"></asp:TextBox>
        <br />

        <asp:Label ID="Labelcountry" runat="server" Text="Introduce el país" Style="margin-left: 20px"></asp:Label>
        <br />

        <asp:TextBox ID="TxtBoxCountry" runat="server" Style="margin-left: 20px"></asp:TextBox>
        <br />

        <asp:Label ID="Labelpostalcode" runat="server" Text="Código postal: " Style="margin-left: 20px"></asp:Label>
        <br />

        <asp:TextBox ID="TxtBoxPostalCode" runat="server" Style="margin-left: 20px"></asp:TextBox>
        <br />

        <asp:Label ID="LabelUserCreated" runat="server" Text="Taller creado" Visible="false" Style="margin-left: 20px"></asp:Label>
        <br />

        <asp:Label ID="LabelUserAlreadyCreated" runat="server" Text="Taller ya existe, no se pudo crear" Visible="false" Style="margin-left: 20px"></asp:Label>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Registrar taller" Style="margin-left: 20px" OnClick="Button1_Click" />

    </form>
</asp:Content>
