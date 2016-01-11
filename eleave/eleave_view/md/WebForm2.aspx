<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="eleave_view.md.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/plugins/swal/sweetalert.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Showalert() {
            swal({
                title: 'Congratulations!',
                text: 'Your message has been succesfully sent',
                type: 'success'
            });
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
    </form>
    
    <script src="../assets/js/jquery.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/swal/sweetalert.min.js" type="text/javascript"></script>
</body>

</html>
