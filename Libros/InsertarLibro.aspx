<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarLibro.aspx.cs" Inherits="WebAppLibros.Libros.InsertarLibro" %>

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
                    <li class="nav-item"><a class="nav-link" href="../Acceso/Login.aspx">Login</a></li>
                    <li class="nav-item active"><a class="nav-link" href="InsertarLibro.aspx">Insertar libro</a></li>
                    <li class="nav-item"><a class="nav-link" href="ConsultarLibros.aspx">Consultar libros</a></li>
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
            <form id="Form1" runat="server" method="post" >
                <label>Titulo:</label>
                <input class="form-control" type="text" name="Titulo" required />
                <br />
                <label>Autor:</label>
                <input class="form-control" type="text" name="Autor" required />
                <br />
                <label>Descricpión:</label>
                <textarea class="form-control" name="Descripcion" required></textarea>
                <br />
                <label>Total de páginas:</label>
                <input class="form-control" type="number" name="TotalPaginas" required />
                <br />
                <label>Precio:</label>
                <input class="form-control" type="text" name="Precio" required /
                <br />
                <br />
                <asp:Button ID="btnInsertar" CssClass="btn btn-primary btn-block" Text="Insertar" runat="server"></asp:Button>
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
