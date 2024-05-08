<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <title> CART PAGE </title>

        </head>
        <body>
            <div>
                <form id ="form1" runat="server">
                <div class="container" runat="server">
                    <div class="row" runat="server">
                        <asp:ListView ID="ListView1" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-3 mb-3">
                                    <div class="card" style="width: 60%;">
                                        <img src='<%#FormatName(Eval("name"))%>' class="card-img-top" height="128" width="128" alt="...">
                                        <div class="card-body">
                                            <h5 class="card-title" id="cardTitle"></h5>
                                            <p><%# Eval("price") + "€"%></p>
                                            <a href="#" class="btn btn-primary">Ver detalles</a>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <div class="col" id="CartProductList" runat="server">
                            <!-- Aqui se irian añadiendo divs representando los productos en el carrito -->
                        </div>
                        <div class="col">
                        </div>

                    </div>
                </div>
                       </form>

            </div>


        </body>
    </html>
</asp:Content>
