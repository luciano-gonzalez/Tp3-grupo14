<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp3_Equipo14._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inicio</h2>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar por nombre" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtfiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="col-6" style="display:flex; flex-direction: column ; justify-content: flex-end;">
        <div class="mb-3">
           <asp:CheckBox Text="filtro avanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>    
    </div>


    <%if (filtroavanzado)
        {%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="campo" runat="server"></asp:Label>
                <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="ddlcampo" OnSelectedIndexChanged="ddlcampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre"></asp:ListItem>
                    <asp:ListItem Text="Marca"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="criterio" runat="server"></asp:Label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlcriterio"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="filtro" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtfiltroavanzado" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    
        

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <asp:Button Text="Limpiar Filtro" runat="server" CssClass="btn btn-primary" ID="btnlimpiar" OnClick="btnlimpiar_Click" />
            </div>
        </div>
    

    </div>
    <%} %>





    <div class="row row-cols-1 row-cols-md-2 g-4">
        <asp:Repeater ID="repRepeater" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("urlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("_nombre") %></h5>
                            <p class="card-text"><%#Eval("_marca") %>.</p>
                            <p class="card-text"><%#Eval("_descripcion") %>.</p>
                            <section class="row" aria-labelledby="aspnetTitle">
                                <a href="DetallesArticulo.aspx?id=<%#Eval("ID") %>">Ver detalle &raquo; </a>
                            </section>
                            <asp:Button Text="Agregar al carrito" CssClass="btn btn-primary" runat="server" ID="btnCarrito" CommandArgument='<%#Eval("ID") %>' CommandName="Articuloid" OnClick="btnCarrito_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
