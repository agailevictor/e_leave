<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="applyleave.aspx.cs" Inherits="eleave_view.user.applyleave"
    MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>
            Request Leave</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="errorHandler alert alert-danger no-display" id="error">
                <i class="icon-remove-sign"></i>You have some form errors. Please check below.
            </div>
            <div class="successHandler alert alert-success no-display" id="success">
                <i class="icon-ok"></i>Your form validation is successful!
            </div>
        </div>
        <div class="col-sm-6">
            <!-- start: DATE/TIME PICKER PANEL -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="icon-external-link-sign"></i>Date/Time Picker
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a><a class="btn btn-xs btn-link panel-expand"
                            href="#"><i class="icon-resize-full"></i></a><a class="btn btn-xs btn-link panel-close"
                                href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <p>
                        Leave Required
                    </p>
                    <div class="input-group input-append bootstrap-timepicker">
                        <asp:DropDownList ID="ddlleave" runat="server" CssClass="form-control" 
                            ClientIDMode="Static">
                            <asp:ListItem Value="">--- Select ---</asp:ListItem>
                            <asp:ListItem Value="1">Annual</asp:ListItem>
                            <asp:ListItem Value="2">Medical</asp:ListItem>
                            <asp:ListItem Value="4">Marriage</asp:ListItem>
                            <asp:ListItem Value="5">Maternity</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <hr>
                    <p>
                        Dates Applied
                    </p>
                    <div class="input-group">
                        <asp:TextBox ID="bootdate" runat="server" CssClass="form-control date-picker" ClientIDMode="Static"></asp:TextBox>
                        <span class="input-group-addon"><i class="icon-calendar"></i></span>
                    </div>
                    <hr>
                    <p>
                        File Upload
                    </p>
                    <div class="input-group-btn">
                        <asp:TextBox ID="txtfile" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                    </div>
                    <hr>
                    <p>
                        Date + Time Range Picker
                    </p>
                    <div class="input-group">
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="vali()" />
                    </div>
                </div>
            </div>
            <!-- end: DATE/TIME PICKER PANEL -->
        </div>
    </div>
</asp:Content>
