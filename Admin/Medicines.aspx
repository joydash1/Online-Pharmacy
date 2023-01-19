<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Medicines.aspx.cs" Inherits="Online_Phanmacy_Management_System.Admin.Medicines" %>

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
        <asp:Label ID="medlbl" runat="server" CssClass="form-label" Visible="false" ForeColor="YellowGreen"></asp:Label>
        <div class="row" style="width: 500px;">
            <div class="text-center">
                <h3>Medicine</h3>
            </div>
            <div class="col-md-6" style="margin-bottom: 15px">
                <input id="medcode" runat="server" class="form-control" placeholder="Medicine code"
                    required="required" />
            </div>
            <div class="col-md-6" style="margin-bottom: 15px">
                <input id="medname" runat="server" class="form-control" placeholder="Medicine Name"
                    required="required" />
            </div>
            <div class="col-md-6">
                <input id="medprice" runat="server" class="form-control" placeholder="Medicine Price"
                    required="required" />
            </div>
            <div class="col-md-6">
                <input id="medstock" runat="server" class="form-control" placeholder="Medicine Stock"
                    required="required" />
            </div>
            <div class="col-md-6" style="margin-top: 15px">
                 <span>Expairy Date</span>
                <input id="medexpairedate" runat="server" class="form-control" type="date" placeholder=""
                    required="required" />
               
            </div>
            <div class="col-md-6" style="margin-top: 15px">
                <span>Medicine Category</span>
                <asp:DropDownList ID="CatDropDownlist" runat="server" CssClass="form-control">
                    <asp:ListItem>Select Medicine Category</asp:ListItem>
                </asp:DropDownList>
               
            </div>

            <div class="col-md-12" style="margin-top: 20px">
                <asp:Button ID="MedInsertBtn" runat="server" Text="Insert" CssClass="btn btn-success" Width="100%"  OnClick="MedInsertBtn_Click" />
                 <asp:Button ID="MedUpdateBtn" runat="server" Text="Update" CssClass="btn btn-info" Width="100%"  OnClick="MedUpdateBtn_Click" />
            </div>
        </div>
    </div>
    <%--  -------------------------Datatable ---------------------%>
    <div class=" container-fluid" style="margin-top: 50px; width: 100%;">
        <asp:Repeater ID="MedicineRepeater" runat="server" OnItemCommand="MedicineRepeater_ItemCommand">

            <HeaderTemplate>
                <table class="table table-responsive table-info table-bordered table-hover">
                     <div class="text-center">
                        <h1>Medicine List</h1>
                        <hr />
                    </div>
                    <tr class="active-row">
                        <th scope="col">Medicine Code</th>
                        <th scope="col">Medicine Name</th>
                        <th scope="col">Medicine Price</th>
                        <th scope="col">Medicine Stock (piece)</th>
                        <th scope="col">Expairy Date</th>
                        <th scope="col">Category Name</th>
                        <th scope="col">Action</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>

                <tr class="active-row">
                    <td>
                        <asp:Label ID="lblmedcode" runat="server" Text='<%#Eval("medCode")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblmedname" runat="server" Text='<%#Eval("medName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblmedeprice" runat="server" Text='<%#Eval("medPrice")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblmedstock" runat="server" Text='<%#Eval("medStock")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblmedexp" runat="server" Text='<%#Eval("medExpDate")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblmedcat" runat="server" Text='<%#Eval("categoryId")%>'></asp:Label>
                    </td>
                    
                    <td>
                        <asp:LinkButton ID="Editbtn" runat="server" CssClass=" badge bg-primary"
                            CommandArgument='<%#Eval("medID") %>' CommandName="edit">
                               <i class="fas fa-pencil-alt" style="width:30px;"></i>                     
                        </asp:LinkButton>

                        <asp:LinkButton ID="Deletebtn" runat="server" Text="Delete" CssClass="badge bg-danger"
                            CommandArgument='<%#Eval("medID") %>' CommandName="delete"
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
