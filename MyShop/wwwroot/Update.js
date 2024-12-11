const title = document.querySelector("#title")
title.textContent = `${JSON.parse(sessionStorage.getItem('user')).firstName} you logged successfully!`

const toUpdate = () => {
    const update = document.querySelector("#update");
    update.style.visibility = 'visible';
}

const getDataFromForm = () => {
    const email = document.querySelector("#email").value;
    const password = document.querySelector("#password").value;
    const firstName = document.querySelector("#firstName").value;
    const lastName = document.querySelector("#lastName").value;
    return { email, password, firstName, lastName };
}

const updateUser = async () => {
    const user = getDataFromForm();
    try {
        const responsePost = await fetch(`api/users/${JSON.parse(sessionStorage.getItem('user')).userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (responsePost.status == 204) {
            alert("weak password")
        }
        if (responsePost.status == 400) {
            alert("user not found")
        }
        else if (!responsePost.ok) {
            alert("Error, please try again")
        }
        else {
            const data = await responsePost.json();
            sessionStorage.setItem('user', JSON.stringify(data))
            alert(`${data.email} updated`);
        }
    }
    catch (error) {
        throw error;
    }
}
const checkpassword = async () => {
    const password = document.querySelector("#password").value;
    const score = document.querySelector("#score");
    try {
        const responsePost = await fetch('api/users/password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });
        const data = await responsePost.json();
        score.value = data;
    }
    catch (error) {
        throw error;
    }
}