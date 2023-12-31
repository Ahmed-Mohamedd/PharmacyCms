var DataTable;

$(document).ready(function () {
    LoadDataTable();
    LoadCategoryDataTable();
});

function LoadDataTable() {
    DataTable = $('#medicineData').DataTable({
        "ajax": {
            "url": "Dashboard/GetMedicines",
            "type": 'GET',
        },
        "columns": [
            {"data":"id" , "width" : "15%"},
            {"data":"name" , "width" : "15%"},
            {"data":"price" , "width" : "15%"},
            {"data":"activeSubstance" , "width" : "15%"},
            {"data":"indications" , "width" : "15%"},
           
           
        ]
    });
}

function LoadCategoryDataTable() {
    DataTable = $('#categoriesData').DataTable({
        "ajax": {
            "url": "Category/GetCategories"
        },
        "columns": [
         
            { "data": "name", "width": "15%" },
            { "data": "createdTime", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                            <a href="Category/Edit?id=${data}"
                            class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                            <a href="Category/Delete?id=${data}"
                            class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                            </div>`
                },
                "width": "15%"
            }
               
        ]
    });
}