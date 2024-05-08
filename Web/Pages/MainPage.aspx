<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="true">

    <form id ="form1" runat="server">
        <asp:Label ID="CheckLogin" runat="server" Text="Texto" EnableViewState="false"></asp:Label>
        <br />
        <div>
            <asp:Panel ID="YourPanel" runat="server">
                <!-- Aquí es donde se agregarán las etiquetas dinámicamente -->
            </asp:Panel>
        </div>


        <asp:ListView ID="ListView1" runat="server">
            <LayoutTemplate>
                <table cellpadding="2" width="640px" border="1" runat="server" id="tblProducts">
                    <tr runat="server">
                        <th runat="server">Action</th>
                        <th runat="server">First Name</th>
                        <th runat="server">Last Name</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <img src='<%#FormatName(Eval("name"))%>' class="card-img-top" height="128" width="128" alt="...">
                    <div class="card-body">
                        <h5 class="card-title" id="cardTitle"></h5>
                        <p><%# Eval("price") + "€"%></p>
                        <a href="#" class="btn btn-primary">Ver detalles</a>
                    </div>
                </div>
            </ItemTemplate>
            </asp:ListView>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>

    </form>

    

<html>
    <head>

        <title>PracticaMaD</title>
        <!--<link rel="stylesheet" href="../CSS/CreateUser.css">-->
        <link rel="stylesheet" href="/Content/bootstrap.css"/>

        

    </head>

    <body>
        
    </body>
</html>
</asp:Content>

    
    
