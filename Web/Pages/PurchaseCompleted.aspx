<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PurchaseCompleted.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.PurchaseCompleted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <title> PURCHASE COMPLETED </title>
        </head>
        <body>
            <div>
                <div class="container">
                    <div class="row">
                        <div class="col-sm">
                            <asp:Image ID="OkImage" runat="server" Height="256" Width="256" />
                        </div>
                        <div class="col-sm">
                            
                            <h1> Se ha realizado la compra con éxito </h1>
                            <asp:HyperLink ID="GoHomeHL" runat="server" NavigateUrl="~/Pages/MainPage.aspx">Ir a la página principal.</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </body>
    </html>
</asp:Content>

