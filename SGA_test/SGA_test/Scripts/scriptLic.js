var delLicencia;
var editLicencia;

$(document).ready(function () {

    $("#dialog").hide();
    $("#dialog-confirm").hide();
    $("#Div1").hide();

    /* Validamos form
    $('#myForm').validate({ 
    rules: {
    describe: {
    required: true
    }
    },
    messages: {
    describe: { required: "Debe llenar el campo.." }
    },
    submitHandler: function (form) {
    alert('Hi');
    }
    });
    */
    //Función Global que levanta dialogo 
    delLicencia = function (licencia) {
        $('#dialog-confirm').dialog({
            resizable: true,
            modal: true,
            title: "Desea Eliminar tipo de Licencia " + licencia,
            buttons: {
                "Eliminar Licencia": function () {
                    $(this).dialog("close");
                    elimLic(licencia);
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        });
    }

    editLicencia = function (codigo, descripcion) {
        $("#actual").val($.trim(descripcion));
        $("#lic").val($.trim(codigo));
        $('#Div1').dialog({
            resizable: true,
            modal: true
        });
    }

    function elimLic(lic) {
        $.ajax({
            type: "POST",
            url: "deleteLicencia",
            data: { licencia: lic },
            success: function (respuesta) {
                //table = $("#Tabla").dataTable();
                //table.fnClearTable();
                showTable();
                alert(respuesta);
            }
        });

    }

    function showTable() {
        $.getJSON("GetLicencias", null, function (licencias) {
            $("#Tabla").html("<thead><tr><td>Tipo</td><td>Nombre</td><td>Editar</td><td>Eliminar</td></tr></thead><tbody></tbody>");
            $("#Tabla").dataTable({
                "aaData": licencias,
                "aoColumns": [

                            { "mData": "ID" },
                            { "mData": "Nombre" },
                            {
                                "mData": null,
                                "mRender": function (data, type, full) {
                                    var nombre = ",'" + full.Nombre + "'";
                                    return '<a onclick="editLicencia(' + full.ID + nombre + ')" >Editar</a>';
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, full) {
                                    return '<a onclick="delLicencia(' + full.ID + ')">Eliminar</a>';
                                }
                            }

                            ],
                "bDestroy": true
            }).fnDraw();
        });
    }

    showTable();

    $('#nuevo').click(function (event) {
        event.preventDefault();
        $("#describe").val("")
        $('#dialog').dialog({
            resizable: true,
            modal: true
        });
    });


    $("#guarda").click(function () {
        var valor = $("#describe").val();
        if (valor == "") {
            alert("Debe ingresar un valor");
        }
        else {
            $("#dialog").dialog('close');
            $.ajax({
                type: "POST",
                url: "insertLicencia",
                data: { describe: valor },
                success: function (respuesta) {
                    //table = $("#Tabla").dataTable().fnDraw();
                    //table.fnClearTable();
                    showTable();
                    alert(respuesta);
                }
            });
        }
    });


    $("#actualiza").click(function () {
        var describe = $("#actual").val();
        var licencia = $("#lic").val();
        if (describe == "") {
            alert("Debe completar la informacion");
        }
        else {
            $("#Div1").dialog('close');
            $.ajax({
                type: "POST",
                url: "updateLicencia",
                data: { describe: describe, licencia: licencia },
                success: function (respuesta) {
                    //table = $("#Tabla").dataTable().fnDraw();
                    //table.fnClearTable();
                    showTable();
                    alert(respuesta);
                }
            });
        }
    });


});