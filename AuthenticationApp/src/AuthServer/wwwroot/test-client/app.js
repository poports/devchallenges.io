const host = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '');
 
var config = {
    authority: "https://localhost:44343",
    client_id: "AuthenticationApp",
    redirect_uri: "https://localhost:44343/authentication/login-callback",
    response_type: "code",
    scope: "AuthServerAPI openid profile",
    filterProtocolClaims: true,
    loadUserInfo: true
};

var mgr = new Oidc.UserManager(config);

mgr.getUser().then(function (user) {
    if (user) {
        log("User logged in", user.profile);
    }
    else {
        log("User not logged in");
    }
});

function login() {
    mgr.signinRedirect();
}

function log() {
    document.getElementById('results').innerText = '';

    Array.prototype.forEach.call(arguments, function (msg) {
        if (msg instanceof Error) {
            msg = "Error: " + msg.message;
        }
        else if (typeof msg !== 'string') {
            msg = JSON.stringify(msg, null, 2);
        }
        document.getElementById('results').innerHTML += msg + '\r\n';
    });
}