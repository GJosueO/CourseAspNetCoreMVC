var dataTable;

$(document).ready(function () {
    cargarDataTable();
});

function cargarDataTable() {
    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/admin/categorias/GetAll",
            "type": "GET",
            "datatype": "json"

        },
        "columns": [
            {
            "data": "id",
            "width" : "5%"
            },
            {
            "data": "nombre",
            "width" : "40%"
            },
            {
            "data": "fechaCreacion",
            "width" : "20%"
            },
            {
            "data": "orden",
            "width" : "10%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                             <a href="/admin/categorias/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;" >
                                <i class="far fa-edit"></i> Editar
                             </a>
                                &nbsp;
                            <a onclick=Delete("/admin/categorias/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;" >
                                <i class="far fa-trash-alt"></i> Eliminar
                            </a>
                        </div>
                    `;
                }, "width": "25%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}