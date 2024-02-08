var dataTable;

$(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'categoryName', "width": "15%" },
            { data: 'description', "width": "30%" },
            { data: 'price', "width": "15%" },
            {
                data: 'productId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?productId=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i> Edit</a>
                    <a onClick=Delete("/admin/product/delete/?productId=${data}") class="btn btn-danger mx-2">
                            <i class="bi bi-trash3-fill"></i> Delete</a>
                    </div>`
                },
                "width": "20%"
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
// Function to handle delete action
function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    dataTable.ajax.reload(function () {
                        // Callback function to be executed after DataTable is reloaded
                        applyTableStyling();
                        toastr.success(data.message);
                    });   
                }
            });
        }
    });
}


