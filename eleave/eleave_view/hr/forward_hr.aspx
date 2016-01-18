<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forward_hr.aspx.cs" Inherits="eleave_view.hr.forward_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page-header">
 <h1>Forward Leave</h1>
</div>
    <div class="table-responsive">
        <asp:GridView ID="grd_forward" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="lid">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" />
                <asp:BoundField DataField="period" HeaderText="Period" />
                <asp:BoundField DataField="reason" HeaderText="Reason" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
