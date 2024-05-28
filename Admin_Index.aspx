<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Admin_Index.aspx.cs" Inherits="New_Project.Admin_Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
        .auto-style2 {
            height: 27px;
            width: 346px;
        }
        .auto-style3 {
            width: 346px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Add_Category.aspx" Font-Bold="False" Font-Italic="False">Add Category</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Edit Category.aspx">Edit Category</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Add_Product.aspx">Add Product</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Edit_Product.aspx">Edit Product</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/View_FeedBack.aspx">View FeedBack</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
