<%@ Page Title="" Language="C#" MasterPageFile="~/Models/principal.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Examen2.Models.articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
       
        .caja-sombreada {
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="caja-sombreada p-4">
                    <h2 class="mb-4 text-center">Gestión de Artículos</h2>
                    <form id="formArticulos" runat="server">
                        <div class="form-group">
                            <label for="txtCodigo">Código:</label>
                            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtNombre">Nombre:</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtPrecio">Precio:</label>
                            <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtCantidad">Cantidad:</label>
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary mr-2" Text="Agregar" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-info mr-2" Text="Modificar" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger mr-2" Text="Eliminar" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-secondary" Text="Consultar" OnClick="btnConsultar_Click" />
                        <asp:GridView ID="GridViewArticulos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped mt-4">
                            <Columns>
                                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            </Columns>
                        </asp:GridView>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
