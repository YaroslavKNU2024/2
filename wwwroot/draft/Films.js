const uri = 'api/Films';
let films = [];

function getFilms() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFilms(data))
        .catch(error => console.error("Films not found", error));
}

function addFilm() {
    const addNameTextbox = document.getElementById('add-name');

    const film = {
        filmName: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(film)
    })
        .then(response => response.json())
        .then(() => {
            getFilms();
            addNameTextBox.value = '';
        })
        .catch(error => console.error('Cannot add a new Film', error));
}

function deleteFilm(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFilms())
        .catch(error => console.error('Cannot delete film.'), error);
}

function editFilm(id) {
    const film = films.find(film => film.id === id);

    document.getElementById('edit-id').value = film.id;
    document.getElementById('edit-name').value = film.filmName;
    document.getElementById('editForm').style.display = 'block';
}

function updateFilm() {
    const filmId = document.getElementById('edit-id').value;
    const film = {
        id: parseInt(filmId, 10),
        filmName: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${filmId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(film)
    })
        .then(() => getFilms())
        .catch(error => console.error('Cannot update Film', error));

    closeInput();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = none;
}

function _displayFilms(data) {
    const tBody = document.getElementById('films');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(film => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick', `editFilm(${film.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteFilm(${film.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(film.filmName);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    films = data;
}
