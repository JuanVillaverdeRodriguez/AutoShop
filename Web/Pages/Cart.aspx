<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <title>CART PAGE</title>
            <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
            <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
        </head>
        <body>
            <div class="container mt-5">
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-lg-8">
                                    <asp:ListView ID="ListView1" runat="server">
                                        <ItemTemplate>
                                            <div class="card mb-3" style="max-width: 200px;">
                                                <img src='<%# FormatName(Eval("ProductName")) %>' class="card-img-top" style="height: 100px; object-fit: cover;" alt="Product Image">
                                                <div class="card-body p-2">
                                                    <h6 class="card-title mb-1"><%# Eval("ProductName") %></h6>
                                                    <p class="card-text mb-1">Precio(ud): <%# Eval("Price") %>€</p>
                                                    <p class="card-text mb-1">Subtotal: <%# Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("Quantity")) %>€</p>
                                                    <asp:Label ID="productId" runat="server" Visible="false" Text='<%# Eval("ProductId") %>'></asp:Label>
                                                    <div class="d-flex justify-content-between align-items-center">
                                                        <asp:Button ID="buttonAdd" runat="server" CssClass="btn btn-primary btn-sm" Text="+" OnClick="buttonAdd_Click" CommandArgument='<%# Container.DisplayIndex %>' />
                                                        <asp:Label ID="productCount" runat="server" CssClass="mx-2" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                        <asp:Button ID="buttonSubstract" runat="server" CssClass="btn btn-primary btn-sm" Text="-" OnClick="buttonSubstract_Click" CommandArgument='<%# Container.DisplayIndex %>' />
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                                <div class="col-lg-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <h3 class="card-title">PEDIDO</h3>
                                            <p id="paragraphTotalPrice" runat="server"></p>
                                            <asp:Button ID="ButtonTramitarId" runat="server" CssClass="btn btn-success btn-block" Text="Tramitar pedido" OnClick="TramitarPedido" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
            <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
            <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
            <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        </body>
    </html>
</asp:Content>
