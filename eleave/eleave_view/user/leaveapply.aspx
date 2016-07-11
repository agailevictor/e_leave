﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leaveapply.aspx.cs" Inherits="eleave_view.user.leaveapply"
    MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully sent',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "listleaves.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            swal({
                title: 'Warning!',
                text: 'Failed to fetch the details needed',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errorpdf() {
            swal({
                title: 'Error!',
                text: 'Invalid File Extension/ Format',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errorpdfsize() {
            swal({
                title: 'Error!',
                text: 'Max File size is 3 MB',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errornotavail() {
            swal({
                title: 'Error!',
                text: 'You Leave Count is Insufficiant ',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errornofile() {
            swal({
                title: 'Error!',
                text: 'Upload Medical Certificate',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errorrange() {
            swal({
                title: 'Error!',
                text: 'Select Start Date & End Date',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errorsrange() {
            swal({
                title: 'Error!',
                text: 'Start Date & End Date Can\'t be same',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error1() {
            swal({
                title: 'Error!',
                text: 'You have some form errors!',
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
                text: 'Failed to fetch the details needed',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error_mandatory_p() {
            swal({
                title: 'Warning!',
                text: 'Select 3 days Mandatory',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errormandatory_m() {
            swal({
                title: 'Warning!',
                text: 'Select 3 days Mandatory',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Request Leave</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: FORM VALIDATION 2 PANEL -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-plus-circle-2"></i>Request Leave
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a><a class="btn btn-xs btn-link panel-expand"
                            href="#"><i class="icon-resize-full"></i></a><a class="btn btn-xs btn-link panel-close"
                                href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <h2>
                        <i class="icon-edit-sign teal"></i>REQUEST</h2>
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
                                    Name 
                                </label>
                                <asp:Label ID="lblname" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Position 
                                </label>
                                <asp:Label ID="lblpos" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Department 
                                </label>
                                <asp:Label ID="lbldep" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Leave Type <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlltype" runat="server" CssClass="form-control"
                                    ClientIDMode="Static" onchange="hideshowfup()" DataTextField="leave_type"
                                    DataValueField="ltype_id">
                                </asp:DropDownList>
                            </div>                            
                            <div class="form-group" id="dates">
                                <label class="control-label">
                                    Dates <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="chosen-disabled form-control"
                                    ClientIDMode="Static" BackColor="White" onchange="reset_period()"></asp:TextBox>
                            </div>
                            <div class="form-group" id="dateranges" style="display: none">
                                <label class="control-label">
                                    Dates <span class="symbol required"></span>
                                </label>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-6" style="padding-left: 0px !important; padding-right: 0px !important;">
                                            <asp:TextBox ID="txtsdate" runat="server" CssClass="chosen-disabled form-control" ClientIDMode="Static" BackColor="White" onchange="reset_period()"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-1">
                                            <span>to</span>
                                        </div>
                                        <div class="col-sm-5" style="padding-left: 0px !important; padding-right: 0px !important;">
                                            <asp:TextBox ID="txtedate" runat="server" CssClass="chosen-disabled form-control" ClientIDMode="Static" BackColor="White" onchange="reset_period()"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Period <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlper" runat="server" CssClass="form-control"
                                    ClientIDMode="Static" DataTextField="period" DataValueField="period_id" onchange="in_or_out()">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Selected
                                </label>
                                <asp:Label ID="lblreq" runat="server" CssClass="form-control" Text="N/A" ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Reason <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtreason" runat="server" TextMode="MultiLine"
                                    CssClass="form-control" ClientIDMode="Static" MaxLength="1" Rows="2"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    My Job Will be coverd by <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddljobc" runat="server" CssClass="form-control"
                                    ClientIDMode="Static" DataTextField="Name" DataValueField="user_id">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Contact No <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtphone" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group" id="fup" style="display: none">
                                <label class="control-label">
                                    Medical Certificate <span class="symbol required"></span>
                                </label>
                                <asp:FileUpload ID="fupload" runat="server"
                                    CssClass="fileupload fileupload-new" ClientIDMode="Static" />
                                <p class="help-block">
                                    Allowed File Type is PDF. <span class="clip-file-pdf"></span>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>                            
                            <div class="form-group">
                                <div id="pulsate-regulario" style="padding: 5px; width: 202px; display: none">
                                    <asp:Label ID="lblio" runat="server" ClientIDMode="Static" ForeColor="Black"></asp:Label>
                                </div>
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
                            <asp:Button ID="btnreq" runat="server" Text="Apply" CssClass="btn btn-success" OnClientClick="leavevali()" OnClick="btnreq_Click" ClientIDMode="Static" />
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end: FORM VALIDATION 2 PANEL -->
        </div>
    </div>
</asp:Content>
