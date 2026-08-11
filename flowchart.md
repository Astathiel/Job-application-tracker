flowchart TD
    Start([Käynnistää ohjelman]) --> CheckFile{Etsii data.json}
    CheckFile -- Kyllä --> LoadData[Lataa tallennetut tiedot taulukkoon]
    CheckFile -- Ei --> CreateEmpty[Luo tyhjän taulukon]

    LoadData --> Idle([Odottaa käyttäjän toimintoa)]
    CreateEmpty --> Idle

    Idle --> ClickSave[Käyttäjä tallentaa tiedot 'Save' nappulasta]

    ClickSave --> Validate{Tarkistaa onko pakolliset kentät täytetty}

    Validate -- Ei --> ShowError[Näyttää käyttäjälle virheilmoituksen]

    ShowError --> Idle

    Validate -- Kyllä --> CreateObject[Luo olion]
    CreateObject --> AddToList[Lisää olion listaan]
    AddToList --> SaveJson[Tallentaa tiedot data.json tai ylikirjoittaa olevan relevantin datan]
    SaveJson --> RefreshIU[Päivittää taulukon]
    RefreshUI --> ClearFields[Tyhjentää syöttökentät]
    ClearFields --> Idle
