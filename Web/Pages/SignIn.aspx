<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form1" runat="server">
        <asp:Label ID="LabelIntroduceNombre" runat="server" Text="Introduce el nombre de usuario" Style="margin-left: 20px"></asp:Label>
        <br />

        <asp:TextBox ID="TxtBoxUserName" runat="server" Style="margin-left: 20px"></asp:TextBox>
        <br />

        <asp:Label ID="LabelIntroduceContraseña" runat="server" Text="Introduce la contraseña" Style="margin-left: 20px"></asp:Label>
        <br />

        <asp:TextBox ID="TxtBoxPassword" runat="server" Style="margin-left: 20px"></asp:TextBox>
        <br />

        <asp:Label ID="LabelUsuarioLogueado" runat="server" Text="Usuario logueado" Style="margin-left: 20px" Visible="false"></asp:Label>
        <br />

        <asp:Label ID="LabelCredencialesIncorrectas" runat="server" Text="Credenciales incorrectas." Style="margin-left: 20px" Visible="false"></asp:Label>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Log in" Style="margin-left: 20px" OnClick="Button1_Click" />

        <a href="CreateUser.aspx">Registrate aqui</a>
    </form>

</asp:Content>
