//function clearTextBox() {
//    $("#firstname").val("");
//    $("#lastname").val("");
//    $("#email").val("");
//    $("#address").val("");
//    $("#gender").val("");
//    $("#contact").val("");
//    $("#dob").val("");
//    $("#password").val("");
//    $("#confirm").val("");
 
//    $('#firstname').css('border-color', 'lightgrey');
//    $('#lastname').css('border-color', 'lightgrey');
//}



function registered() {
    var res = validate();
    if (res = false) {
        return false;
    }

    var regObj = {
        FirstName: $("#firstname").val(),
        LastName: $("#lastname").val(),
        Email: $("#email").val(),
        Address: $("#address").val(),
        Gender: $("#gender").val(),
        Contact: $("#contact").val(),
        DOB: $("#dob").val(),
        Password: $("#password").val(),
        Confirm: $("#confirm").val()
    };

    $.ajax({
        url: "/Login/index",
        datatype: "json",
        contentType: "application/json;charset=urf-8",
        type: "POST",
        data: JSON.stringify(regObj),
        success: function (result) {
            if (result == true) {
                console.log(result);
                alert("Registered Successfully");
            } else {
                alert("something wrong");
            }
        },
    
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}







function validate() {
    var isValid = true;
    if ($('#firstname').val().trim() == "") {
        $('#firstname').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#firstname').css('border-color', 'lightgrey');
    }
    if ($('#lastname').val().trim() == "") {
        $('#lastname').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#lastname').css('border-color', 'lightgrey');
    }
    if ($('#email').val().trim() == "") {
        $('#email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#email').css('border-color', 'lightgrey');

    }
    if ($('#address').val().trim() == "") {
        $('#address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#address').css('border-color', 'lightgrey');
    }
    if ($('#gender').val().trim() == "") {
        $('#gedner').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#gender').css('border-color', 'lightgrey');
    }
    if ($('#contact').val().trim() == "") {
        $('#contect').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#contact').css('border-color', 'lightgrey');
    }
    if ($('#dob').val().trim() == "") {
        $('#dob').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dob').css('border-color', 'lightgrey');
    }
    if ($('#password').val().trim() == "") {
        $('#password').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#password').css('border-color', 'lightgrey');
    }
    if ($('#confirm').val().trim() == "") {
        $('#confirm').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#confirm').css('border-color', 'lightgrey');
    }
    return isValid;
}