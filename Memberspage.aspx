<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Memberspage.aspx.cs" Inherits="Memberspage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 center-block">

                <asp:Label runat="server" Text="My Profile" Font-Size="40px" Font-Bold="True"></asp:Label> <br/><br/>


            </div>

            <div class="col-md-4">

                <asp:Image ID="userImg" runat="server" Width="200px"/>
                <br/>
                <br/>

                <asp:Label ID="Label2" runat="server" Font-Size="20px" Font-Bold="True" Text="Registered User Benefits:"></asp:Label> <br/> <br/>
                <asp:Button ID="Button3" runat="server" Text="Submit a Deal" OnClick="Button1_Click"/> <br/>
                <asp:Button ID="Button4" runat="server" Text="Premium deals" OnClick="Button2_Click"/>

            </div>
            <div class="col-md-4">

                <asp:Label ID="name" Font-Bold="True" runat="server" Font-Size="30px" Text=""></asp:Label>
                <asp:Label ID="surname" Font-Bold="True" Font-Size="30px" runat="server" Text=""></asp:Label>
                <br/>
                <br/>
                <asp:Label ID="Label3" Font-Size="18px" runat="server" Text="Username:"></asp:Label>
                <asp:Label ID="username" Font-Size="18px" runat="server" Text=""></asp:Label>
                <br/>
                <asp:Label ID="Label4" runat="server" Text="Password:" Font-Size="18px"></asp:Label>
                <asp:Label ID="password" runat="server" Text="" Font-Size="18px"></asp:Label>
                <br/>
                <asp:Label ID="Label5" Font-Size="18px" runat="server" Text="Gender:"></asp:Label>
                <asp:Label ID="gender" Font-Size="18px" runat="server" Text=""></asp:Label>
                <br/>
                <asp:Label ID="Label6" Font-Size="18px" runat="server" Text="Email Address:"></asp:Label>
                <asp:Label ID="emailAddress" Font-Size="18px" runat="server" Text="Label"></asp:Label>


                <br/>


            </div>
        </div>
    </div>

</asp:Content>