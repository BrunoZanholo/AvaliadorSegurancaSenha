$(function () {

    $("#input-senha-valor").keyup(function (e) {

        var form = $("#form-senha");

        $.ajax({
            type: "POST",
            data: form.serialize(),
            url: form.attr("action")
        }).done(function (result) {

            $("#span-senha-score").text(result.Score + "%");
            $("#span-senha-complexidade").text(result.Complexidade);

            $("#span-senha-complexidade").removeClass("label-danger");
            $("#span-senha-complexidade").removeClass("label-warning");
            $("#span-senha-complexidade").removeClass("label-info");
            $("#span-senha-complexidade").removeClass("label-success");            

            if ((result.Complexidade == "Muito curta") ||
                (result.Complexidade == "Muito fraca") ||
                (result.Complexidade == "Fraca")) {
                $("#span-senha-complexidade").addClass("label-danger")
            }
            else if (result.Complexidade == "Boa") {
                $("#span-senha-complexidade").addClass("label-danger")
            }
            else if (result.Complexidade == "Forte") {
                $("#span-senha-complexidade").addClass("label-info")
            }
            else if (result.Complexidade == "Muito forte") {
                $("#span-senha-complexidade").addClass("label-success")
            }

        }).fail(function (result) {
            alert("Ocorreu o erro: " + result.responseText);
        });
    });

    $("#input-senha-exibir").change(function () {

        $("#input-senha-valor").removeAttr("type");

        if ($(this).prop("checked")) {
            $("#input-senha-valor").attr("type", "text");
        }
        else {
            $("#input-senha-valor").attr("type", "password");
        }
    });
});