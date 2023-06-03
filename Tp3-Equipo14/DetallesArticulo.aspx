<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallesArticulo.aspx.cs" Inherits="Tp3_Equipo14.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles del producto</h2>
    

   
        <div class="row">
            <div class="col-6">
            <div class="mb-3">
                <label for="txtid" class="form-label">id</label>
                <asp:TextBox ID="Txtid" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Txtcodart" class="form-label">Codigo articulo</label>
                <asp:TextBox ID="Txtcodart" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="Txtnombre" class="form-label">Nombre del articulo</label>
                <asp:TextBox ID="Txtnombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Txtdescripcion" class="form-label">Descripcion del articulo</label>
                <asp:TextBox ID="Txtdescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Txtcategoria" class="form-label">Categoria del articulo</label>
                <asp:TextBox ID="Txtcategoria" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Txtmarca" class="form-label">Marca del articulo</label>
                <asp:TextBox ID="Txtmarca" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Txtprecio" class="form-label">Precio Articulo</label>
                <asp:TextBox ID="Txtprecio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
          </div>
               
            <div class="col-6">
               <asp:Image imageUrl="<%=urlImagen%>" runat="server" ID="imgArticulo" Width="80%"/>
            </div>
        </div>
    


</asp:Content>
