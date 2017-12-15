(function () {
    $(window).load(function () {
        setFooterPosition();
        $(window).on('resize', setFooterPosition);

        $('.alert').fadeOut(10000);
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

    var obj = {};
    $.ajax({
        type: 'GET',
        url: '/my/url',
        .....,
        .....,
        success: function (result) {
            // Calbaclk here: call me  when you get result :)
            obj = result;

            // Or just call function 
            myFunction(obj, result);
        }
    })

    function myFunction(obj, result) {
        // More logic here 
    }


})();
