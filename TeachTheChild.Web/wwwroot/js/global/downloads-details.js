(function () {
    $(document).ready(function () {
        $(document).on('click', '.view-picture', showDetails);
        $(document).on('click', '.download-picture', downloadPicture);
    });

    function showDetails(e) {
        var id = $(e.target).data('id');
        var url = '/Downloads/GetAjax/' + id;
        $.get(url, function (data) {
            var dialog = bootbox.dialog({
                message: data
            });
        });
    }

    function downloadPicture(e) {
        var count = Number($('#downloadsCount').text());
        count++;
        $('#downloadsCount').text(count)
        var id = $(e.target).data('id');
        window.location = '/downloads/download/' + id;

    }
})();