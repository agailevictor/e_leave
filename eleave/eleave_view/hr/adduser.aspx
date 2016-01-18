﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adduser.aspx.cs" Inherits="eleave_view.hr.adduser" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'User Added succesfully !',
                type: 'success'
                },
                function () {
                    window.location = "listuser.aspx";
            });
        }
    </script>
     <script type="text/javascript">
         function error_dupli() {
             swal({
                 title: 'Error!',
                 text: 'Username Cannot be Same!',
                 type: 'error'
             });
         }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong!',
                type: 'error'
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Add User</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: Apply Leave HR -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="icon-external-link-sign"></i>Request Leave
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a><a class="btn btn-xs btn-link panel-expand"
                            href="#"><i class="icon-resize-full"></i></a><a class="btn btn-xs btn-link panel-close"
                                href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <h2>
                        <i class="icon-edit-sign teal"></i> ADD </h2>
                    <hr>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="errorHandler alert alert-danger no-display">
                                <i class="icon-remove-sign"></i>You have some form errors. Please check below.
                            </div>
                            <div class="successHandler alert alert-success no-display">
                                <i class="icon-ok"></i>Your form validation is successful!
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">
                                    Name <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   User Name <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtuname" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   Gender <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlgender" runat="server"  CssClass="form-control" ClientIDMode="Static" DataTextField="gender" DataValueField="gid"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   Date Join <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtdoj" runat="server" CssClass="chosen-disabled form-control" BackColor="White" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   Department <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddldep" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="dep_name" DataValueField="dep_id" AutoPostBack="True" OnSelectedIndexChanged="ddldep_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   Designation <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddldesi" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="designation" DataValueField="dsg_id" AutoPostBack="True" OnSelectedIndexChanged="ddldesi_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   Grade <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlgrade" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="grade_desc" DataValueField="grade_id"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   Category <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtcategory" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                   Region <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlregion" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="region" DataValueField="region_id"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div>
                                <span class="symbol required"></span>Required Fields
                                    <hr>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <asp:Button ID="btnuseradd" runat="server" Text="Add" CssClass="btn btn-success" OnClientClick="uservali()" OnClick="btnreq_hr_Click" />
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end: Apply Leave HR -->
        </div>
    </div>
</asp:Content>