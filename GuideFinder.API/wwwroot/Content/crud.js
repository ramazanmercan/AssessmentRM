
    $(document).ready(function () {
        $(document).on("click", ".open-detail", function () {
            var guideId = $(this).data("id");

            $.ajax({
                type: "GET",
                url: "/api/guidedetail/GetGuideDetails?guideId=" + guideId,
                dataType: "json",
                success: function (data) {
                    var tableBody = $("#detail-table-body");
                    tableBody.empty();

                    data.forEach(function (item) {
                        var row = '<tr>';
                        row += '<td>' + item.id + '</td>';
                        row += '<td>' + item.phone + '</td>';
                        row += '<td>' + item.email + '</td>';
                        row += '<td>' + item.address + '</td>';
                        row += '<td>' + item.location + '</td>';
                        row += '<td>' + item.explanation + '</td>';
                        row += '<td><a class="btn btn-primary delete-detail-button" data-id="' + item.id + '">Kaldır</a></td>';
                        row += '</tr>';
                        tableBody.append(row);
                    });
                },
                error: function (err) {
                    console.log(err.statusText);
                }
            });
        });

        $(document).on("click", ".delete-detail-button", function () {
            var guideId = $(this).data("id");
            if (confirm("Bu kaydı silmek istediğinizden emin misiniz?")) {
                $.ajax({
                    type: "DELETE",
                    url: "/api/guidedetail?Id=" + guideId,
                    success: function () {
                        location.reload(true);
                    },
                    error: function () {
                        // Hata durumları
                    }
                });
            }
        });
    });



    function OnAddClick() {
        var formData = {
            name: $("#name").val(),
            surname: $("#surname").val(),
            company: $("#company").val(),
            explanation: $("#explanation").val()
        };

        var jsonData = JSON.stringify(formData);

        $.ajax({
            type: "POST",
            url: "/api/guide",
            dataType: "json",
            contentType: 'application/json',
            data: jsonData,
            success: function (result) {
                alert("İşlem başarıyla tamamlandı.");

                setTimeout(function () {
                    location.reload(true);
                }, 2000);
            },
            error: function (err) {

            }
        });
    }

    $(document).ready(function () {
        $(".delete-button").on("click", function () {
            var guideId = $(this).data("id");
            if (confirm("Bu kaydı silmek istediğinizden emin misiniz?")) {
                $.ajax({
                    type: "DELETE",
                    url: "/api/guide?Id=" + guideId,
                    success: function () {
                        location.reload(true);
                    },
                    error: function () {
                    }
                });
            }
        });
    });



    function clearModalForm() {
        $("#phone").val("");
        $("#email").val("");
        $("#address").val("");
        $("#location").val("");
        $("#explanation").val("");
    }


    $(document).ready(function () {
        $(".open-popup").on("click", function () {
            var guideId = $(this).data("id");
            $("#guideId").val(guideId);
        });

        $("#saveInfo").on("click", function () {
            var formData = {
                GuideId: parseInt($("#guideId").val(), 10),
                Phone: $("#phone").val(),
                Email: $("#email").val(),
                Address: $("#address").val(),
                Location: $("#location").val(),
                Explanation: $("#explanation").val()
            };

            var jsonData = JSON.stringify(formData);

            $.ajax({
                type: "POST",
                url: "/api/guidedetail",
                contentType: 'application/json',
                data: jsonData,
                success: function () {
                    alert("İşlem başarıyla tamamlandı.");
                },
                error: function () {

                }
            });
        });
    });


    function addLatestReportToTable(report) {
        var tableBody = $("#reportTable tbody");
        var newRow = $("<tr style='background-color:red'>");
        newRow.append($('<td>').text('###'));
        newRow.append($('<td>').text(report.location));
        newRow.append($('<td>').text('...'));
        newRow.append($('<td>').text('...'));
        newRow.append($('<td>').text('...'));
        newRow.append($('<td>').text('...'));
        newRow.append($('<td>').html(report.status ? '<b>hazır</b>' : 'Hazırlanıyor.'));

        tableBody.prepend(newRow);
        setTimeout(function () {
            location.reload();
        }, 5000);
    }

    $(document).ready(function () {
        $("#openModalButton").click(function () {
            $("#reportModal").modal("show");
        });

        $("#createReportButton").click(function () {
            var selectedLocation = $("#location2").val();

            var reportData = {
                location: selectedLocation
            };

            $.ajax({
                type: "POST",
                url: "/api/report/CreateReport",
                data: JSON.stringify(reportData),
                contentType: "application/json",
                success: function (data) {
                    console.log("Rapor oluşturuldu:", data);
                    $("#reportModal").modal("hide");
                    addLatestReportToTable(data);
                },
                error: function (error) {
                    console.error("Hata oluştu:", error);
                }
            });
        });
    });


    $(document).ready(function () {
    // API'den verileri çek
    $.ajax({
        url: '/api/report', // API endpoint URL
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            // Verileri tabloya ekle
            var table = $('#reportTable tbody');
            $.each(data, function (index, item) {
                var row = $('<tr>');
                row.append($('<td>').text(item.id));
                row.append($('<td>').text(item.location));
                row.append($('<td>').text(item.numberOfContacts));
                row.append($('<td>').text(item.numberOfPhoneNumbers));
                row.append($('<td>').text(item.uuid));
                row.append($('<td>').text(item.requestDate));
                row.append($('<td>').html(item.status ? '<b style="color:green">Hazır</b>' : 'Hazırlanıyor.'));
                table.append(row);
            });
        },
        error: function (error) {
            console.log(error);
        }
    });
});
