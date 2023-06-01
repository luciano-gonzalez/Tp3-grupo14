<%@ Page Title="carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp3_Equipo14.Carrito1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" CssClass="table table-light table-bordered" OnRowDeleting="gridView1_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="_nombre" />
            <asp:BoundField HeaderText="Precio Unitario" DataField="_precio" />
            <asp:ImageField DataImageUrlField="urlImagen" HeaderText="" ControlStyle-Width="100" ControlStyle-Height="100" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <asp:Label ID="Label1" runat="server" Text="Precio Final"></asp:Label>

</asp:Content>