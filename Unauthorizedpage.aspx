<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Unauthorizedpage.aspx.cs" Inherits="Unauthorizedpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">

            <div class="col-md-6 center-block">
    <asp:image id="img" runat="server" imageurl="http://www.wphelpline.com/wp-content/uploads/forbidden-346x315.jpg" />
                <asp:Label ID="Label1" Font-Size="20px" runat="server" Text="access denied: you don't have permission to access on this webpage"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Loginpage.aspx">click here to sign in</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Registerpage.aspx">dont have an account? click here to register</asp:HyperLink>
    
            </div> 
            </div>
        </div>
</asp:Content>

