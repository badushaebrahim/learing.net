// JavaScript source code

function checkname() {
    let nameinput = document.getElementById("name");
    let name2value = nameinput.value.trim();
    if (name2value === "") {
        setError(nameinput, "empty name");
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

function checkpassword() {

}

function setError(input, message) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = 'smallshown';
    small.innerText = message;
    submitbutton.disabled=true

}
function setSuccess(input) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = "smallhidden"
    small.innerHTML= ""
    submitbutton.disabled = false
}

