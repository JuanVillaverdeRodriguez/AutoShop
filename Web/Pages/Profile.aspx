<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .profile-container {
            max-width: 600px;
            margin: auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 10px;
            background-color: #f9f9f9;
        }
        .profile-header {
            text-align: center;
            margin-bottom: 20px;
        }
        .profile-form .form-group {
            margin-bottom: 15px;
        }
        .profile-buttons {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="profile-container">
            <div class="profile-header">
                <h2>Perfil</h2>
            </div>
            <form id="form1" runat="server" class="profile-form">
                <div class="form-group">
                    <label for="Name">Nombre</label>
                    <asp:TextBox ID="Name" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Surname">Apellido</label>
                    <asp:TextBox ID="Surname" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Email">Correo Electrónico</label>
                    <asp:TextBox ID="Email" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Language">Idioma</label>
                    <asp:TextBox ID="Language" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Country">País</label>
                    <asp:TextBox ID="Country" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="WorkshopId">ID del Taller</label>
                    <asp:TextBox ID="WorkshopId" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="profile-buttons">
                    <asp:Button ID="ButtonUpdateProfile" runat="server" Text="Aplicar" CssClass="btn btn-primary" OnClick="buttonApply_click" />
                    <asp:Button ID="ButtonCancelUpdateProfile" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="buttonCancel_click"/>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
