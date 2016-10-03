<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstSample.aspx.cs" Inherits="Pages_FirstSample" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br /><br />

    <h1>Entity vs Linq to Entity Query</h1>
    <br /><br />

    <asp:TextBox ID="YearQuery" runat="server"></asp:TextBox>
    <br /><br />

    <asp:Button ID="SubmitQuery" runat="server" Text="Submit" />
    <br /><br />

    <asp:GridView ID="EntityFrameworkList" runat="server" AutoGenerateColumns="False" DataSourceID="EntityFrameworkODS">
        <Columns>
            <asp:BoundField DataField="ArtistId" HeaderText="ArtistId" SortExpression="ArtistId"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="EntityFrameworkODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_ListAll" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    <br /><br />

    <asp:GridView ID="LinqToEntityList" runat="server" AutoGenerateColumns="False" DataSourceID="LinqToEntityODS">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="TotalTracksforAlbum" HeaderText="TotalTracksforAlbum" SortExpression="TotalTracksforAlbum"></asp:BoundField>
            <asp:BoundField DataField="TotalPriceForalbumtracks" HeaderText="TotalPriceForalbumtracks" SortExpression="TotalPriceForalbumtracks"></asp:BoundField>
            <asp:BoundField DataField="AverageTrackLengthA" HeaderText="AverageTrackLengthA" SortExpression="AverageTrackLengthA"></asp:BoundField>
            <asp:BoundField DataField="AverageTrackLengthB" HeaderText="AverageTrackLengthB" SortExpression="AverageTrackLengthB"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="LinqToEntityODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ArtistAlbums_Get" TypeName="ChinookSystem.BLL.ArtistController">
        <SelectParameters>
            <asp:ControlParameter ControlID="YearQuery" PropertyName="Text" DefaultValue="2008" Name="year" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

