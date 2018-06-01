function getCookie(key) {
    var keyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
    return keyValue ? keyValue[2] : null;
}

function setCookie(key, value) {
    var expires = new Date();
    expires.setTime(expires.getTime() + (1 * 24 * 60 * 60 * 1000));
    document.cookie = key + '=' + value + ';expires=' + expires.toUTCString();
}

function logOut() {
    document.cookie = 'userName=;expires=-1';
    window.location = window.location;
}

function checkUserValidated() {
    var userHello = '';

    userHello = getCookie('userName');

    if (userHello != null && userHello != '') {
        $('.not-logged-in').hide();
        $('#logged-in').text('Hello, ' + userHello + ' !');
        $('#logout').show();

        var roleId = getCookie('roleType');

        if (roleId == '2') { // Doctor
            $('#lnkDocs').show();
            $('#lnkProc').show();
        }
        else if (roleId == '3') // Facility
        {
            $('#lnkFac').show();
            $('#lnkProc').show();
        }
        else if (roleId == '4') { // Insurer
            $('#lnkProv').show();
            $('#lnkProc').show();
        }
        else if (roleId == '5') { // Data Entry
            $('#lnkDocs').show();
            $('#lnkFac').show();
            $('#lnkProv').show();
            $('#lnkProc').show();
        }
    }
}