(function () {
    $(window).load(function () {
        setFooterPosition();
        $(window).on('resize', setFooterPosition);
        toastr.options = { "positionClass": "toast-top-center" };
        // $('.alert').fadeOut(10000);
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

   


})();
