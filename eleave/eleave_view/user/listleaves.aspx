<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listleaves.aspx.cs" Inherits="eleave_view.user.listleaves" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function success() {
        swal({
            title: 'Success!',
            text: 'Your request has been succesfully Updated',
            type: 'success'
            });
    }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong',
                type: 'error'
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">                            
<h1>Leaves<small><a href="leaveapply.aspx"> Request Leave</a></small></h1>                                 
</div>
    <div class="table-responsive">
        <asp:GridView ID="grd_leaves" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="lid" ClientIDMode="Static" OnPreRender="grd_leaves_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="req_date" HeaderText="Applied On" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" />
                <asp:BoundField DataField="rej_reason" HeaderText="Reject Reason" />
                <asp:BoundField DataField="stat" HeaderText="Status" />
                <asp:TemplateField HeaderText="Operation">
                    <ItemTemplate>
                        <asp:Button ID="btncancel" runat="server" CssClass="btn btn-bricky" OnClick="btncancel_Click" Text="Cancel" Visible='<%# Isvisible((string)Eval("stat")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnldownload" runat="server" CssClass="clip-download-2" OnClick="lnldownload_Click" ToolTip="Download" Visible='<%# Isenable((string)Eval("stat")) %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
