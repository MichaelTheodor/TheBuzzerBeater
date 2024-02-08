var dataTable;

$(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'firstName', "width": "15%" },
            { data: 'lastName', "width": "15%" },
            { data: 'email', "width": "20%" },
            { data: 'phoneNumber', "width": "15%" },
            { data: 'role', "width": "10%" },
            {
                data: {id:"id",lockoutEnd :"lockoutEnd"},
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `
                            <div class="text-center">
                                <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:125px;">
                                    <i class="bi bi-lock-fill"></i> Locked
                                </a>
                                <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-danger text-white" style="cursor:pointer; width:125px;">
                                    <i class="bi bi-pencil-square"></i> Permission
                                </a>
                            </div>
                        `
                    }
                    else {
                        return `
                            <div class="text-center">
                                
                                <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width:125px;">
                                    <i class="bi bi-unlock-fill"></i> Unlocked
                                </a>
                                <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-danger text-white" style="cursor:pointer; width:125px;">
                                    <i class="bi bi-pencil-square"></i> Permission
                                </a>
                            </div>
                        `
                    }
                },
                "width": "25%"
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

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}