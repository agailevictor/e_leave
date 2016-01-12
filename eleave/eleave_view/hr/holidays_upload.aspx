<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="holidays_upload.aspx.cs" Inherits="eleave_view.hr.holidays_upload" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Upload Holidays List</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: FORM VALIDATION 2 PANEL -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-paperplane"></i>Upload Holidays
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a><a class="btn btn-xs btn-link panel-expand"
                            href="#"><i class="icon-resize-full"></i></a><a class="btn btn-xs btn-link panel-close"
                                href="#"><i class="icon-remove"></i></a>
                    </div>
                    <div class="panel-body">
                        <h4 style="text-align: justify">Format for Uploading the data,copy all the cells in the excel and paste it into the below shown box.
                            The columns must in the format Event Name,Event Date(yyyy-mm-dd),Event Color</h4>
                        <img src="../assets/images/leaves.jpg" height="auto" width="100%" />
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
                                        Holiday List <span class="symbol required"></span>
                                    </label>
                                    <asp:TextBox ID="txtholidays" runat="server" TextMode="MultiLine"
                                        CssClass="form-control" ClientIDMode="Static" MaxLength="1" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <span class="symbol required"></span>Required Fields
                                <hr/>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <asp:Button ID="btnreq" runat="server" Text="Upload" CssClass="btn btn-success" />
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
