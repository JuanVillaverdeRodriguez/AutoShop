<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">
    <html>
        <head>
            <title> PURCHASE PAGE </title>
            <link href="../CSS/Purchase.css" rel="stylesheet" />
            <style>
                .notification {
                    position: relative;
                    background-color: #28a745;
                    color: white;
                    padding: 10px;
                    border-radius: 5px;
                    z-index: 1000;
                    opacity: 0;
                    transition: opacity 0.5s ease-in-out;
                    margin-top: 10px;
                }

                .notificationError {
                    position: relative;
                    background-color: #a7284a;
                    color: white;
                    padding: 10px;
                    border-radius: 5px;
                    z-index: 1000;
                    opacity: 0;
                    transition: opacity 0.5s ease-in-out;
                    margin-top: 10px;
                }

                .notification.show {
                    opacity: 1;
                }

                .notification.hide {
                    opacity: 0;
                    transition: opacity 0.5s ease-in-out;
                }

                .notification-container {
                    position: fixed;
                    top: 0;
                    left: 50%;
                    transform: translateX(-50%);
                    display: flex;
                    flex-direction: column-reverse;
                    align-items: center;
                    z-index: 1000;
                    pointer-events: none; /* Para evitar que la notificación bloquee otras acciones*/
                }

                .notificationError.show {
                    opacity: 1;
                }

                .notificationError.hide {
                    opacity: 0;
                    transition: opacity 0.5s ease-in-out;
                }

                .notificationError-container {
                    position: fixed;
                    top: 0;
                    left: 50%;
                    transform: translateX(-50%);
                    display: flex;
                    flex-direction: column-reverse;
                    align-items: center;
                    z-index: 1000;
                    pointer-events: none; /* Para evitar que la notificación bloquee otras acciones*/
                }
            </style>
            <script>
                let notificationCount = 0;
                const maxNotifications = 3;

                function ensureNotificationContainer() {
                    let notificationContainer = document.querySelector('.notification-container');
                    if (!notificationContainer) {
                        notificationContainer = document.createElement('div');
                        notificationContainer.className = 'notification-container';
                        document.body.appendChild(notificationContainer);
                    }
                    return notificationContainer;
                }

                function showNotification(message, isError) {
                    const notificationContainer = ensureNotificationContainer();

                    if (notificationCount >= maxNotifications) {
                        notificationContainer.removeChild(notificationContainer.lastChild);
                        notificationCount--;
                    }

                    const notification = document.createElement('div');
                    if (isError == "error") {
                        notification.className = 'notificationError';
                    }
                    else {
                        notification.className = 'notification';
                    }
                    notification.innerText = message;
            

                    notificationContainer.insertBefore(notification, notificationContainer.firstChild);
                    setTimeout(() => notification.classList.add('show'), 100); // Allow DOM to render

                    setTimeout(() => {
                        notification.classList.add('hide');
                        setTimeout(() => {
                            notificationContainer.removeChild(notification);
                            notificationCount--;
                        }, 500); // Match the CSS transition duration
                    }, 3000); // Display time

                    notificationCount++;
                }
            </script>
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
                            <asp:DropDownList ID="ddlCard" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            

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


                                <asp:Button ID="aceptar" runat="server" Text="aceptar tarjeta" visible="false" OnClick="ButtonAcceptNewCard"/>


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
                                <asp:Label ID="LabelPurchaseOkId" runat="server" Text="Compra realizada exitosamente!"></asp:Label>
                                <asp:Label ID="LabelPurchaseFailedOutOfStockId" runat="server" Text="No existen suficientes existencias del siguiente producto: "></asp:Label>

                        </div>
                    </div>

                </div>
            </form>
        </body>
    </html>
</asp:Content>
