(function () {
    $(document).ready(function () {
        $(document).on('click', '.like-book', likeBook);
        initCommentFormValidation();
    });

    function likeBook(e) {
        var id = $(e.target).data('id');
        var likeValue = $(e.target).data('likevalue');

        var data = { id: id, isLike: likeValue };

        $.ajax({
            type: 'POST',
            url: '/Books/LikeBookAjax',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            dataType: 'json',
            success: function (result) {
                if (result.success) {
                    $('#material-likes').text(result.likes);
                    $('#material-dislikes').text(result.dislikes);
                    var message = likeValue ? 'You liked this book' : 'You dislike this book';
                    toastr['success'](message, 'Success');
                } else {
                    toastr['error']('You cannot evaluate this book.', 'Error');
                }
            }
        });
    }

    function initCommentFormValidation() {
        $('.comment-form').validate({
            submitHandler: addComment,
            rules: {
                Id: 'required',
                Content: 'required'
            }
        });
    }

    function addComment(form, e) {
        if ($(form).valid()) {
            $.post('/Books/AddCommentAjax', $('.comment-form').serialize(), function (result) {
                if (result.success) {
                    var p = $('#noComment');
                    if (p) {
                        $(p).hide();
                    }

                    var user = $('#currentUser').val();
                    var text = $('#textarea-comment').val();
                    $('#textarea-comment').val('');

                    document.getElementById('comments-list').innerHTML += '<li class="h-title"><div><strong>' + user + ': </strong>' + text + '</div></li>';
                    toastr['success']('Your comment was added.', 'Success');
                } else {
                    toastr['error']('Add comment failed.', 'Error');
                }
            });
        }
    }

})();