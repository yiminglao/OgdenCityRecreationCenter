$(document).ready(function () {
    // get access info and set nav buttons
    if ($('input[name=access]').val() == '1') {
        $('#userLinks').append('<li><a href="/Account/UserList">Admin</a></li>');
    }
    if ($('input[name=team]').val().length > 0) {
        $("#teamSelector").show();
        $('#userLinks').append('<li><a href="/home/result">' + $('input[name=team]').val() + '</a></li>');
    }
    if ($('input[name=school]').val().length > 0) {
        $("#schoolSelector").show();
        $('#userLinks').append('<li><a href="/home/result">' + $('input[name=school]').val() + '</a></li>');
    }

    // check to see if coach or school is checked then show or hide accordingly 
    if ($("#role_2_").prop('checked')) {
        $("#teamSelector").show();
    } else {
        $("#teamSelector").hide();
    }
    if ($("#role_3_").prop('checked')) {
        $("#schoolSelector").show();
    } else {
        $("#schoolSelector").hide();
    }

    // show and hide coach or school
    $("#role_2_").on("change", function () {
        if ($("#role_2_").prop('checked')) {
            $("#teamSelector").show();
        } else {
            $("#teamSelector").hide();
        }
    })
    $("#role_3_").on("change", function () {
        if (this.checked) {
            $("#schoolSelector").show();
        } else {
            $("#schoolSelector").hide();
        }
    })
});
