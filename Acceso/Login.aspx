<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppLibros.Acceso.Login" %>

<%
    if (Session["usuario"] != null)
    {
        Response.Redirect("../Default.aspx");
    }
%>

<!DOCTYPE html>
<html lang="es-mx">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Ejemplo de Bootstrap">
    <meta name="author" content="Juan Mauricio Ochoa Castillo">
    <link rel="icon" href="favicon.ico">
    
    <title><%=Titulo%></title>

    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.css" rel="stylesheet">
</head>
<body>
    <div>
        <nav class="navbar navbar-expand-md navbar-dark bg-dark">
            <a class="navbar-brand" href="#">{Nombre Proyecto}</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">                
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item"><a class="nav-link" href="../Default.aspx">Inicio</a></li>
                    <li class="nav-item active"><a class="nav-link" href="Login.aspx">Login</a></li>
                    <li class="nav-item"><a class="nav-link" href="../Libros/InsertarLibro.aspx">Insertar libro</a></li>
                    <li class="nav-item"><a class="nav-link" href="../Libros/ConsultarLibros.aspx">Consultar libros</a></li>
                </ul>
                    
                <% if (Session["usuario"] == null) { %>
                    <a class="btn btn-outline-success" href="Acceso/Login.aspx">Iniciar sesión</a>
                <% } else { %>
                    <a class="btn btn-outline-danger" href="Acceso/CerrarSesion.aspx">Cerrar sesión</a>
                <% } %>
            </div>
        </nav>
        
        <div>
            <h1 class="text-center"><% Response.Write("Titulo: " + Titulo); %></h1>
        </div>
        
        <div class="container">
            <form id="Form1" runat="server" method="post">
                <label>Usuario:</label>
                <input class="form-control" type="text" name="Usuario" placeholder="Nombre de usuario" required />
                <br />
                <label>Contraseña:</label>
                <input class="form-control" type="password" name="Contraseña" placeholder="Contraseña" required />
                <br />
                <br />
                <button class="btn btn-primary btn-block" type="submit">Iniciar sesión</button>
            </form>
        </div>
    </div>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="../js/jquery-3.3.1.js"></script>
    <script src="../js/bootstrap.min.js"></script>
</body>
</html>
