<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateUserDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.UpdateUserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Rellene los campos a cambiar: "></asp:Label>
        <br />

        <asp:Label ID="LabelNombre" runat="server" Text="Nombre: "></asp:Label>
        <br />

        <asp:TextBox ID="TxtBoxNombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelApellidos" runat="server" Text="Apellidos: "></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxApellidos" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelEmail" runat="server" Text="Email: "></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelLanguage" runat="server" Text="Idioma: "></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxLanguage" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelChangesApplied" runat="server" Text="Cambios aplicados" Visible="false"></asp:Label>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Confirmar Cambios" OnClick="Button1_Click" />

    </form>
</asp:Content>
