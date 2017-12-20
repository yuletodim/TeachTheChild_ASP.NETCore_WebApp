(function () {
    $(document).ready(function () {
        loadUsersDatatable('#usersTable', '/Admin/Users/LoadDatatableAjax');
        $(document).on('click', '.add-to-role', addUserToRole);
    });

    function loadUsersDatatable(selector, url) {
        var roleValue = $('#role').data('id');
        if (roleValue){
            url += '?role=' + roleValue;
        }
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
                { 'data': 'userName' },
                { 'data': 'name' },
                { 'data': 'email' },
                {
                    'data': 'createdOn',
                    'render': function (createdOn) {
                        if (createdOn)
                            return moment(createdOn).format('DD-MM-YYYY');
                        return '';
                    }
                },
                {
                    'data': {id: 'id', userName: 'userName'},
                    'render': function (data) {
                        var buttons =
                            '<div class="btn-group">' +
                            '<button type="button" data-id="' + data.id + '" class="btn btn-primary btn-sm userDetails">Details</button>' +
                                '<button type="button" data-id="' + data.id + '" data-username="' + data.userName + '" class="btn btn-primary btn-sm add-to-role">Add to role</button>' +
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

    function addUserToRole(e) {
        var userId = $(e.target).data('id');
        var username = $(e.target).data('username');
        var title = 'Add user ' + username + ' to role';
        var url = '/Admin/Users/AddUserToRoleGetAsync?userId=' + userId;
        $.get(url, function (data) {
            var dialog = bootbox.dialog({
                message: data
            });
            $('#user-details > ul > li.bootbox-header > h3').text(title);

            dialog.init(function () {
                initValidation();
                $('#cancelAddToRole').on('click', closeModal);
            });
        });
    }

    function initValidation () {
        $('.role-form').validate({
            submitHandler: formSubmit,
            rules: {
                UserId: 'required',
                Role: 'required'
            }
        });
    }

    function closeModal() {
        bootbox.hideAll();
    }

    function formSubmit(form, e) {
        if ($(form).valid()) {
            var a = form;
            $.post('/Admin/Users/AddToRole', $('.role-form').serialize(), function (result) {
                bootbox.hideAll();
                if (result.success) {
                    toastr['success']('User added to role.', 'Success');
                } else {
                    toastr['error']('Cannot add user to role.', 'Error');
                }
            });
        }       
    }
})();