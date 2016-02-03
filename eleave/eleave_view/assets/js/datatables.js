var TableData = function () {
    //function to initiate DataTable
    //DataTable is a highly flexible tool, based upon the foundations of progressive enhancement, 
    //which will add advanced interaction controls to any HTML table
    //For more information, please visit https://datatables.net/
    var runDataTable = function () {
        var oTable = $('#grd_users').dataTable({
            "aoColumnDefs": [{
                'bSortable': false,
                "aTargets": [0,9,10]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "oPaginate": {
                    "sPrevious": "",
                    "sNext": ""
                }
            },
            "aaSorting": [
                [1, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 5,
        });
        $('#grd_users_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_users_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable1 = function () {
        var oTable = $('#grd_userleaves').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "oPaginate": {
                    "sPrevious": "",
                    "sNext": ""
                }
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 5,
        });
        $('#grd_userleaves_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_userleaves_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable2 = function () {
        var oTable = $('#status_hr').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "oPaginate": {
                    "sPrevious": "",
                    "sNext": ""
                }
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 5,
        });
        $('#status_hr_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#status_hr_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable3 = function () {
        var oTable = $('#grd_forward').dataTable({
            "aoColumnDefs": [{
                'bSortable': false,
                "aTargets": [0,8,9,10,11,12,13]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "oPaginate": {
                    "sPrevious": "",
                    "sNext": ""
                }
            },
            "aaSorting": [
                [1, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 5,
        });
        $('#grd_forward_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_forward_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable4 = function () {
        var oTable = $('#grd_cancel_hr').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "oPaginate": {
                    "sPrevious": "",
                    "sNext": ""
                }
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 5,
        });
        $('#grd_cancel_hr_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_cancel_hr_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

   return {
        //main function to initiate template pages
        init: function () {
            runDataTable();
            runDataTable1();
            runDataTable2();
            runDataTable3();
            runDataTable4();
        }
    };
}();