(function () {
    $(document).ready(function () {
        $(document).on('click', '.like-video', likeVideo);

    });

    function likeVideo(e) {
        var id = $(e.target).data('id');
        var likeValue = $(e.target).data('likevalue');
        var url = '/Videos/LikeVideoAjax/' + id + "likeValue=" + likeValue;
        $.get(url, function (data) {
            if (result.success) {
                var count = Number($('#downloadsCount').text());
                count++;
                $('#downloadsCount').text(count)
                var message = likeValue ? 'You liked this video' : 'You dislike this video';
                toastr['success']("User added to role.");
            } else {
                toastr['error']('You cannot evaluate this video.');
            }
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