<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="Online_Phanmacy_Management_System.Admin.Seller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <asp:Label ID="msgsel" runat="server" Visible="false" CssClass="form-label" ForeColor="YellowGreen"></asp:Label>
        <div class="row" style="width: 500px;">
            <div class="text-center" style="margin-bottom: 10px">
                <h2>Shop Keeper</h2>
            </div>
            <div class="col-md-6" style="margin-bottom: 15px">
                <input id="sellername" runat="server" class="form-control" placeholder="Seller Name"
                    required="required" />
            </div>
            <div class="col-md-6" style="margin-bottom: 15px">
                <input id="selleremail" runat="server" class="form-control" type="email" placeholder="seller Email"
                    required="required" />
            </div>
            <div class="col-md-6" style="margin-top: 15px">
                <input id="sellerpass" runat="server" class="form-control" placeholder="Password"
                    required="required" />
            </div>
            <div class="col-md-6" style="margin-top: 15px">
                <input id="sellerdob" runat="server" class="form-control" type="date"
                    required="required" />
                <span>Date Of Birth</span>
            </div>
            <div class="col-md-6" style="margin-top: 15px">
                <asp:DropDownList ID="GenderDropDownList" runat="server" CssClass="form-control">
                    <asp:ListItem  Selected="True">Select Your Gender</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-6" style="margin-top: 15px">
                <input id="sellerAddress" runat="server" class="form-control" placeholder="Seller Address"
                    required="required" />

            </div>

            <div class="col-md-12" style="margin-top: 20px">
                <asp:Button ID="SellerInsertBtn" runat="server" Text="Insert" CssClass="btn btn-success" Width="100%"  OnClick="SellerInsertBtn_Click"/>
                <asp:Button ID="SellerEditBtn" runat="server" Text="Update" CssClass="btn btn-info" Width="100%" OnClick="SellerEditBtn_Click" />

            </div>
        </div>
    </div>
    <%--  -------------------------Datatable ---------------------%>
    <div class=" container-fluid" style="margin-top: 50px; width: 100%;">
        <asp:Repeater ID="SellerRepeater" runat="server" OnItemCommand="SellerRepeater_ItemCommand">

            <HeaderTemplate>
                <table class="table table-responsive table-info table-bordered table-hover">
                    <div class="text-center">
                        <h1>Shop Keeper Information List</h1>
                        <hr />
                    </div>
                    <tr class="active-row">
                        <th scope="col">ID</th>
                        <th scope="col">Name</th>
                        <th scope="col">Email</th>
                        <th scope="col">Password</th>
                        <th scope="col">Date Of Birth</th>
                        <th scope="col">Gender</th>
                        <th scope="col">Address</th>
                        <th scope="col">Action</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>

                <tr class="active-row">     
                     <td>
                        <asp:Label ID="sellerIDlbl" runat="server" Text='<%#Eval("sellerId")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="sellernamelbl" runat="server" Text='<%#Eval("sellerName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="selleremaillbl" runat="server" Text='<%#Eval("sellerEmail")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="sellerpasslbl" runat="server" Text='<%#Eval("sellerPas")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="sellerDOBlbl" runat="server" Text='<%#Eval("sellerDOB")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="sellergenderlbl" runat="server" Text='<%#Eval("sellerGender")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="selleraddresslbl" runat="server" Text='<%#Eval("sellerAddress")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="Editbtn" runat="server" CssClass=" badge bg-primary"
                            CommandArgument='<%#Eval("sellerId") %>' CommandName="edit">
                               <i class="fas fa-pencil-alt" style="width:30px;"></i>                     
                        </asp:LinkButton>

                        <asp:LinkButton ID="Deletebtn" runat="server" Text="Delete" CssClass="badge bg-danger"
                            CommandArgument='<%#Eval("sellerId") %>' CommandName="delete"
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
