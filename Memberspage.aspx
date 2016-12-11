<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Memberspage.aspx.cs" Inherits="Memberspage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div>
    <br/>
        <asp:Table ID="Table1" runat="server" BorderWidth="1px" BorderStyle="Groove" GridLines="Both" ToolTip="They may be old, but somebody out there still wants 'em" Width="599px" Caption="Your items currently for sale">
            <asp:TableHeaderRow ID="tHed">
                <asp:TableHeaderCell Scope="Column" Text="Name" />
                <asp:TableHeaderCell Scope="Column" Text="Type" />
                <asp:TableHeaderCell Scope="Column" Text="Image" />
            </asp:TableHeaderRow>
        </asp:Table>
         
        
       
        
    <asp:Label ID="prNameLabel" runat="server" Text="Product Name: "></asp:Label>
    <asp:TextBox ID="prName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nameRequiredFieldValidator" runat="server" ErrorMessage="Name field may not be left empty" ControlToValidate="prName" ForeColor="Red"></asp:RequiredFieldValidator>      
    <br />
    <asp:Label ID="prTypeLabel" runat="server" Text="Product Type: "></asp:Label>
    <asp:DropDownList ID="prTypeDropDownList" runat="server">
        <asp:ListItem>none</asp:ListItem>
        <asp:ListItem>Shiny Rock</asp:ListItem>
        <asp:ListItem>Soap-on-a-Rope</asp:ListItem>
        <asp:ListItem>Welsh Person</asp:ListItem>
        <asp:ListItem>Shoe Contents</asp:ListItem>
    </asp:DropDownList>
        <asp:RequiredFieldValidator ID="prDDLRequiredFieldValidator" runat="server" ErrorMessage="Must choose a product type" ControlToValidate="prTypeDropDownList" ForeColor="Blue" InitialValue="none"></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:FileUpload ID="picFileUpload" runat="server" />
        <asp:Label ID="picUpLabel" runat="server" Text=""></asp:Label>
        <asp:RequiredFieldValidator ID="picRequiredFieldValidator" runat="server" ErrorMessage="Must upload a picture" ControlToValidate="picFileUpload" ForeColor="Purple" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <asp:Image ID="inImage" runat="server" Height="135px" Width="157px" />
        <br />
<asp:Button ID="saveButton" runat="server" Text="submit" OnClick="saveButton_Click" />
    </div>

    <%--submit deal--%>
   <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 center-block">
                <asp:Label ID="SellingLabel" runat="server" Text="My Listed Items"></asp:Label>
                <br />
               <asp:Button ID="Button1" runat="server" Text="Submit a Deal" OnClick="Button1_Click" />
                <br />
                </div>
            </div>
        </div>
   
</asp:Content>
