(function () {
    $(document).ready(function () {
        $(document).on('click', '.addComment', addComment);
    });

    function initValidation() {
        $('.comment-form').validate({
            submitHandler: addComment,
            rules: {
                MaterialId: 'required',
                Role: 'required'
            }
        });
    }

    function addComment(e) {
        var articleId = $(e.target).data('materialid');
        var content = $
    }

    function addComment(form, e) {
        if ($(form).valid()) {
            var a = form;
            $.post('/Articles/AddCommentAjax/', $('.comment-form').serialize(), function (result) {
                bootbox.hideAll();
                if (result.success) {
                    toastr['success']("User added to role.");
                } else {
                    toastr['error']("Cannot add user to role.");
                }
            });
        }
    }

})();