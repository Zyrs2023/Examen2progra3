<%@ Page Title="" Language="C#" MasterPageFile="~/Models/principal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Examen2.Models.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       
        html, body, #container {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            overflow: hidden;
        }

        #container img {
            width: 100%;
            height: 100%;
            object-fit: cover;
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="container">
    
        <img src="../Imagenes/1985-Portada-punto-de-venta.jpg" />
    </div>
</asp:Content>
