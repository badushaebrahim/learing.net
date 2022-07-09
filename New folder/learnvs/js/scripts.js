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
   // var nocheckregex = /^\d+$/;
    let phoneinput = document.getElementById("phone")
    if (phoneinput.value.trim() === "") {
        setError(phoneinput, "Empty phone number")
    } else {
       /* if (phoneinput.value.trim().match(nocheckregex)) {
            setSuccess(phoneinput)
        } else {
            setError(phoneinput,"invalid format")
        }*/
        if (isNaN(phoneinput.value.trim())) {
            setSuccess(phoneinput)
        } else {
            setError(phoneinput,"Sent only Numbers")
        }
    }

}
//file upload check
function checkfile() {
    let fileinput = document.getElementById("file")
    //let filename = fileinput.value.substr(fileinput.value.lastIndexOf('\\') + 1).split('.')[0];
    if (fileinput.value.trim() === "") {
        setError(fileinput,"No file Selected")
    } else {
        var allowed_extension = ["png", "jpg", "jpeg"]
        var flag = 0;
        let extension = fileinput.value.split('.')[1];
        for (i = 0; i < allowed_extension.length; i++) {
            if (extension == allowed_extension[i]) {
                flag++;
            }
        }
        if (flag == 0) {
            setError(fileinput, "Not Allowed file type try: jpg,png,jpeg")
        }
        else {
            setSuccess(fileinput)
        }
    }
    

   
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
    checkfile()
}