<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="approve_leave_hr.aspx.cs" Inherits="eleave_view.hr.approve_leave_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
	    <div class="col-md-12">
		<!-- start: BASIC TABLE PANEL -->
			<div class="panel panel-default">
				<div class="panel-heading">
					<i class="icon-external-link-sign"></i>
					Approve or Reject Leaves
					<div class="panel-tools">
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
					<table class="table table-hover" id="sample-table-1">
						<thead>
							<tr>
								<th class="center">#</th>
								<th>Browser</th>
				    			<th class="hidden-xs">Creator</th>
								<th class="hidden-xs">Cost (USD)</th>
								<th>Software license</th>
								<th class="hidden-xs">Current layout engine</th>
								<th></th>
							</tr>
						</thead>
						<tbody>
											<tr>
												<td class="center">1</td>
												<td class="hidden-xs">Google Chrome</td>
												<td>Google</td>
												<td class="hidden-xs">Free</td>
												<td>
												<a href="#" rel="nofollow" target="_blank">
													Terms of Service
												</a></td>
												<td class="hidden-xs">Blink</td>
												<td class="center">
												<div class="visible-md visible-lg hidden-sm hidden-xs">
													<a href="#" class="btn btn-teal tooltips" data-placement="top" data-original-title="Edit"><i class="icon-edit"></i></a>
													<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="icon-share"></i></a>
													<a href="#" class="btn btn-bricky tooltips" data-placement="top" data-original-title="Remove"><i class="icon-remove icon-white"></i></a>
												</div>
												<div class="visible-xs visible-sm hidden-md hidden-lg">
													<div class="btn-group">
														<a class="btn btn-primary dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
															<i class="icon-cog"></i> <span class="caret"></span>
														</a>
														<ul role="menu" class="dropdown-menu pull-right">
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-edit"></i> Edit
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-share"></i> Share
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-remove"></i> Remove
																</a>
															</li>
														</ul>
													</div>
												</div></td>
											</tr>
											<tr>
												<td class="center">2</td>
												<td>Internet Explorer</td>
												<td class="hidden-xs">Microsoft, Spyglass</td>
												<td class="hidden-xs">comes with Windows</td>
												<td>
												<a href="#" rel="nofollow" target="_blank">
													Proprietary
												</a></td>
												<td class="hidden-xs">Trident</td>
												<td class="center">
												<div class="visible-md visible-lg hidden-sm hidden-xs">
													<a href="#" class="btn btn-teal tooltips" data-placement="top" data-original-title="Edit"><i class="icon-edit"></i></a>
													<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="icon-share"></i></a>
													<a href="#" class="btn btn-bricky tooltips" data-placement="top" data-original-title="Remove"><i class="icon-remove icon-white"></i></a>
												</div>
												<div class="visible-xs visible-sm hidden-md hidden-lg">
													<div class="btn-group">
														<a class="btn btn-primary dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
															<i class="icon-cog"></i> <span class="caret"></span>
														</a>
														<ul role="menu" class="dropdown-menu pull-right">
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-edit"></i> Edit
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-share"></i> Share
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-remove"></i> Remove
																</a>
															</li>
														</ul>
													</div>
												</div></td>
											</tr>
											<tr>
												<td class="center">3</td>
												<td>Mozilla Firefox</td>
												<td class="hidden-xs">Mozilla Foundation</td>
												<td class="hidden-xs">Free</td>
												<td>
												<a href="#" rel="nofollow" target="_blank">
													MPR
												</a></td>
												<td class="hidden-xs">Gecko</td>
												<td class="center">
												<div class="visible-md visible-lg hidden-sm hidden-xs">
													<a href="#" class="btn btn-teal tooltips" data-placement="top" data-original-title="Edit"><i class="icon-edit"></i></a>
													<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="icon-share"></i></a>
													<a href="#" class="btn btn-bricky tooltips" data-placement="top" data-original-title="Remove"><i class="icon-remove icon-white"></i></a>
												</div>
												<div class="visible-xs visible-sm hidden-md hidden-lg">
													<div class="btn-group">
														<a class="btn btn-primary dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
															<i class="icon-cog"></i> <span class="caret"></span>
														</a>
														<ul role="menu" class="dropdown-menu pull-right">
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-edit"></i> Edit
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-share"></i> Share
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-remove"></i> Remove
																</a>
															</li>
														</ul>
													</div>
												</div></td>
											</tr>
											<tr>
												<td class="center">4</td>
												<td>Safari</td>
												<td class="hidden-xs">Apple Inc.</td>
												<td class="hidden-xs">Free</td>
												<td>
												<a href="#" rel="nofollow" target="_blank">
													Proprietary
												</a></td>
												<td class="hidden-xs">WebKit</td>
												<td class="center">
												<div class="visible-md visible-lg hidden-sm hidden-xs">
													<a href="#" class="btn btn-teal tooltips" data-placement="top" data-original-title="Edit"><i class="icon-edit"></i></a>
													<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="icon-share"></i></a>
													<a href="#" class="btn btn-bricky tooltips" data-placement="top" data-original-title="Remove"><i class="icon-remove icon-white"></i></a>
												</div>
												<div class="visible-xs visible-sm hidden-md hidden-lg">
													<div class="btn-group">
														<a class="btn btn-primary dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
															<i class="icon-cog"></i> <span class="caret"></span>
														</a>
														<ul role="menu" class="dropdown-menu pull-right">
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-edit"></i> Edit
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-share"></i> Share
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-remove"></i> Remove
																</a>
															</li>
														</ul>
													</div>
												</div></td>
											</tr>
											<tr>
												<td class="center">5</td>
												<td>Opera</td>
												<td class="hidden-xs">Opera Software</td>
												<td class="hidden-xs">Free</td>
												<td>
												<a href="#" rel="nofollow" target="_blank">
													Proprietary
												</a></td>
												<td class="hidden-xs">Presto</td>
												<td class="center">
												<div class="visible-md visible-lg hidden-sm hidden-xs">
													<a href="#" class="btn btn-teal tooltips" data-placement="top" data-original-title="Edit"><i class="icon-edit"></i></a>
													<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="icon-share"></i></a>
													<a href="#" class="btn btn-bricky tooltips" data-placement="top" data-original-title="Remove"><i class="icon-remove icon-white"></i></a>
												</div>
												<div class="visible-xs visible-sm hidden-md hidden-lg">
													<div class="btn-group">
														<a class="btn btn-primary dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
															<i class="icon-cog"></i> <span class="caret"></span>
														</a>
														<ul role="menu" class="dropdown-menu pull-right">
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-edit"></i> Edit
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-share"></i> Share
																</a>
															</li>
															<li role="presentation">
																<a role="menuitem" tabindex="-1" href="#">
																	<i class="icon-remove"></i> Remove
																</a>
															</li>
														</ul>
													</div>
												</div></td>
											</tr>
										</tbody>
									</table>
								</div>
							</div>
							<!-- end: BASIC TABLE PANEL -->
						</div>
					</div>



</asp:Content>
