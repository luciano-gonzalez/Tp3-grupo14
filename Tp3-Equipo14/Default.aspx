<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp3_Equipo14._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
     
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>


    </main>
    <div class="row row-cols-1 row-cols-md-2 g-4">
    <%
        foreach (Dominio.Articulo arti in ListaArticulos)
        {
    %>        
         <div class="col">
          <div class="card">
            <img src="<%:arti.urlImagen %>" class="card-img-top" alt="...">
            <div class="card-body">
              <h5 class="card-title"><%: arti._nombre %></h5>
              <p class="card-text"><%: arti._descripcion %>.</p>
              <a href="DetallesArticulo.aspx?id=<%: arti.ID %>"> Ver detalle </a>
            </div>
          </div>
         </div>
        
    <%   } %>
    </div>
</asp:Content>
