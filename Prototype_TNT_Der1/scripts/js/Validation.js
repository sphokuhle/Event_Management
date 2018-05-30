
function checkName() {
    var Username = document.getElementById('<%=txtName.ClientID %>').value;
   if (Username == " ") {
        alert("No Data Entered");
       return false;

    }
    else if (Username != " ") {

        document.getElementById("<%=txtName.ClientID %>").class = "valid";
        return true;
    }
}

function checkName() {
    var Username = document.getElementById('<%=txtLogName.ClientID %>').value;
    if (Username == " ") {
        alert("No Data Entered");
        return false;

    }
    else if (Username != " ") {

        document.getElementById("<%=txtLogName.ClientID %>").class = "valid";
        return true;
    }
}

function checkSurname() {
    var Surname = document.getElementById("txtSurname").value;
    if (Surname.length < 2) {
        document.getElementById("txtSurname").style.borderColor = "red";
        return false;

    }
    else if (Surname.length > 2) {

        document.getElementById("txtSurname").style.borderColor = "green";
        return true;
    }
}

function checkPhnNumber() {

    var phone = document.getElementById("phone").value;
    var phoneNum = phone.replace(/[^\d]/g, '');

    if (phone.length > 6 && phone.length < 11) {
        document.getElementById("mySpan").style.visibility = 'hidden';
        document.getElementById("phone").className = 'valid';
        return true;
    } else if (phone.length < 7 || phone.length > 10) {
        document.getElementById("phone").className = 'error';
        document.getElementById("mySpan").style.visibility = 'visible';
        return false;
    }
    else if (phone.value.length == "") {
        document.getElementById("phone").className = 'empty';
    }
}

function checkEmail() {
    var email = document.getElementById('txtEmail').valueOf;
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!filter.test(email.value)) {
        document.getElementById("txtEmail").style.borderColor = "red";
        return false;
    }
    else if (filter.test(email.value)) {
        document.getElementById("txtEmail").style.borderColor = "green";
        return true;
    }
}


function checkPassword() {

}


function isNumeric(keyCode) {
    return ((keyCode >= 48 && keyCode <= 57) || keyCode == 8)
}