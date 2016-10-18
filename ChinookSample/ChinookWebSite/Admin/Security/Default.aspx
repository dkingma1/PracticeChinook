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
                    <h2>Roles</h2>
                </div> 

                <!-- Unregistered User tab -->
                <div class="tab-pane fade" id="unregistered">
                    <h2>Unregistered</h2>
                </div> 

            </div>
        </div>
    </div>

</asp:Content>

