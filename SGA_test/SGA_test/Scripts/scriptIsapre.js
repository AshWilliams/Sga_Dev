var delIsapre;
var editIsapre;

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

    delIsapre = function (isapre) {
        $('#dialog-confirm').dialog({
            resizable: true,
            modal: true,
            title: "Desea Eliminar tipo de Licencia " + isapre,
            buttons: {
                "Eliminar Isapre": function () {
                    $(this).dialog("close");
                    elimIsa(isapre);
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        });
    }

    editIsapre = function (codigo, descripcion, rut) {
        $("#actual").val($.trim(descripcion));
        $("#Isa").val($.trim(codigo));
        $("#rutisapre").val($.trim(rut));
        $('#Div1').dialog({
            resizable: true,
            modal: true
        });
    }

    function elimIsa(Isa) {
        $.ajax({
            type: "POST",
            url: "deleteIsapres",
            data: { Isapre: Isa },
            success: function (respuesta) {
                //table = $("#Tabla").dataTable();
                //table.fnClearTable();
                showTable();
                alert(respuesta);
            }
        });

    }

    function showTable() {
        $.getJSON("GetIsapres", null, function (Isapres) {
            $("#Tabla").html("<thead><tr><td>Tipo</td><td>Nombre</td><td>RUT Isapre</td><td>Editar</td><td>Eliminar</td></tr></thead><tbody></tbody>");
            $("#Tabla").dataTable({
                "aaData": Isapres,
                "aoColumns": [

                            { "mData": "ID" },
                            { "mData": "Nombre" },
                            { "mData": "RutIsa" },
                            {
                                "mData": null,
                                "mRender": function (data, type, full) {
                                    var nombre = ",'" + full.Nombre + "'" + ",'" + full.RutIsa + "'";
                                    return '<a onclick="editIsapre(' + full.ID + nombre + ')" >Editar</a>';
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, full) {
                                    return '<a onclick="delIsapre(' + full.ID + ')">Eliminar</a>';
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
        $("#isapre").val("")
        $("#rutisapre1").val("")
        $('#dialog').dialog({
            resizable: true,
            modal: true
        });
    });


    $("#guarda").click(function () {
        var valor = $("#isapre").val();
        var RutIsapre = $("#rutisapre1").val();
        if (valor == "") {
            alert("Debe ingresar un valor");
        }
        else {
            $("#dialog").dialog('close');
            $.ajax({
                type: "POST",
                url: "insertIsapre",
                data: { isapre: valor, RutIsapre: RutIsapre },
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
        var Isapre = $("#Isa").val();
        var RutIsapre = $("#rutisapre").val();
        if (describe == "") {
            alert("Debe completar la informacion");
        }
        else {
            $("#Div1").dialog('close');
            $.ajax({
                type: "POST",
                url: "updateIsapre",
                data: { describe: describe, Isapre: Isapre, RutIsapre: RutIsapre },
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