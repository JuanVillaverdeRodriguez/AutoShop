<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">
    <html>
        <head>
            <title> PURCHASE PAGE </title>
            <link href="../CSS/Purchase.css" rel="stylesheet" />

            
        </head>
        <body>
            <form id ="form1" runat="server">
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <div>
                                <asp:Label ID="Label1" runat="server" Text="Introduce codigo postal"></asp:Label>
                                <br />

                                <asp:TextBox ID="TextBoxPostalCode" runat="server"></asp:TextBox>
                                <br />


                            </div>
                            <asp:ListView ID="ListView1" runat="server">
                                <ItemTemplate>
                                    <div>
                                        <asp:Label runat="server"> ID="labelCardNumber"Text="Card Number: <%#Eval("cardNumber").ToString()%>"</asp:Label>
                                        <asp:Button ID="Button1" runat="server" Text="Select card" OnClick="divUserCard_Click"/>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                            

                            <asp:Button ID="ButtonAddCardId" runat="server" Text="Añadir nueva tarjeta"  OnClick="ButtonCreateNewCard"/>
                            
                            <div id="divCreateNewCardId" runat="server">

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
                                    <asp:ListItem Text="Mastercard" Value="Mastercard" />
                                    <asp:ListItem Text="Visa" Value="Visa" />
                                    <asp:ListItem Text="American Express" Value="American Express" />
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

                                <asp:Label ID="Label3" runat="server" Text="¿Usar como tarjeta por defecto?"></asp:Label>
                                <br />

                                <asp:CheckBox ID="CheckBoxDefaultCard" runat="server" />
                                <br />

                                

                                <asp:Label ID="LabelTarjetaCreada" runat="server" Text="Compra realizada correctamente" Visible="false"></asp:Label>
                                <br />

                                <asp:Label ID="LabelTarjetaNoCreada" runat="server" Text="Error al realizar la compra. ¿La tarjeta es valida?" Visible="false"></asp:Label>
                                <br />

                            </div>
                            <div>
                                <asp:Label ID="Label4" runat="server" Text="Descripcion de la compra"></asp:Label>
                                <br />

                                <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col">
                            <h1> COMPRAR </h1>
                                <asp:Label ID="Label2" runat="server" Text="¿Pedido urgente?"></asp:Label>
                                <br />
                                <asp:CheckBox ID="CheckBoxIsUrgent" runat="server" />
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="Comprar" OnClick="ButtonBuy_Click" />
                        </div>
                    </div>

                </div>
            </form>
        </body>
    </html>
</asp:Content>
