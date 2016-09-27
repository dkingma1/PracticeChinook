<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstSample.aspx.cs" Inherits="Pages_FirstSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Entity vs Linq to Entity Query</h1>
    <asp:GridView ID="EntityFrameworkList" runat="server"></asp:GridView>
    <asp:GridView ID="LinqToEntityList" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="EntityFrameworkODS" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LinqToEntityODS" runat="server"></asp:ObjectDataSource>
</asp:Content>

