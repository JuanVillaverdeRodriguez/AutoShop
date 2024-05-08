<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">

    <html>
    <head>
        <title>PDETALLE DEL PRODUCTO </title>
        <link rel="stylesheet" href="/Content/bootstrap.css"/>

    </head>
    <body>
        <div>

        </div>
        <div>
            <form id="form1" runat="server">
        
            <asp:Label ID="ProductName" Text="" runat="server"> </asp:Label>
        </form>

        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <asp:Image height="256" width="256" ID="ProductImage" runat="server" ImageUrl="~/Imagenes/MAHLE ORIGINAL OX 188D.jpg" />
                </div>
                <div class="col-sm">
                    <ul id="DetailsList"  runat="server">
                    </ul>
                </div>
                <div class="col-sm">
                    <div class = "card">
            <div class="card-body">
                <h5 class="card-title" ID="cardTitle"> PRODUCT NAME -title" ID="cardTitle"> PRODUCT NAME </h5>
                <p class="card-text">Esta seria la descripcion del producto chulisimo.</p>
                <a href="#" class="btn btn-primary"> Añadir al carrito</a>
            </div>
        </div>

                </div>
            </div>
        </div>
        

        
    </body>

    </html>

</asp:Content>
