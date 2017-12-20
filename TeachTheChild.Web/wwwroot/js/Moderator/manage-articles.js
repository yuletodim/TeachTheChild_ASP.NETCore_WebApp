(function () {
    $(document).ready(function () {
        loadArticlesDatatable('#articlesTable', '/Moderator/Articles/LoadDatatableAjax');

        $(document).on('click', '.deleteArticle', deleteArticleConfirmation);
    });

    function loadArticlesDatatable(selector, url, common) {
        $(selector).DataTable({
            'processing': true,
            'serverSide': true,
            'filter': true,
            'orderMulti': false,
            'scrollX': true,
            'order': [[2, 'desc']],
            'ajax': {
                'url': url,
                'type': 'POST'
            },
            'deferRender': true,
            'columns': [
                { 'data': 'title' },
                { 'data': 'author' },
                {
                    'data': 'createdOn',
                    'render': function (createdOn) {
                        if (createdOn)
                            return moment(createdOn).format('DD-MM-YYYY');
                        return '';
                    }
                },
                { 'data': 'commentsCount' },
                { 'data': 'likesCount' },
                { 'data': 'dislikesCount' },
                {
                    'data': { id: 'id', title: 'title' },
                    'render': function (data) {
                        var friendlyTitle = makeUrlSeoFriendly(data.title);
                        var buttons =
                            '<div class="btn-group">' +
                            '<a href="/articles/' + data.id + '/' + friendlyTitle + '" class="btn btn-primary btn-sm">Article</a>' +
                            '<button type="button" data-id="' + data.id + '" data-title="' + data.title + '" class="btn btn-primary btn-sm deleteArticle">Delete</button>' +
                            '</div>';

                        return buttons;
                    },
                    'sortable': false,
                    'searchable': false
                }
            ],
            'language': {
                'paginate': {
                    'previous': '<<',
                    'next': '>>'
                },
                'processing': '<img src="/images/loading.gif">'
            }
        });
    }

    function deleteArticleConfirmation(e) {
        var id = $(e.target).data('id');
        var title = $(e.target).data('title');
        bootbox.confirm('Are you sure you want to delete article: \"' + title + '\"?', function (result) {
            if (result) {
                deleteArticle(id, title);
            }
        });
    }

    function deleteArticle(id, title) {
        var data = { id: id };
        $.ajax({
            type: 'POST',
            url: '/Moderator/Articles/Delete/',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            dataType: 'json',
            success: function (result) {
                if (result.success) {
                    bootbox.hideAll();
                    $('#articlesTable').DataTable().draw();
                    var deleteMessage = 'Article "' + title + '" deleted.';
                    toastr['success'](deleteMessage, 'Success');
                } else {
                    toastr['error']('Failed to delete article.', 'Error');
                }
            }
        });
    }
})();