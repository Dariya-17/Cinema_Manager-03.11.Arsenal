async function loadScreenings() {

    // 1. Вземаме стойностите от полетата
    let search = document.getElementById("search").value;
    let genre = document.getElementById("genre").value;
    let sortOrder = document.getElementById("sortOrder").value;
    // 2. Подготвяме адреса на заявката
    let params = new URLSearchParams({
        search: search,
        genre: genre,
        sortOrder: sortOrder
    });
    // 3. Изпращаме заявката към контролера
    let response = await fetch(
        "/Screening/GetFilteredScreenings?" + params
    );

    // 4. Преобразуваме JSON отговора в JavaScript обекти
    let screenings = await response.json();
    // 5. Изчистваме старите редове от таблицата
    let tbody = document.getElementById("screeningsTable");
    tbody.innerHTML = "";
    // 6. Добавяме ред за всяка намерена прожекция
    screenings.forEach(function (screening) {
        let row = document.createElement("tr");
        [screening.movieTitle, screening.genre, screening.cinemaName,
        screening.startTime, screening.hallNumber, screening.ticketPrice,
        screening.customersCount].forEach(function (value) {
            let cell = document.createElement("td");
            cell.textContent = value ?? "";
            row.appendChild(cell);
        });
        // Колона с линкове за действия
        let actions = document.createElement("td");
        ["Edit", "Details", "Delete"].forEach(function (action, index) {

            if (index > 0) {

                actions.appendChild(document.createTextNode(" | "));

            }
            let link = document.createElement("a");
            link.href = "/Screening/" + action + "/" + screening.id;
            link.textContent = action;
            actions.appendChild(link);
        });
        row.appendChild(actions);
        tbody.appendChild(row);

    });

}

// Автоматично филтриране

document.getElementById("search")

    .addEventListener("input", loadScreenings);

document.getElementById("genre")

    .addEventListener("input", loadScreenings);

document.getElementById("sortOrder")

    .addEventListener("change", loadScreenings);

// Изчистване на филтрите

document.getElementById("clearFilters")

    .addEventListener("click", function () {

        document.getElementById("search").value = "";

        document.getElementById("genre").value = "";

        document.getElementById("sortOrder").value = "title_asc";

        loadScreenings();

    });