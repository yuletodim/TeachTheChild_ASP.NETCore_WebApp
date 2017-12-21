(function () {
    $(document).ready(function () {
        loadDownloadsDatatable('#booksTable', '/Moderator/Downloads/LoadDatatableAjax');

        $(document).on('click', '.deleteDownload', deleteDownloadsConfirmation);
    });

    function loadDownloadsDatatable(selector, url) {
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
                { 'data': 'id' },
                { 'data': 'user' },
                {
                    'data': 'createdOn',
                    'render': function (createdOn) {
                        if (createdOn)
                            return moment(createdOn).format('DD-MM-YYYY');
                        return '';
                    }
                },
                { 'data': 'downloads' },
                {
                    'data': 'id',
                    'render': function (id) {
                        var buttons =
                            '<div class="btn-group">' +
                            '<a href="javascript:;" class="btn btn-primary btn-sm view-picture" data-id="' + id + '">Picture</a>' +
                                '<button type="button" data-id="' + id + '" class="btn btn-primary btn-sm deleteDownload">Delete</button>' +
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

    function deleteDownloadsConfirmation(e) {
        var id = $(e.target).data('id');
        bootbox.confirm('Are you sure you want to delete material: ' + id + '?', function (result) {
            if (result) {
                deleteBook(id);
            }
        });
    }

    function deleteBook(id) {
        var data = { id: id };
        $.ajax({
            type: 'POST',
            url: '/Moderator/Downloads/Delete/',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            dataType: 'json',
            success: function (result) {
                if (result.success) {
                    bootbox.hideAll();
                    $('#booksTable').DataTable().draw();
                    var deleteMessage = 'Material: "' + id + '" deleted.';
                    toastr['success'](deleteMessage, 'Success');
                } else {
                    toastr['error']('Failed to delete book.', 'Error');
                }
            }
        });
    }

})();