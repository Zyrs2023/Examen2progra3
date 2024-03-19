<%@ Page Title="" Language="C#" MasterPageFile="~/Models/principal.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Examen2.Models.Reporte" %>

<%@ Import Namespace="Examen2.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
       
        .caja-sombreada {
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin-bottom: 30px;
            background-color: #fff;
        }
        .titulo-centrado {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="titulo-centrado mb-4">Reportes</h2> 
            <div class="caja-sombreada">
                
                <h3 class="titulo-centrado mb-4">Artículos</h3> 
                <asp:GridView ID="GridViewArticulos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
               
                <div class="col-md-6">
                    <div class="caja-sombreada">
                        <h3 class="titulo-centrado mb-4">Categorías</h3> 
                        <asp:GridView ID="GridViewCategorias" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
               
                <div class="col-md-6">
                    <div class="caja-sombreada">
                        <h3 class="titulo-centrado mb-4">Vendedores</h3> 
                        <asp:GridView ID="GridViewVendedores" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>

    
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
