<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Online_Phanmacy_Management_System.Admin.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            margin-top: 50px;
            height: 400px;
            width: 400px;
            display: flex;
            align-content: center;
            justify-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="text-center">
                <h1>ADMIN</h1>
            </div>
            <div class="col-md-12">
                <input id="adminname" runat="server" type="text" placeholder="Username" class="form-control" required />
            </div>
            <div class="col-md-12">
                <input id="adminpass" runat="server" type="password" placeholder="Password" class="form-control" required />
            </div>
            <div class="col-md-12">
                <asp:Button ID="AdminBtn" runat="server" Text="Login" CssClass="btn btn-success" Width="100%" OnClick="AdminBtn_Click" />
            </div>
            <div class=" text-end">
                <asp:Label ID="msgadmin" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
