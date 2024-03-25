<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Introduce el nombre de usuario"></asp:Label>
        <br />
        <asp:TextBox ID="TxtBoxUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Introduce la contraseña"></asp:Label>
        <br />
        <asp:TextBox ID="TxtBoxPassword" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LabelUserCreated" runat="server" Text="Usuario creado" Visible="false"></asp:Label>
        <br />

        <asp:Label ID="LabelUserAlreadyCreated" runat="server" Text="Usuario ya existe, no se pudo crear" Visible="false"></asp:Label>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Dale pa lante" OnClick="Button1_Click" />

    </form>
    
</asp:Content>
