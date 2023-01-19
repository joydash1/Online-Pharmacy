<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Online_Phanmacy_Management_System.Admin.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"
        rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"
        crossorigin="anonymous" />
    <!-- bootstrap5 dataTables css cdn -->
    <link
        rel="stylesheet"
        href="https://cdn.datatables.net/1.11.3/css/dataTables.bootstrap5.min.css" />
    <style>
        .contaier {
            display: flex;
            align-content: center;
            justify-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contaier" style="margin-top: 50px;">

        <div class="row">

            <div class="col-md-12" style="margin-bottom: 15px">
                <input id="categoryname" runat="server" class="form-control" placeholder="Category Name"
                    required="required" />
            </div>
            <div>
                <asp:Button ID="Categorybtn" runat="server" Text="Insert" Width="100%" CssClass="btn btn-success" OnClick="Categorybtn_Click" />
                <asp:Button ID="CatUpdatebtn" runat="server" Text="Update" Width="100%" CssClass="btn btn-info" OnClick="CatUpdatebtn_Click" />

            </div>
            <div style="margin-top: 10px">
                <asp:Label ID="catmsg" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container" style="margin-top: 50px; background-color: white;">
        <asp:Repeater ID="CategoryRepeater" runat="server" OnItemCommand="CategoryRepeater_ItemCommand" OnItemDataBound="CategoryRepeater_ItemDataBound">
            <HeaderTemplate>
                <table id="datatable" class="table table-responsive table-striped table-info table-bordered table-hover">
                    <div class="text-center">
                        <h1>Category List</h1>
                        <hr />
                    </div>
                    <tr class="active-row">
                        <th scope="col">Product Number</th>
                        <th scope="col">Category Name</th>
                        <th scope="col">Action</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>

                <tr class="active-row">
                    <td>
                        <asp:Label ID="lblcatid" runat="server" Text='<%#Eval("categoryId")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblcatname" runat="server" Text='<%#Eval("CategoryName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="Editbtn" runat="server" CssClass=" badge bg-primary"
                            CommandArgument='<%#Eval("categoryId") %>' CommandName="edit">
                               <i class="fas fa-pencil-alt" style="width:30px;"></i>                     
                        </asp:LinkButton>

                        <asp:LinkButton ID="Deletebtn" runat="server" Text="Delete" CssClass="badge bg-danger"
                            CommandArgument='<%#Eval("categoryId") %>' CommandName="delete"
                            OnClientClick="return confirm('Do you want to delete this Category?');">
                        <i class="fa-solid fa-trash" style="width:30px;"></i>                         
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
