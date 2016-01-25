<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="status_leave_hr.aspx.cs" Inherits="eleave_view.hr.status_leave_hr" MasterPageFile="~/hr/hr.Master" %>

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
    <style type="text/css">
        .WordWrap {
            overflow-x: auto; /* Use horizontal scroller if needed; for Firefox 2, not needed in Firefox 3 */
             white-space: pre-wrap; /* css-3 */
              white-space: -moz-pre-wrap !important; /* Mozilla, since 1999 */ 
              white-space: -pre-wrap; /* Opera 4-6 */ 
              white-space: -o-pre-wrap; /* Opera 7 */ /* width: 99%; */ 
              word-wrap: break-word; /* Internet Explorer 5.5+ */
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">                            
        <h1>Leaves<small><a href="applyleave_hr.aspx"> Request Leave</a></small></h1>                                 
    </div>
    <div class="table-responsive">
        <asp:GridView ID="status_hr" runat="server" 
            CssClass="table table-bordered table-hover" AutoGenerateColumns="False" 
            DataKeyNames="lid" ClientIDMode="Static" OnPreRender="status_hr_PreRender"  >
            <Columns>
                <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                 <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="req_date" HeaderText="Applied On" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" />
                <asp:BoundField DataField="stat" HeaderText="Status" />
                <asp:TemplateField HeaderText="Operation">
                    <ItemTemplate>
                        <asp:Button ID="btncancel_hr" runat="server" CssClass="btn btn-bricky" Visible='<%# Isvisible((string)Eval("stat")) %>' 
                            Text="Cancel" onclick="btncancel_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="dwnld_hr" runat="server" 
                            Visible='<%# Isenable((string)Eval("stat")) %>' CssClass="clip-download-2" 
                            onclick="LinkButton1_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BorderStyle="None" />
        </asp:GridView>
    </div>

</asp:Content>
