<%@ Page Title="carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp3_Equipo14.Carrito1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--ACÁ MODIFICO--%>
    <asp:GridView ID="dgvCarro" runat="server" CssClass="table table-light table-bordered" AutoGenerateColumns="false" OnRowCommand="dgvCarro_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Nº">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
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
    <%--ACÁ MODIFICO--%>
    <%--

<asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" CssClass="table table-light table-bordered" OnRowCommand="dgvCarrito_RowCommand" DataKeyNames="ID">
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

    --%>
    <p class="fw-bolder">
        Precio Final: $
        <asp:Label ID="lblPrecioFinal" runat="server" Text="Precio Final"></asp:Label>
    </p>


</asp:Content>



