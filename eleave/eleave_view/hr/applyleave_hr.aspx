<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="applyleave_hr.aspx.cs" Inherits="eleave_view.hr.applyleave_hr" MasterPageFile="~/hr/hr.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully sent',
                type: 'success'
                },
                function () {
                    window.location = "status_leave_hr.aspx";
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
    <script type="text/javascript">
        function warning() {
            swal({
                title: 'Warning!',
                text: 'Failed to fetch the details needed',
                type: 'warning'
            });
        }
    </script>
    <script type="text/javascript">
        function errorpdf() {
            swal({
                title: 'Error!',
                text: 'Invalid File Extension/ Format',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function errorpdfsize() {
            swal({
                title: 'Error!',
                text: 'Max File size is 2 MB',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function errornotavail() {
            swal({
                title: 'Error!',
                text: 'You Leave Count is over the required limit ',
                type: 'error'
            });
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h1>
            Request Leave</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: Apply Leave HR -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-plus-circle-2"></i>Request Leave
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                        <a class="btn btn-xs btn-link panel-expand" href="#"><i class="icon-resize-full"></i></a>
                        <a class="btn btn-xs btn-link panel-close" href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <h2>
                        <i class="icon-edit-sign teal"></i>REQUEST</h2>
                    <hr>
                    <%--<form action="#" role="form" id="form2">--%>
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
                                    <asp:Label ID="lblname_hr" runat="server" CssClass="form-control" 
                                        ClientIDMode="Static"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Position <span class="symbol required"></span>
                                    </label>
                                    <asp:Label ID="lblpos_hr" runat="server"  CssClass="form-control" 
                                        ClientIDMode="Static"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Department <span class="symbol required"></span>
                                    </label>
                                    <asp:Label ID="lbldep_hr" runat="server"  CssClass="form-control" 
                                        ClientIDMode="Static"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Leave Type <span class="symbol required"></span>
                                    </label>
                                    <asp:DropDownList ID="ddlltype_hr" runat="server" CssClass="form-control" 
                                        ClientIDMode="Static" onchange="hideshowfup_hr()" DataTextField="leave_type" 
                                        DataValueField="ltype_id">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" id ="fup_hr">
                                    <label class="control-label">
                                        Upload File <span class="symbol required"></span>
                                    </label>
                                    <asp:FileUpload ID="fupload_hr" runat="server" 
                                        CssClass="fileupload fileupload-new" ClientIDMode="Static" />
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Dates <span class="symbol required"></span>
                                    </label>
                                    <asp:TextBox ID="txtdate_hr" runat="server" CssClass="chosen-disabled form-control" 
                                        ClientIDMode="Static" BackColor="White" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Period <span class="symbol required"></span>
                                    </label>
                                    <asp:DropDownList ID="ddlper_hr" runat="server" CssClass="form-control" 
                                        ClientIDMode="Static" DataTextField="period" DataValueField="period_id">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Reason <span class="symbol required"></span>
                                    </label>
                                    <asp:TextBox ID="txtreason_hr" runat="server" TextMode="MultiLine" 
                                        CssClass="form-control" ClientIDMode="Static" MaxLength="1" Rows="2"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Your Job Will be coverd by <span class="symbol required"></span>
                                    </label>
                                    <asp:DropDownList ID="ddljobc_hr" runat="server" CssClass="form-control" 
                                        ClientIDMode="Static" DataTextField="Name" DataValueField="user_id">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Contact No <span class="symbol required"></span>
                                    </label>
                                    <asp:TextBox ID="txtphone_hr" runat="server" CssClass="form-control" 
                                        ClientIDMode="Static"></asp:TextBox>
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
                            <asp:Button ID="btnreq_hr" runat="server" Text="Apply" CssClass="btn btn-success" OnClientClick="leavevali()" onclick="btnreq_hr_Click" /> 
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                   <%-- </form>--%>
                </div>
            </div>
            <!-- end: Apply Leave HR -->
        </div>
    </div>

</asp:Content>
