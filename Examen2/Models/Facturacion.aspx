<%@ Page Title="Facturación" Language="C#" MasterPageFile="~/Models/principal.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="Examen2.Controllers.Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .form-container {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .btn-facturar {
            margin-top: 30px;
        }

        .total-venta {
            margin-top: 20px;
            font-weight: bold;
            font-size: 18px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-3">
            <h2 class="mb-4 text-center">Facturación de Artículos</h2>
            <div class="form-container">
                <div class="row">
                    <div class="col-md-3 mb-3">
                        <label for="txtCodigoArticulo">Código del Artículo</label>
                        <asp:TextBox ID="txtCodigoArticulo" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCodigoArticulo_TextChanged" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3 mb-3">
                        <label for="txtCategoria">Categoría</label>
                        <asp:TextBox ID="txtCategoria" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3 mb-3">
                        <label for="txtCodigoVendedor">Código Vendedor</label>
                        <asp:TextBox ID="txtCodigoVendedor" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 mb-3">
                        <label for="txtNombreArticulo">Nombre del Artículo</label>
                        <asp:TextBox ID="txtNombreArticulo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2 mb-3">
                        <label for="txtExistencia">Existencia</label>
                        <asp:TextBox ID="txtExistencia" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2 mb-3">
                        <label for="txtPrecio">Precio</label>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2 mb-3">
                        <label for="txtCantidad">Cantidad</label>
                        <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2 mb-3">
                        <asp:Button ID="btnFacturar" CssClass="btn btn-success btn-facturar" runat="server" Text="Facturar" OnClick="btnFacturar_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblTotalVenta" CssClass="total-venta text-success" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

