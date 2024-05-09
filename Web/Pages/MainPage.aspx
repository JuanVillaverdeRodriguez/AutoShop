<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">

    <form id ="form1" runat="server" style="margin-bottom: 24px">
        <br />
        <div>
            <asp:Panel ID="YourPanel" runat="server">
                <!-- Aquí es donde se agregarán las etiquetas dinámicamente -->
            </asp:Panel>
        </div>
        <style>
            .card {
            border: 2px solid #ccc; /* Ajusta el grosor y el color del borde según tus preferencias */
            border-radius: 5px; /* Añade esquinas redondeadas si lo deseas */
            }
        </style>
        <div class="container">
            <div class="row mb-3">
                <div class="col">
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                        <asp:ListItem Text="" Value="" />
                        <asp:ListItem Text="Neumáticos" Value="Neumaticos" />
                        <asp:ListItem Text="Neumáticos de invierno" Value="Neumaticos de invierno" />
                        <asp:ListItem Text="Filtros de aceite" Value="Filtros de aceite" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="row mb-3">
                    <div class="col">
                        <asp:TextBox ID="TextBoxBusqueda" runat="server"></asp:TextBox>
                        <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="Button_Search"/>
                    </div>
                </div>
                <asp:ListView ID="ListView1" runat="server" AllowPaging="True" PageSize="12" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-sm-2 mb-2">
                            <div class="card" style="width: 75%;">
                                <img src='<%#FormatName(Eval("name"))%>' class="card-img-top" height="128" width="128" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title" id="cardTitle"></h5>
                                    <p style="font-size: smaller;"><%# Eval("name")%></p>
                                    <p><%# Eval("price") + "€"%></p>
                                    <a href="../Pages/ProductDetails.aspx?id=<%#Eval("detailsUrl") %>" class="btn btn-primary">Ver detalles</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="12">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="False" />
                </Fields>
            </asp:DataPager>
    </form>
</asp:Content>
