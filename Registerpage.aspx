<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registerpage.aspx.cs" Inherits="Registerpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form2" runat="server">
    <div>
        <asp:Label ID="Label3" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="TextBox2"  runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button1_Click" />
    </div>
    </form>
</asp:Content>



