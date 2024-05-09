<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>

        <title>PracticaMaD</title>

    </head>

    <body>
        <form id="form1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Introduce el nombre de usuario" Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:TextBox ID="TxtBoxUserName" runat="server" Style="margin-left: 20px"></asp:TextBox>
            <br />

            <asp:Label ID="Label4" runat="server" Text="Introduce la contraseña" Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:TextBox ID="TxtBoxPassword" runat="server" Style="margin-left: 20px"></asp:TextBox>
            <br />

            <asp:Label ID="LabelNombre" runat="server" Text="Nombre: " Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:TextBox ID="TxtBoxNombre" runat="server" Style="margin-left: 20px"></asp:TextBox>
            <br />

            <asp:Label ID="LabelApellidos" runat="server" Text="Apellidos: " Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:TextBox ID="TextBoxApellidos" runat="server" Style="margin-left: 20px"></asp:TextBox>
            <br />

            <asp:Label ID="LabelEmail" runat="server" Text="Email: " Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:TextBox ID="TextBoxEmail" runat="server" Style="margin-left: 20px"></asp:TextBox>
            <br />

            <asp:Label ID="LabelLanguage" runat="server" Text="Idioma: " Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:TextBox ID="TextBoxLanguage" runat="server" Style="margin-left: 20px"></asp:TextBox>
            <br />

            <asp:Label ID="LabelWorkshopId" runat="server" Text="WorkshopId: " Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:TextBox ID="TextBoxWorkshopId" runat="server" Style="margin-left: 20px"></asp:TextBox>

            <a href="RegisterWorkshop.aspx">Registra tu taller aquí</a>
            <br />

            <asp:Label ID="LabelUserCreated" runat="server" Text="Usuario creado" Visible="false" Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:Label ID="LabelUserAlreadyCreated" runat="server" Text="Usuario ya existe, no se pudo crear" Visible="false" Style="margin-left: 20px"></asp:Label>
            <br />

            <asp:Button ID="Button1" runat="server" Text="Registrar" Style="margin-left: 20px" OnClick="Button1_Click" />

        </form>

    </body>
    </html>

</asp:Content>

    
    
