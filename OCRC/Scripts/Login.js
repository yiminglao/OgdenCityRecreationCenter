$(document).ready(function () {
    testLocalStorageData();
});


function getLocalProfile(callback) {
    var profileName = sessionStorage.getItem("PROFILE_NAME");
    var email = sessionStorage.getItem("EMAIL");

    if (profileName !== null
        && email !== null) {
        callback(profileName, email);
    }
    else {
     
    }
}

function loadProfile() {
    if (!supportsHTML5Storage()) { return false; }
    getLocalProfile(function (profileName, email) {
        //changes in the UI
        $("#profile-name").html(profileName);
        $("#email").html(email);
        $("#email").hide();
        $("#rememberbox").hide();
    });
}

function supportsHTML5Storage() {
    try {
        return 'sessionStorage' in window && window['sessionStorage'] !== null;
    } catch (e) {
        return false;
    }
}

function testLocalStorageData() {
    if (!supportsHTML5Storage()) { return false; }
    function dofirst() {
        var button = document.getElementById("button");
        button.addEventListener("click", saveUserName, false);
    }
    function saveUserName() {
            var name = document.getElementById("profile-name").value;
            var username = document.getElementById("email").value;
            sessionStorage.setItem("PROFILE_NAME", name);
            sessionStorage.setItem("EMAIL", username);
    }
    window.addEventListener("load", dofirst, false);
 
}

