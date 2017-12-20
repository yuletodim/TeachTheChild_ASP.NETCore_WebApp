(function () {
    $(document).ready(function () {
        loadBooksDatatable('#booksTable', '/Moderator/Books/LoadDatatableAjax');
       
        $(document).on('click', '.deleteBook', deleteBookConfirmation);
    });

    function loadBooksDatatable(selector, url) {
        $(selector).DataTable({
            'processing': true,
            'serverSide': true,
            'filter': true,
            'orderMulti': false,
            'scrollX': true,
            'order': [[3, 'desc']],
            'ajax': {
                'url': url,
                'type': 'POST'
            },
            'deferRender': true,
            'columns': [
                { 'data': 'title' },
                { 'data': 'author' },
                { 'data': 'userName' },
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
                                '<a href="/books/' + data.id + '/' + friendlyTitle + '" class="btn btn-primary btn-sm">Book</a>' +
                                '<button type="button" data-id="' + data.id + '" data-title="' + data.title + '" class="btn btn-primary btn-sm deleteBook">Delete</button>' +
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

    function deleteBookConfirmation(e) {
        var id = $(e.target).data('id');
        var title = $(e.target).data('title');
        bootbox.confirm('Are you sure you want to delete book: \"' + title + '\"?', function (result) {
            if (result) {
                deleteBook(id, title);
            }
        });
    }

    function deleteBook(id, title) {
        var data = { id: id };
        $.ajax({
            type: 'POST',
            url: '/Moderator/Books/Delete/',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            dataType: 'json',
            success: function (result) {
                if (result.success) {
                    bootbox.hideAll();
                    $('#booksTable').DataTable().draw();
                    var deleteMessage = 'Book "' + title +'" deleted.';
                    toastr['success'](deleteMessage, 'Success');
                } else {
                    toastr['error']('Failed to delete book.', 'Error');
                }
            }
        });
    }
})();