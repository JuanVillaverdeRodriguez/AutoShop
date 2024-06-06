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
                            <div class="col">
                                <asp:ListView ID="ListView1" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-3 mb-3">
                                            <div class="card" style="width: 60%;">
                                                <img src='<%# FormatName(Eval("ProductName")) %>' class="card-img-top" height="128" width="128" alt="...">
                                                <div class="card-body">
                                                    <h5 class="card-title" id="cardTitle"></h5>
                                                    <p><%# Eval("Price") + "€" %></p>
                                                </div>
                                                <asp:Label ID="productId" runat="server" Visible="false" Text=<%# Eval("ProductId") %>></asp:Label>
                                            </div>
                                            <div class="row">
                                                <div class="col d-flex align-items-center">
                                                    <asp:Button ID="buttonAdd" runat="server" Text="+" OnClick="buttonAdd_Click" CommandArgument='<%# Container.DisplayIndex %>' />
                                                    <asp:Label ID="productCount" runat="server" Text=<%# Eval("Quantity") %>></asp:Label>
                                                    <asp:Button ID="buttonSubstract" runat="server" Text="-" OnClick="buttonSubstract_Click" CommandArgument='<%# Container.DisplayIndex %>' />
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                            <div class="col">
                                <div>
                                    <h1> PEDIDO </h1>
                                    <p id="paragraphTotalPrice" runat="server"></p>
                                </div>
                                <asp:Button ID="ButtonTramitarId" runat="server" Text="Tramitar pedido" OnClick="TramitarPedido" />
                            </div>
                        </div>
                    </div>
                </form>

            </div>


        </body>
    </html>
</asp:Content>
