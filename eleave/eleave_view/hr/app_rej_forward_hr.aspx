﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app_rej_forward_hr.aspx.cs" MasterPageFile="~/hr/hr.Master" Inherits="eleave_view.hr.app_rej_forward_hr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully updated !',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong !',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errormail() {
            swal({
                title: 'Warning!',
                text: 'Mail Not Sent!',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="approved_hr" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="lid" >
        <Columns>
            <asp:TemplateField HeaderText="No">                
                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name" />
            <asp:BoundField HeaderText="Department" DataField="depname" />
            <asp:BoundField HeaderText="Designation" DataField="desig" />
            <asp:BoundField HeaderText="Leave Type" DataField="ltype" />
            <asp:BoundField HeaderText="Dates Applied" DataField="dates" />                        
            <asp:BoundField HeaderText="Period" DataField="period" />
            <asp:BoundField HeaderText="Reason" DataField="reason" />                       

            <asp:BoundField DataField="idate" HeaderText="idate">
                    <HeaderStyle CssClass="hidden"></HeaderStyle>

                    <ItemStyle CssClass="hidden"></ItemStyle>
                </asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="Email">
                    <HeaderStyle CssClass="hidden"></HeaderStyle>

                    <ItemStyle CssClass="hidden"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Approve">
                
                <ItemTemplate>
                    <asp:LinkButton ID="lnk_appr" runat="server" CssClass="btn btn-green" OnClick="lnk_appr_Click"><i class="glyphicon glyphicon-ok-sign"></i></asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reject">
                
                <ItemTemplate>
                    <asp:LinkButton ID="lnk_reject" runat="server" CssClass="btn btn-bricky" OnClick="lnk_reject_Click"><i class="glyphicon glyphicon-remove-circle"></i></asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>