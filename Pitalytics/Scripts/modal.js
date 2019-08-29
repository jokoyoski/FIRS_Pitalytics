$(".modal").on('show.bs.modal', function (e) {
    var caller = e.relatedTarget;
    var modalTitle = $(caller).data("title");
    $("#modalLabel").html(modalTitle);
    var url = $(caller).attr("href");
    $.get(url, function (response) {
        $(".modal-body").html(response);
    });

})

$(".modal").on('hidden.bs.modal', function (e) {
    var ajaxLoader = "<img src='/Content/Images/ajaxLoaderBlue.gif' alt='Viewing page...' />";
    $(".modal-body").html(ajaxLoader);
}); 