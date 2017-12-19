(function () {
    $(document).ready(function () {
        loadBooksDatatable('#booksTable', '/Moderator/Downloads/LoadDatatableAjax');

        $(document).on('click', '.deleteDownload', deleteDownload);
    });

    function loadBoosDatatable(selector, url) {
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
                { 'data': 'id' },
                { 'data': 'author' },
                {
                    'data': { id: 'userId', userName: 'userName' },
                    'render': function (data) {
                        return '<a href="javascript:;"data-id="' + data.userId + '" class="btn btn-primary btn-sm details">' + userName + '</a>';
                    },
                },
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
                                '<a href="/downloads/details/' + id + '" class="btn btn-primary btn-sm">Picture</a>'
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

})();