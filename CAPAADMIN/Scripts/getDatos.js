function deleteevent() {
    var EVENTO = {
        IdEvento: $("#IdEvento").val()
    }

    var url2 = "@Url.Action("deleteevent", "Home")";

    data = { obj: EVENTO }
    $.post(url2, data).done(function (data) {
        console.log(data);
    });


    window.location.reload()

}