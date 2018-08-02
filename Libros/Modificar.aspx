<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="WebAppLibros.Libros.Modificar" %>

<%@ Import Namespace="WebAppLibros.Modelo" %>

<%
    if (Session["usuario"] == null)
    {
        Response.Redirect("../Acceso/Login.aspx");
    }
    else
    {
        Usuario usuario = (Usuario)Session["usuario"];

        if (usuario.Rol != "ADMIN")
        {
            Response.Redirect("../Default.aspx");
        }
    }
%>

<!DOCTYPE html>
<html lang="es-mx">
<head runat="server">
    <title>Modificar</title>
</head>
<body>
    
</body>
</html>
