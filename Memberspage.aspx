<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Memberspage.aspx.cs" Inherits="Memberspage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 center-block">
                <asp:Button ID="Button1" runat="server" Text="Submit a Deal" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Premium deals" OnClick="Button2_Click" />
            
            
            </div>
            </div>
        </div>
   
</asp:Content>