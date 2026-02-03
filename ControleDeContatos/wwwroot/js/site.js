$(document).ready(function () {

    // Tabela de CONTATOS
    if ($('#table-contatos').length) {
        $('#table-contatos').DataTable({
            ordering: true,
            paging: true,
            searching: true,
            language: {
                emptyTable: "Nenhum registro encontrado na tabela",
                info: "Mostrar _START_ até _END_ de _TOTAL_ registros",
                infoEmpty: "Mostrar 0 até 0 de 0 Registros",
                infoFiltered: "(Filtrar de _MAX_ total registros)",
                lengthMenu: "Mostrar _MENU_ registros por página",
                loadingRecords: "Carregando...",
                processing: "Processando...",
                zeroRecords: "Nenhum registro encontrado",
                search: "Pesquisar",
                paginate: {
                    next: "Próximo",
                    previous: "Anterior",
                },
                aria: {
                    sortAscending: ": Ordenar colunas de forma ascendente",
                    sortDescending: ": Ordenar colunas de forma descendente"
                }
            }
        });
    }

    // Tabela de USUÁRIOS
    if ($('#table-Usuarios').length) {
        $('#table-Usuarios').DataTable({
            ordering: true,
            paging: true,
            searching: true,
            language: {
                emptyTable: "Nenhum registro encontrado na tabela",
                info: "Mostrar _START_ até _END_ de _TOTAL_ registros",
                infoEmpty: "Mostrar 0 até 0 de 0 Registros",
                infoFiltered: "(Filtrar de _MAX_ total registros)",
                lengthMenu: "Mostrar _MENU_ registros por página",
                loadingRecords: "Carregando...",
                processing: "Processando...",
                zeroRecords: "Nenhum registro encontrado",
                search: "Pesquisar",
                paginate: {
                    next: "Próximo",
                    previous: "Anterior",
                },
                aria: {
                    sortAscending: ": Ordenar colunas de forma ascendente",
                    sortDescending: ": Ordenar colunas de forma descendente"
                }
            }
        });
    }



    // Fechar alertas
    $('.close-alert').click(function () {
        $('.alert').hide();
    });

});
