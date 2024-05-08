﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <title> PURCHASE PAGE </title>
        </head>
        <body>
            <div>
                <form id ="form1" runat="server">
                    <asp:Label ID="Label1" runat="server" Text="Introduce codigo postal"></asp:Label>
                    <br />

                    <asp:TextBox ID="TextBoxPostalCode" runat="server"></asp:TextBox>
                    <br />

                    <asp:Label ID="LabelIntroduceNuevaTarjeta" runat="server" Text="Introduce la nueva tarjeta"></asp:Label>
                    <br />

                    <asp:TextBox ID="TextBoxNumeroTarjeta" runat="server"></asp:TextBox>
                    <br />

                    <asp:Label ID="LabelIntroduceCSV" runat="server" Text="Introduce CSV"></asp:Label>
                    <br />

                    <asp:TextBox ID="TextBoxCSV" runat="server"></asp:TextBox>
                    <br />
                    
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                        <asp:ListItem Text="" Value="" />
                        <asp:ListItem Text="Mastercard" Value="Neumaticos" />
                        <asp:ListItem Text="Visa" Value="Neumaticos de invierno" />
                        <asp:ListItem Text="American Express" Value="Filtros de aceite" />
                    </asp:DropDownList>

                    <asp:Label ID="LabelDATE" runat="server" Text="Introduce la fecha de expiracion"></asp:Label>
                    <br />

                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control">
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="4" Value="4" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="6" Value="6" />
                        <asp:ListItem Text="7" Value="7" />
                        <asp:ListItem Text="8" Value="8" />
                        <asp:ListItem Text="9" Value="9" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="11" Value="11" />
                        <asp:ListItem Text="12" Value="12" />
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" AutoPostBack="true">
                    </asp:DropDownList>

                    <asp:TextBox ID="TextBoxFECHA" runat="server"></asp:TextBox>
                    <br />

                    <asp:CheckBox ID="CheckBoxDefaultCard" runat="server" />
                    <br />

                    <asp:CheckBox ID="CheckBoxIsUrgent" runat="server" />
                    <br />

                    <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Comprar" OnClick="Button1_Click" />
                    <br />

                    <asp:Label ID="LabelTarjetaCreada" runat="server" Text="Compra realizada correctamente" Visible="false"></asp:Label>
                    <br />

                    <asp:Label ID="LabelTarjetaNoCreada" runat="server" Text="Error al realizar la compra. ¿La tarjeta es valida?" Visible="false"></asp:Label>
                    <br />


                </form>
            </div>
        </body>
    </html>
</asp:Content>