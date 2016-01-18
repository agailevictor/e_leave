<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hrdash.aspx.cs" Inherits="eleave_view.hr.hrdash" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Dash Board</h1>
    </div>
    <!-- start: PAGE CONTENT -->
    <!-- start: DIALER -->
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class=" clip-paperplane "></i>
                    Leaves
                                <div class="panel-tools">
                                    <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                                    <a class="btn btn-xs btn-link panel-expand" href="#">
                                        <i class="icon-resize-full"></i>
                                    </a>
                                    <a class="btn btn-xs btn-link panel-close" href="#">
                                        <i class="icon-remove"></i>
                                    </a>
                                </div>
                </div>
                <div class="panel-body">
                    <div class="col-sm-3">
                        <div id="ann"></div>
                    </div>
                    <div class="col-sm-3">
                        <div id="med"></div>
                    </div>
                    <div class="col-sm-3">
                        <div id="repl"></div>
                    </div>
                    <div class="col-sm-3">
                        <div id="mrg"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End: DIALER -->
    <!-- start: FULL CALENDAR -->
    <div class="row">
        <div class="col-sm-12">
            <!-- start: FULL CALENDAR PANEL -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-calendar"></i>
                    Calendar
									<div class="panel-tools">
                                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                                        <a class="btn btn-xs btn-link panel-expand" href="#">
                                            <i class="icon-resize-full"></i>
                                        </a>
                                        <a class="btn btn-xs btn-link panel-close" href="#">
                                            <i class="icon-remove"></i>
                                        </a>
                                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-sm-9">
                        <div id='calendar'></div>
                    </div>
                </div>
            </div>
            <!-- end: FULL CALENDAR PANEL -->
        </div>
    </div>
    <!-- end: PAGE CONTENT-->
</asp:Content>
