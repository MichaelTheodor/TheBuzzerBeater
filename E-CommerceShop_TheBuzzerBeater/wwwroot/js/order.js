var dataTable;

$(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else
    {
        if (url.includes("completed")) {
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved")) {
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall?status='+status },
        "columns": [
            { data: 'orderHeaderId', "width": "5%" },
            { data: 'firstName', "width": "15%" },
            { data: 'lastName', "width": "15%" },
            { data: 'phoneNumber', "width": "15%" },
            { data: 'applicationUser.email', "width": "20%" },
            { data: 'orderStatus', "width": "10%" },
            { data: 'orderTotal', "width": "10%" },
            {
                data: 'orderId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/Admin/Order/details?orderId=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i>
                    </a>
                    
                            </div>`
                },
                "width": "10%"
            }
        ],
        "initComplete": function (settings, json) {
            // Apply row styling here
            applyTableStyling();
        },
        "drawCallback": function (settings) {
            // Apply row styling on each draw (including pagination)
            applyTableStyling();
        }
    });
}

// Function to apply styling to DataTable rows and cells
function applyTableStyling() {
    // Remove existing styling
    $('#tblData tbody tr').removeClass('table-dark');
    $('#tblData tbody td').css('font-size', '');
    // Apply new styling
    $('#tblData tbody tr').addClass('table-dark');
    $('#tblData tbody td').css('font-size', '20px');
}

