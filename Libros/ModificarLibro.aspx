<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarLibro.aspx.cs" Inherits="WebAppLibros.Libros.ModificarLibro" %>

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
                    <% if (Session["usuario"] != null) { %>
                        <% Usuario usuario = (Usuario)Session["usuario"]; %>
                        <% if (usuario.Rol == "ADMIN") { %>
                            <li class="nav-item"><a class="nav-link" href="InsertarLibro.aspx">Insertar libro</a></li>
                            <li class="nav-item"><a class="nav-link" href="ConsultarLibros.aspx">Consultar libros</a></li>
                        <% } else { %>
                            <li class="nav-item"><a class="nav-link" href="ConsultarLibros.aspx">Consultar libros</a></li>
                        <% } %>
                    <% } %>
                </ul>
                    
                <% if (Session["usuario"] == null) { %>
                    <a class="btn btn-outline-success" href="../Acceso/Login.aspx">Iniciar sesión</a>
                <% } else { %>
                <% Usuario usuario = (Usuario)Session["usuario"]; %>
                    <a class="navbar-brand" href="../Cuenta/Perfil.aspx"><%=usuario.Nombre + " " + usuario.Apellidos %></a>
                    <a class="btn btn-outline-danger" href="../Acceso/CerrarSesion.aspx">Cerrar sesión</a>
                <% } %>
            </div>
        </nav>
        
        <div>
            <h1 class="text-center"><% Response.Write("Titulo: " + Titulo); %></h1>
        </div>
        
        <div class="container">
            <%
                if (libro != null)
                {
            %>
                    <form id="Form1" action="Modificar.aspx" runat="server" method="post">
                        <label>IdLibro:</label>
                        <input class="form-control" type="text" name="IdLibro" value="<%=libro.IdLibro%>" required readonly />
                        <br />
                        <label>Titulo:</label>
                        <input class="form-control" type="text" name="Titulo" value="<%=libro.Titulo%>" required />
                        <br />
                        <label>Autor:</label>
                        <input class="form-control" type="text" name="Autor" value="<%=libro.Autor%>" required />
                        <br />
                        <label>Descricpión:</label>
                        <textarea class="form-control" name="Descripcion" required><%=libro.Descripcion%></textarea>
                        <br />
                        <label>Total de páginas:</label>
                        <input class="form-control" type="number" name="TotalPaginas" value="<%=libro.TotalPaginas%>" required />
                        <br />
                        <label>Precio:</label>
                        <input class="form-control" type="text" name="Precio" value="<%=libro.Precio%>" required />
                        <br />
                        <button class="btn btn-primary btn-block" type="submit">Modificar</button>
                    </form>
            <%
                }
                else
                {
                    Response.Write("<br><br><a class='btn btn-primary btn-block' href='../Default.aspx'>Regresar</a>");
                }
            %>
        </div>
    </div>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="../js/jquery-3.3.1.js"></script>
    <script src="../js/bootstrap.min.js"></script>
</body>
</html>
