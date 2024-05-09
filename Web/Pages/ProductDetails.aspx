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
            <form id="form1" runat="server" style="margin-top: 40px">
                <div class="container">
                    <div class="row">
                        <div class="col-sm">
                            <asp:Image height="256" width="256" ID="ProductImage" runat="server" ImageUrl="~/Imagenes/MAHLE ORIGINAL OX 188D.jpg" />
                        </div>
                        <div class="col-sm">
                            <asp:Label ID="ProductName" Text="" runat="server" Style="font-size: larger"> </asp:Label>
                            <br />
                            <ul id="DetailsList"  runat="server" style="margin-top: 30px">
                            </ul>
                            <asp:Button ID="Button1" runat="server" Text="Añadir al carrito" Style="margin-top: 20px" OnClick="Button1_Click" />
                        </div>
                        <div class="col-sm">


                        </div>
                    </div>
                </div>
            </form>
        </div>
        

        
    </body>

    </html>

</asp:Content>
