# Pelinkehityshaasteet
Tämä Github projekti sisältää kesällä 2021 Jyväskylän yliopiston *Pelinkehityshaaste* -kurssilla luotuja tuotoksia. Kyseisellä kurssilla tuli suunnitella ja toteuttaa peli tyhjästä tiettyjen rajoitteiden puitteissa kahdessa viikossa. Ensimmäinen viikko käytettiin suunnitteluun ja toinen viikko toteutukseen.
Kyseisellä kurssilla toteutin kolme pienimuotoista peliprototyyppiä Unity-pelimoottorilla C#-kielellä.

## Kansioiden sisältö
Kukin kansio sisältää Builds-kansion jossa on pelattava peliprototyyppi, sekä Scripts-kansion joka sisältää kaikki projektissa käytetyt C#-koodit. Koko Unity-projektia ei valitettavasti Githubin kokorajoitteiden takia voi lisätä.

## Pelit

### Binary Dungeon
Tarkoituksena oli luoda tietotekniikkaan ja informaatioteknologiaan liittyvä opetuspeli. Päädyin luomaan binäärinumeroiden opettamiseen keskittyvän pelin nimellä Binary Dungeon. Pelissä pelaajan hahmo on lukittu huoneeseen, jonka seinältä löytyy 8 soihtua. Huppupäinen hahmo kertoo pelaajalle numeron, jonka pelaaja on esitettävä binäärisesti soihtujen avulla. Kukin soihtu vastaa 8-lukuisen binäärinumeron paikkaa; sytytetyt soihdut ovat ykkösiä ja loput nollia. Oikean kombinaation löydettyään ovi aukeaa ja pelaaja voi läpäistä tason ja alkaa suorittamaan seuraavaa numeroa.

### Tuho
Tehtävänantona oli luoda devoluutio eli yksinkertaisempi versio olemassa olevasta pelistä. Loin alkuperäiseen [Doom](https://en.wikipedia.org/wiki/Doom_(1993_video_game)) -peliin perustuvan 2D top down shooter pelin nimeltä Tuho.
Peli koostuu vain yhdestä tasosta, jossa pelihahmoa liikutetaan nuolinäppäimillä ja vihollisia ammutaan välilyönnillä.
Tarkoituksena on löytää kentän loppu ja kerätä matkalla esineitä.
Pelissä käytettiin kolmannen osapuolen A* reitinhakualgorytmiä vihollisten tekoälyn toteuttamiseen.

### Typing Fast Food
Tehtävänantona oli luoda peli, joka käyttää epätavallista kontrollimekaniikkaa (eli ei typpillistä hiirellä tai nuolinäppäimillä ohjattavuutta).
Toteutin [Typing of the Dead](https://en.wikipedia.org/wiki/The_Typing_of_the_Dead) -pelin inspiroimana oman näkökulmani aiheesta nimellä Typing Fast Food.
Kyseisessä pelissä pelaaja on pikaruokaketjun työntekijä, joka palvelee asiakkaita kirjoittamalla heidän tilauksensa ylös.
Asiakas kävelee pelaajan tiskille ja ruudulle ilmeentyy heidän tilauksensa, jonka pelaajan tulee toistaa näppäimistöllä, jolloin tilaus muuttuu vihreäksi.
Pelaajan onnistuessa hänen rahatilinsä kasvaa ja asiakasta poistuu tyytyväisenä.
Mikäli pelaaja ei saa kirjoitettua tilausta tarpeeksi nopeasti, asiakas ei ole tyytyväinen palveluun ja poistuu.
Viiden tyytymättömän asiakkaan jälkeen peli päättyy.

