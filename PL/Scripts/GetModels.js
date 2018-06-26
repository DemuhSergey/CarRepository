$(document).ready(function () {
    $("#MarkName").change(function () {
        $.get("/Home/GetModelsByMarkName",
            { MarkName: $("#MarkName").val() },
            function (data) {
                $("#ModelName").empty();
                $.each(data,
                    function (index, row) {
                        $("#ModelName").append("<option value='" + row.Name + "'>" + row.Name + "</option>");
                    });
            });
    });
});