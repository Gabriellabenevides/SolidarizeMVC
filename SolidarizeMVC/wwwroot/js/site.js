$(document).ready(function () {
    $('#Campanhas').DataTable({
        language: {
            "url": "//cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json"
        }
    });

    $('#Doadores').DataTable({
        language: {
            "url": "//cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json"
        }
    });

    $('#Doacoes').DataTable({
        language: {
            "url": "//cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json"
        }
    });

    setTimeout(function () {
        $("alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 5000)
});
