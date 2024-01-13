

$(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'category.name', "width": "15%" },
            { data: 'description', "width": "30%" },
            { data: 'price', "width": "5%" },
            {
                data: 'productId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?productId=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i> Edit</a>
                    <a href="" class="btn btn-danger mx-2">
                            <i class="bi bi-trash3-fill"></i> Delete</a>
                    </div>`
                },
                "width": "20%"
            }
        ],
        "initComplete": function (settings, json) {
            // Apply row styling here
            $('#tblData tbody tr').addClass('table-dark');
            $('#tblData tbody td').css('font-size', '20px');
        }
    });
}