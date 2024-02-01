var dataTable;

$(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'firstname', "width": "15%" },
            { data: 'lastname', "width": "15%" },
            { data: 'email', "width": "20%" },
            { data: 'phoneNumber', "width": "15%" },
            { data: '', "width": "10%" },
            {
                data: 'productId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?productId=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i> Edit</a>
                    </div>`
                },
                "width": "25%"
            }
        ],
        "initComplete": function (settings, json) {
            // Apply row styling here
            applyTableStyling();
        }
    });
}

// Function to apply styling to DataTable rows and cells
function applyTableStyling() {
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


