(function () {
    $(window).load(function () {
        setFooterPosition();
        $(window).on('resize', setFooterPosition);
        toastr.options = { "positionClass": "toast-top-center" };
        $(document).on('click', '.userDetails', showUserDetails);
    });

    function setFooterPosition() {
        var body = document.body;
        var html = document.documentElement;

        if (html.clientHeight >= body.offsetHeight) {
            $('footer').css({
                'position': 'fixed',
                'left': '0px',
                'bottom': '0px',
                'width': '100%'
            });
        } else {
            $('footer').css({
                'position': 'relative'
            });
        }
    }

    function showUserDetails(e) {
        var userId = $(e.target).data('id');
        var url = '/Admin/Users/GetUserAjax?id=' + userId;
        $.get(url, function (data) {
            var dialog = bootbox.dialog({
                message: data
            });
        });
    }

   


})();
