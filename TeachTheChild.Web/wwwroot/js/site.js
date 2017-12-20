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

function makeUrlSeoFriendly(url) {
    var encodedUrl = url.toLowerCase();
    encodedUrl = encodedUrl.split(/\&+/).join("-and-")
    encodedUrl = encodedUrl.split(/[^a-z0-9]/).join("-");
    encodedUrl = encodedUrl.split(/-+/).join("-");
    encodedUrl = encodedUrl.trim('-');

    return encodedUrl; 
}

   
$(window).load(function () {
    setFooterPosition();

    $(window).on('resize', setFooterPosition);

    toastr.options = { 'positionClass': 'toast-top-center' };

    $(document).on('click', '.userDetails', showUserDetails);
});

