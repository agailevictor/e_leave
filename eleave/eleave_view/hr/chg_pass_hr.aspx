<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chg_pass_hr.aspx.cs" Inherits="eleave_view.hr.chg_pass_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success_pwd()
        {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully sent',
                type: 'success'
            },
                function () {
                    window.location = "hrdash.aspx";
                });
        }
    </script>

    <script type="text/javascript">
        function error_pwd()
        {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong. Try Again',
                type: 'error'
            });
        }
    </script>

    <script type="text/javascript">
        function pwd_match_fail()
        {
            swal({
                title: 'Error!',
                text: 'Passwords Dont Match. Try Again',
                type: 'error'
            });
        }
    </script>

    <script type="text/javascript">
        function error()
        {
            swal({
                title: 'Error!',
                text: 'Old Password doesnt match. Try again',
                type: 'error'
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page-header">
        <h1>
            Change Password</h1>
    </div>
    <div class="row">
		<div class="col-md-12">
		<!-- start: FORM VALIDATION 2 PANEL -->
			<div class="panel panel-default">
				<div class="panel-heading">
					<i class="icon-external-link-sign"></i>Change Password

					<div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                        <a class="btn btn-xs btn-link panel-expand" href="#"><i class="icon-resize-full"></i></a>
                        <a class="btn btn-xs btn-link panel-close" href="#"><i class="icon-remove"></i></a>
                    </div>
				</div>
				<div class="panel-body">
                    <div class="row">							
							<div class="col-md-6">
								<div class="form-group">
									<label class="control-label">
										Old Password <span class="symbol required"></span>
									</label>
						            <asp:TextBox ID="oldpwd_hr_txt" runat="server" CssClass="form-control"></asp:TextBox>
								</div>
								<div class="form-group">
									<label class="control-label">
										New Password <span class="symbol required"></span>
									</label>
                                    <asp:TextBox ID="nwpwd_hr_txt" runat="server" CssClass="form-control"></asp:TextBox>
								</div>
								<div class="form-group">
									<label class="control-label">
										Confirm New Password <span class="symbol required"></span>
									</label>
                                    <asp:TextBox ID="conf_nwpwd_hr_txt" runat="server" CssClass="form-control"></asp:TextBox>
								</div>
                                <div class="col-md-4">
                                    <asp:Button ID="Button1" runat="server" Text="Change Password" CssClass="btn btn-yellow btn-block" OnClick="Button1_Click" />                                
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>