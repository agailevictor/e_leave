<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app_rej.aspx.cs" Inherits="eleave_view.md.app_rej" MasterPageFile="~/md/md.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully updated !',
                type: 'success'
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong !',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            swal({
                title: 'Warning!',
                text: 'Atleast Select One record !',
                type: 'warning'
            });
        }
    </script>
    <script type="text/javascript">
        var gridViewId = '#<%= grd_app_rej.ClientID %>';
        function checkAll(selectAllCheckbox) {
            //get all checkboxes within item rows and select/deselect based on select all checked status
            //:checkbox is jquery selector to get all checkboxes
            $('td :checkbox', gridViewId).prop("checked", selectAllCheckbox.checked);
        }
        function unCheckSelectAll(selectCheckbox) {
            //if any item is unchecked, uncheck header checkbox as well
            if (!selectCheckbox.checked)
                $('th :checkbox', gridViewId).prop("checked", false);
        }
    </script>
    <style type="text/css">
        .hidden {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Approve / Reject Leave</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_app_rej" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="lid" ClientIDMode="Static" OnPreRender="grd_app_rej_PreRender">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" onclick="checkAll(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" onclick="unCheckSelectAll(this);" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="depname" HeaderText="Department" />
                <asp:BoundField DataField="desig" HeaderText="Designation" />
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" />
                <asp:BoundField DataField="period" HeaderText="Period" />
                <asp:BoundField DataField="reason" HeaderText="Reason" />
                <asp:BoundField DataField="med_path" HeaderText="File Path" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                    <HeaderStyle CssClass="hidden"></HeaderStyle>

                    <ItemStyle CssClass="hidden"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Medical Certificate">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_dwn" runat="server" Visible='<%# Isenable((string)Eval("ltype")) %>' CssClass="clip-download-2" OnClick="lnk_dwn_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Approve">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkforward" runat="server" CssClass="btn btn-green" OnClick="lnkforward_Click"><i class="glyphicon glyphicon-ok-sign"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reject">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkreject" runat="server" CssClass="btn btn-bricky" OnClick="lnkreject_Click"><i class="glyphicon glyphicon-remove-circle"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
    <div class="table-responsive">
        <table class="table-responsive">
            <tr>
                <td>
                    <asp:Button ID="btnaccept" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnaccept_Click"/></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnreject" runat="server" Text="Reject" CssClass="btn btn-orange" OnClick="btnreject_Click"/></td>
            </tr>
        </table>
    </div>
</asp:Content>
