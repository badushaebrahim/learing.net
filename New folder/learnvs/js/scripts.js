// JavaScript source code of login.js

function checkemail2() {
    let emailinput = document.getElementById("email");
    let email2value = emailinput.value.trim();
    let small = document.getElementById("emailerror");
    if (email2value === "") {
        setError2(small, "Email is Empty");
    }
    else {
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;//regex from email
        if (email2value.match(mailformat)) {
            setSuccess2(small)
        }
        else {
            setError2(small, "Invalid email format");
        }
    }
}

function checkpassword2() {

    let passwordinput = document.getElementById("pwd")
    let password2value = passwordinput.value.trim();
    let small2 = document.getElementById("pwdderror")
    if (password2value === "") {
        setError2(small2, "Password is Empty ");
    } else {
        setSuccess2(small2)
    }

}





function setError2(small, message) {
    let button = document.getElementById("submit")
    button.disabled=true
    small.className = 'smallshown';
    small.innerHTML = message;

}
function setSuccess2(small) {
    let button = document.getElementById("submit")
    small.className = 'smallhidden';
    button.disabled = false


}
// JavaScript source code of register.js

function checkname() {
    let nameinput = document.getElementById("name");
    let name2value = nameinput.value.trim();
    if (name2value === "") {
        setError(nameinput, "Empty name");
        console.log("hit")
    }
    else {
        setSuccess(nameinput)
        console.log("not")

    }
}
function checkemail() {
    let emailinput = document.getElementById("email");
    let email2value = emailinput.value.trim();
    if (email2value === "") {
        setError(emailinput, "Email is Empty");
    }
    else {
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;//regex from email
        if (email2value.match(mailformat)) {
            setSuccess(emailinput)
        }
        else {
            setError(emailinput, "Invalid email format");
        }
    }
}

//funcrtion are used ever where to sho error msg in <small> tag
function setError(input, message) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = 'smallshown';
    small.innerText = message;
    submitbutton.disabled = true

}
function setSuccess(input) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = "smallhidden"
    small.innerHTML = ""
    submitbutton.disabled = false
}
//till here

//checking password from register
function checkpwd() {
    let passwordinput = document.getElementById("password")
    let password2value = passwordinput.value.trim()
    if (password2value === "") {
        setError(passwordinput, "Empty Password")
    } else {
        setSuccess(passwordinput);
    }
}
//check re-entered password from register
function checkrepwd() {
    let passwordinput2value = document.getElementById("password").value.trim()
    let repassword = document.getElementById("repassword")
    let repassword2value = repassword.value.trim()
    if (repassword2value === "") {
        setError(repassword, "Empty Re-entered Password")
    } else {
        if (repassword2value === passwordinput2value) {
            setSuccess(repassword)
            
        }
        else {
            setError(repassword, "Password not Matching")
        }
    }

}

function checkphone() {
    var nocheckregex = /^\d+$/;
    let phoneinput = document.getElementById("phone")
    if (phoneinput.value.trim() === "") {
        setError(phoneinput, "Empty phone number")
    } else {
        if (phoneinput.value.trim().match(nocheckregex)) {
            setSuccess(phoneinput)
        } else {
            setError(phoneinput,"invalid format")
        }
    }

}
//file upload check
function checkfile(fileName) {
    let fileinput = document.getElementById("file")
    var allowed_extensions = new Array("jpg", "png", "gif");
    var file_extension = fileName.split('.').pop().toLowerCase(); // split function will split the filename by dot(.), and pop function will pop the last element from the array which will give you the extension as well. If there will be no extension then it will return the filename.

    for (var i = 0; i <= allowed_extensions.length; i++) {
        if (allowed_extensions[i] == file_extension) {
            return setError(fileinput, "File not allowed type"); // valid file extension
        }
    }

    return setSuccess(fileinput);
}
function datecheck() {
    let dateinput = document.getElementById('date');
    if (dateinput.value === "") {
        setError(dateinput, "Date of Birth is Empty")
    }
    else {
        setSuccess(dateinput)
    }
}

function loginbuttoncheck() {
    checkemail2();
    checkpassword2();
}
function registerbuttoncheck() {
    checkname();
    datecheck();
    checkemail();
    checkphone();
    checkpwd();
    checkrepwd();
}