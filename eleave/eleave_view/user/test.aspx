<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="eleave_view.user.test" MasterPageFile="~/user/user.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function success() {
        swal({
            title: 'Success!',
            text: 'Your request has been succesfully sent',
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
    <script type="text/javascript">
        function warning() {
            swal({
                title: 'Warning!',
                text: 'Failed to fetch the details needed',
                type: 'warning'
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
							<!-- start: FORM VALIDATION 2 PANEL -->
							<div class="panel panel-default">
								<div class="panel-heading">
									<i class="icon-external-link-sign"></i>
									Form Validation 2
									<div class="panel-tools">
										<a class="btn btn-xs btn-link panel-collapse collapses" href="#">
										</a>
										<a class="btn btn-xs btn-link panel-config" href="#panel-config" data-toggle="modal">
											<i class="icon-wrench"></i>
										</a>
										<a class="btn btn-xs btn-link panel-refresh" href="#">
											<i class="icon-refresh"></i>
										</a>
										<a class="btn btn-xs btn-link panel-expand" href="#">
											<i class="icon-resize-full"></i>
										</a>
										<a class="btn btn-xs btn-link panel-close" href="#">
											<i class="icon-remove"></i>
										</a>
									</div>
								</div>
								<div class="panel-body">
									<h2><i class="icon-edit-sign teal"></i> REGISTER</h2>
									<p>
										Create one account to manage everything you do with ClipOne, from your shopping preferences to your ClipOne activity.
									</p>
									<hr>
									<form action="#" role="form" id="form2">
										<div class="row">
											<div class="col-md-12">
												<div class="errorHandler alert alert-danger no-display">
													<i class="icon-remove-sign"></i> You have some form errors. Please check below.
												</div>
												<div class="successHandler alert alert-success no-display">
													<i class="icon-ok"></i> Your form validation is successful!
												</div>
											</div>
											<div class="col-md-6">
												<div class="form-group">
													<label class="control-label">
														First Name <span class="symbol required"></span>
													</label>
                                                    <asp:TextBox ID="txtname" CssClass="form-control" runat="server" 
                                                        ClientIDMode="Static" name="txtname"></asp:TextBox>
												</div>
												<div class="form-group">
													<label class="control-label">
														Last Name <span class="symbol required"></span>
													</label>
													<input type="text" placeholder="Insert your Last Name" class="form-control" id="lastname2" name="lastname2">
												</div>
												<div class="form-group">
													<label class="control-label">
														Email Address <span class="symbol required"></span>
													</label>
													<input type="email" placeholder="Text Field" class="form-control" id="email2" name="email2">
												</div>
												<div class="form-group">
													<label class="control-label">
														Occupation <span class="symbol required"></span>
													</label>
													<input type="text" class="form-control" name="occupation" id="occupation">
												</div>
												<div class="form-group">
													<label class="control-label">
														Dropdown <span class="symbol required"></span>
													</label>
                                                            <asp:DropDownList ID="ddl" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">One</asp:ListItem>
                                                                <asp:ListItem Value="2">Two</asp:ListItem>
                                                            </asp:DropDownList>

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
												<p>
													By clicking REGISTER, you are agreeing to the Policy and Terms &amp; Conditions.
												</p>
											</div>
											<div class="col-md-4">
                            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-yellow btn-block" onclick="Button1_Click" />
                                                <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" />
											</div>
										</div>
									</form>
								</div>
							</div>
							<!-- end: FORM VALIDATION 2 PANEL -->
						</div>
					</div>
</asp:Content>
