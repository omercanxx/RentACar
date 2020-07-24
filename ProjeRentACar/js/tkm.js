var slayt = document.getElementsByClassName("slayt");

var slaytSayisi = slayt.length;
var slaytNo = 0;
//slaytGoster(slaytNo);
function slaytGoster(SlaytNumarasi) {
    slaytNo = SlaytNumarasi;

    if (SlaytNumarasi >= slaytSayisi) {
        slaytNo = 0;
    }
    if (SlaytNumarasi < 0) {
        slaytNo = slaytSayısı - 1;
    }
    for (i = 0; i < slaytSayisi; i++) {
        slayt[i].style.display = "none";
    }
    slayt[slaytNo].style.display = "block";
}

// var timer = setInterval(function(){
//     slaytNo++;
//     slaytGoster(slaytNo);
// },1000);
var turn = document.getElementById("turn");
var id;
function oyna() {
    rand = Math.floor(Math.random() * 3);
    if (id == 0) {
        if (rand == 0) {
            turn.innerHTML = "BERABERE";
        }
        else if (rand == 1) {
            turn.innerHTML = "YENİLDİNİZ";
        }
        else {
            turn.innerHTML = "YENDİNİZ";
        }
    }
    else if (id == 1) {
        if (rand == 0) {
            turn.innerHTML = "YENDİNİZ";
        }
        else if (rand == 1) {
            turn.innerHTML = "BERABERE";
        }
        else {
            turn.innerHTML = "YENİLDİNİZ";
        }
    }
    else {
        if (rand == 0) {
            turn.innerHTML = "YENİLDİNİZ";
        }
        else if (rand == 1) {
            turn.innerHTML = "YENDİNİZ";
        }
        else {
            turn.innerHTML = "BERABERE";
        }
    }
    slaytGoster(rand);
}

function selected(clicked_id) {
    id = clicked_id;
}
