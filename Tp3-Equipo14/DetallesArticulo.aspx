<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallesArticulo.aspx.cs" Inherits="Tp3_Equipo14.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-uppercase fw-bold m-5">Detalles del producto</h2>
    <div class="container my-5 d-flex justify-content-center">
        <asp:Image runat="server" ID="imgImagen" Width="80%" />
    </div>
    <div class="col-8 container">
        <table class="table table-dark table-bordered">
            <tbody>
                <tr>
                    <th scope="row">Nombre</th>
                    <td>
                        <asp:Label runat="server" ID="lblNombre"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Código</th>
                    <td>
                        <asp:Label runat="server" ID="lblCodigo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Marca</th>
                    <td>
                        <asp:Label runat="server" ID="lblMarca"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Precio</th>
                    <td>
                        <asp:Label runat="server" ID="lblPrecio"></asp:Label></td>
                </tr>
                <tr>
                    <th scope="row">Descripción:</th>
                    <td>
                        <asp:Label runat="server" ID="lblDescripcion"></asp:Label></td>
                </tr>

            </tbody>

        </table>
    </div>
    <!--
    <asp:GridView FooterStyle-Wrap="true" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" runat="server" ID="dgvArticulo" CssClass="table table-dark table-bordered table-responsive" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="ID" />
            <asp:BoundField HeaderText="Código" DataField="_codArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="_nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="_descripcion" />
            <asp:BoundField HeaderText="Id" DataField="ID" />
            <asp:BoundField HeaderText="Precio" DataField="_precio" />

        </Columns>
    </asp:GridView>


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
            <asp:Image ImageUrl="<%=urlImagen%>" runat="server" ID="imgArticulo" Width="80%" />
        </div>
    </div>

        -->


</asp:Content>
