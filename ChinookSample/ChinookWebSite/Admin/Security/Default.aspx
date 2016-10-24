<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="row jumbotron">
        <h1>User and Role Administration</h1>
    </div>

    <div class="row">
        <div class="col-md-12">
            <!-- Nav Tabs -->
            <ul class="nav nav-tabs">
                <li class="active"><a href="#users" data-toggle="tab">Users</a></li>
                <li><a href="#roles" data-toggle="tab">Roles</a></li>
                <li><a href="#unregistered" data-toggle="tab">Unregistered Users</a></li>
            </ul>
            <!-- Tab content area -->
            <div class="tab-contnt">

                <!-- User tab -->
                <div class="tab-pane fade in active" id="users">
                    <h2>Users</h2>
                </div> 


                <!-- Role tab -->
                <div class="tab-pane fade" id="roles">
                    <%--DataKeyNames comtains the considered key field that is being used in insert, update, and delete. RefreshAll will call a genaric method in my code behind that will cause the ODS sets to re-bind thier data--%>
                    <asp:ListView ID="RoleListView" runat="server" DataSourceID="RoleListViewODS" ItemType="ChinookSystem.Security.RoleProfile" InsertItemPosition="LastItem" DataKeyNames="RoleId" OnItemInserted="RefreshAll" OnItemDeleted="RefreshAll">

                        <EmptyDataTemplate>
                            <span>No Security Roles have been set up</span>
                        </EmptyDataTemplate>

                        <LayoutTemplate>
                            <div class="row bginfo">
                                <div class="col-sm-3 h4">Action</div>
                                <div class="col-sm-3 h4">RoleName</div>
                                <div class="col-sm-6 h4">Users</div>
                            </div>
                            <div class="row" id="itemPlaceholder" runat="server">
                                
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:LinkButton ID="RemoveRole" runat="server" CommandName="Delete">Remove</asp:LinkButton>
                                </div>
                                <div class="col-sm-3">
                                    <%# Item.RoleName %>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Repeater ID="RoleUsers" runat="server" DataSource="<%#Item.UserNames%>" ItemType="System.String">
                                        <ItemTemplate>
                                            <%# Item %>
                                        </ItemTemplate>
                                        <SeparatorTemplate>, </SeparatorTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>

                        <InsertItemTemplate>
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:LinkButton ID="InsertRole" runat="server" CommandName="Insert">Insert</asp:LinkButton> 
                                    <asp:LinkButton ID="Cancel" runat="server">Cancel</asp:LinkButton>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="RoleName" runat="server" Text='<%# BindItem.RoleName %>' placeholder="RoleName"></asp:TextBox>
                                </div>
                            </div>
                        </InsertItemTemplate>

                    </asp:ListView>
                    <asp:ObjectDataSource ID="RoleListViewODS" runat="server" DataObjectTypeName="ChinookSystem.Security.RoleProfile" DeleteMethod="RemoveRole" InsertMethod="AddRole" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllRoles" TypeName="ChinookSystem.Security.RoleManager"></asp:ObjectDataSource>
                </div> 


                <!-- Unregistered User tab -->
                <div class="tab-pane fade" id="unregistered">
                    <h2>Unregistered</h2>
                </div> 

            </div>
        </div>
    </div>

</asp:Content>

