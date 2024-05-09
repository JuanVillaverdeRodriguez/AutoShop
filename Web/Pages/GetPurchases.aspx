<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GetPurchases.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.GetPurchases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form1" runat="server" style="margin-top: 24px">
        <style>
            .card {
            border: 2px solid #ccc; /* Ajusta el grosor y el color del borde según tus preferencias */
            border-radius: 5px; /* Añade esquinas redondeadas si lo deseas */
            }
        </style>
        <div class="container">
                <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-2 mb-2">
                            <div class="card" style="width: 75%;">
                                <div class="card-body">
                                    <h5 class="card-title" id="cardTitle"><%# Eval("descriptiveName")%></h5>
                                    <p><%# "Realizado el: "+ Eval("purchaseDate")%></p>
                                    <p><%# "Tarjeta: " + Eval("cardNumber")%></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
        </div>
    </form>
</asp:Content>
