<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Error404" runat="server" Text="Error 404 Lo sentimos la dirección web que has especificado no es una página activa de nuestra web."></asp:Label>
             <li class="nav-item">
                <a class="nav-link" href="../../Pages/MainPage.aspx">Volver a la página principal</a>
             </li>
        </div>
    </form>
</body>
</html>
