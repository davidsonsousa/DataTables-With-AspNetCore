$(document).ready(function () {
    $("#table-list").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            type: "POST",
            url: "home/getpeopledata"
        }
    });
});
