<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppLibros.Default" %>

<%@ Import Namespace="WebAppLibros.Modelo" %>

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
    <link href="css/bootstrap.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-md navbar-dark bg-dark">
                <a class="navbar-brand" href="#">{Nombre Proyecto}</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarCollapse">                
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active"><a class="nav-link" href="Default.aspx">Inicio</a></li>
                        <% if (Session["usuario"] != null) { %>
                            <% Usuario usuario = (Usuario)Session["usuario"]; %>
                            <% if (usuario.Rol == "ADMIN") { %>
                                <li class="nav-item"><a class="nav-link" href="Libros/InsertarLibro.aspx">Insertar libro</a></li>
                                <li class="nav-item"><a class="nav-link" href="Libros/ConsultarLibros.aspx">Consultar libros</a></li>
                            <% } else { %>
                                <li class="nav-item"><a class="nav-link" href="Libros/ConsultarLibros.aspx">Consultar libros</a></li>
                            <% } %>
                        <% } %>
                    </ul>
                    
                    <% if (Session["usuario"] == null) { %>
                        <a class="btn btn-outline-success" href="Acceso/Login.aspx">Iniciar sesión</a>
                    <% } else { %>
                    <% Usuario usuario = (Usuario)Session["usuario"]; %>
                        <a class="navbar-brand" href="Cuenta/Perfil.aspx"><%=usuario.Nombre + " " + usuario.Apellidos %></a>
                        <a class="btn btn-outline-danger" href="Acceso/CerrarSesion.aspx">Cerrar sesión</a>
                    <% } %>
                </div>
            </nav>
            
            <div>
                <h1 class="text-center"><% Response.Write("Titulo: " + Titulo); %></h1>
            </div>
            
            <main role="main">
			    <div class="jumbotron">
				    <div class="container">
					    <h1 class="display-3">Bienvenidos a {Nombre Proyecto}</h1>
                        <hr>
					    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Soluta eveniet error amet beatae dolorem, voluptate quos. Fuga quia, necessitatibus, eius, beatae aliquid veritatis optio incidunt ducimus sit mollitia provident quo.</p>
					    <% if (Session["usuario"] == null) { %><p><a class="btn btn-primary btn-lg" href="Acceso/Registro.aspx" role="button">Regístrate »</a></p><% } %>
				    </div>
			    </div>
	        </main>
        </div>
    </form>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/jquery-3.3.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
