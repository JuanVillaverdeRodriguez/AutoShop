<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">

<html>
<head>
    <title>DETALLE DEL PRODUCTO</title>
    <link rel="stylesheet" href="/Content/bootstrap.css" />
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
    <form id="form1" runat="server" style="margin-top: 40px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <asp:Image ID="ProductImage" runat="server" Height="256" Width="256" />
                </div>
                <div class="col-sm">
                    <asp:Label ID="ProductName" runat="server" Style="font-size: larger"></asp:Label>
                    <br />
                    <asp:Label ID="ProductPrice" runat="server" Style="font-size: larger"></asp:Label>
                    <br />
                    <asp:Label ID="ProductStock" runat="server" Style="font-size: larger"></asp:Label>
                    <br />
                    <ul id="DetailsList" runat="server" style="margin-top: 30px"></ul>

                    <!-- Para que solo se actualice lo de dentro de UpdatePanel (solo el boton) cuando se pulse el boton y se haga PostBack -->
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
                        <ContentTemplate>
                            <asp:Button ID="Button1" runat="server" Text="Añadir al carrito" Style="margin-top: 20px" OnClick="Button1_Click" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

</asp:Content>
