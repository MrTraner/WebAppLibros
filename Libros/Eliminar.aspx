<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="WebAppLibros.Libros.Eliminar" %>

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
    <title>Eliminar</title>
</head>
<body>

</body>
</html>
