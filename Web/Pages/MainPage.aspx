<%@ Page Title="Página Principal" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">

    <form id="form1" runat="server">
        <style>
            .search-bar {
                margin-bottom: 24px;
                text-align: center;
            }

            .card-custom {
                border: 1px solid #ccc;
                border-radius: 10px;
                padding: 10px;
                box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.1);
                height: 300px; /* Fija la altura de las tarjetas */
                overflow: hidden; /* Asegura que el contenido no se desborde */
                cursor: pointer; /* Cambia el cursor para indicar que la tarjeta es clickeable */
                transition: transform 0.2s; /* Añade una transición suave */
            }

            .card-custom:hover {
                transform: scale(1.05); /* Aumenta ligeramente el tamaño al pasar el ratón por encima */
            }

            .card-img-top {
                object-fit: cover;
                height: 180px; /* Ajusta la altura de las imágenes */
                width: 100%;
                border-bottom: 1px solid #ddd;
            }

            .data-pager {
                text-align: center;
                margin-top: 20px;
            }
        </style>

        <div class="container mt-5">
            <div class="search-bar">
                <div class="row mb-3">
                    <div class="col-md-4 offset-md-4">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                            <asp:ListItem Text="" Value="" />
                            <asp:ListItem Text="Neumáticos" Value="Neumaticos" />
                            <asp:ListItem Text="Neumáticos de invierno" Value="Neumaticos de invierno" />
                            <asp:ListItem Text="Filtros de aceite" Value="Filtros de aceite" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-md-6 offset-md-3">
                        <div class="input-group">
                            <asp:TextBox ID="TextBoxBusqueda" runat="server" CssClass="form-control" placeholder="Buscar productos..."></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="Button_Search" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <asp:ListView ID="ListView1" runat="server" AllowPaging="True" PageSize="12" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4">
                            <a href="../Pages/ProductDetails.aspx?id=<%# Eval("detailsUrl") %>" class="text-decoration-none">
                                <div class="card card-custom">
                                    <img src='<%# FormatName(Eval("name")) %>' class="card-img-top" alt="...">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("name") %></h5>
                                        <p class="card-text"><strong>Precio: </strong><%# Eval("price") + "€" %></p>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            
            <div class="data-pager">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="12">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>
    </form>
</asp:Content>
