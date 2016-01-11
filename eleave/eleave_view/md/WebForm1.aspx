<%@ Page Title="" Language="C#" MasterPageFile="~/md/md.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="eleave_view.md.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    <script type="text/javascript">
        function successalert() {
            swal({
                title: 'Congratulations!',
                text: 'Your message has been succesfully sent',
                type: 'success'
            });
        }
    </script>
</asp:Content>
