<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Adminspage.aspx.cs" Inherits="Adminspage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">

            <div class="col-md-6 center-block">
                <asp:Label runat="server" Text="List of registered users:" Font-Size="30px" Font-Bold="True"></asp:Label>

                <br/>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="userId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True"/>
                        <asp:BoundField DataField="userId" HeaderText="userId" InsertVisible="False" ReadOnly="True" SortExpression="userId"/>
                        <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName"/>
                        <asp:BoundField DataField="pwd" HeaderText="pwd" SortExpression="pwd"/>
                        <asp:CommandField ShowDeleteButton="True"/>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BorderStyle="Double" />
                </asp:GridView>
                    <asp:Button ID="createAdminButton" runat="server" Text="Elevate selected user to admin" OnClick="createAdminButton_Click" />
                <asp:Button ID="viewUserButton" runat="server" Text="View/edit user profile" />
                <br/>
                <asp:Button ID="Button1" runat="server" Text="Reset the list" OnClick="Button1_Click"/>
                &nbsp;
                    &nbsp;&nbsp;
                <br/>
                <br/>
                <br/>
                <br/>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [admins] WHERE [adminId] = @original_adminId AND [userName] = @original_userName AND [pwd] = @original_pwd" InsertCommand="INSERT INTO [admins] ([userName], [pwd]) VALUES (@userName, @pwd)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [admins]" UpdateCommand="UPDATE [admins] SET [userName] = @userName, [pwd] = @pwd WHERE [adminID] = @original_adminID AND [userName] = @original_userName AND [pwd] = @original_pwd">
                    <DeleteParameters>
                        <asp:Parameter Name="original_adminID" Type="Int32"/>
                        <asp:Parameter Name="original_userName" Type="String"/>
                        <asp:Parameter Name="original_pwd" Type="String"/>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="userName" Type="String"/>
                        <asp:Parameter Name="pwd" Type="String"/>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="userName" Type="String"/>
                        <asp:Parameter Name="pwd" Type="String"/>
                        <asp:Parameter Name="original_adminID" Type="Int32"/>
                        <asp:Parameter Name="original_userName" Type="String"/>
                        <asp:Parameter Name="original_pwd" Type="String"/>
                    </UpdateParameters>
                </asp:SqlDataSource>
                <br/>


                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Users] WHERE [userId] = @original_userId AND [userName] = @original_userName AND [pwd] = @original_pwd" InsertCommand="INSERT INTO [Users] ([userName], [pwd]) VALUES (@userName, @pwd)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Users] SET [userName] = @userName, [pwd] = @pwd WHERE [userId] = @original_userId AND [userName] = @original_userName AND [pwd] = @original_pwd">
                    <DeleteParameters>
                        <asp:Parameter Name="original_userId" Type="Int32"/>
                        <asp:Parameter Name="original_userName" Type="String"/>
                        <asp:Parameter Name="original_pwd" Type="String"/>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="userName" Type="String"/>
                        <asp:Parameter Name="pwd" Type="String"/>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="userName" Type="String"/>
                        <asp:Parameter Name="pwd" Type="String"/>
                        <asp:Parameter Name="original_userId" Type="Int32"/>
                        <asp:Parameter Name="original_userName" Type="String"/>
                        <asp:Parameter Name="original_pwd" Type="String"/>
                    </UpdateParameters>
                </asp:SqlDataSource>

                <asp:Label runat="server" Text="List of admins:" Font-Size="30px" Font-Bold="True"></asp:Label>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource3">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" ShowSelectButton="True"/>
                        <asp:CommandField ShowEditButton="True"/>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="col-md-6 center-block">
                    <br />
                    <br />
                </div>
                

            </div>

        </div>


    </div>
</asp:Content>