function kullaniciSil(kullanici_id) {

    bootbox.confirm('Kullanıcıyı silmek istiyor musunuz?', function (cevap) {

        if (cevap) {

            $.ajax({
                //JSON
                url: '/Arac/sil',
                data: { id: kullanici_id },
                success: function (sonuc) {
                    //AJAX ile web sayfası yüklendikten sonra, sunucu üzerine veri göndermek ve sunucudan veri almak mümkündür.Böylece, sayfa yenilenmeden, sayfanın belirli bir bölümünün, sunucu tarafından alınan verilerle yenilenebilir.

                    bootbox.alert(sonuc);
                    $('#satir_' + kullanici_id).remove();
                },
                error: function () {

                }
            });

        }
        else {
            bootbox.alert('Silme işlemi iptal edildi.');
        }

    })
}

function guncelle(satir_id) {
    var marka = document.getElementById('marka_' + satir_id);
    var plaka = document.getElementById('plaka_' + satir_id);
    var yil = document.getElementById('yil_' + satir_id);
    var yakit = document.getElementById('yakit_' + satir_id);
    var durum = document.getElementById('durumlar_' + satir_id);
    var vites = document.getElementById('vites_' + satir_id);
    var img = document.getElementById('img_' + satir_id);

    if ((marka.value != '') && (plaka.value != '')) {
        var dataBilgi = {};
        dataBilgi.arac = { id: satir_id, Marka: marka.value, Plaka: plaka.value, Yakıt_Tipi: yakit.value, Yıl: yil.value, Vites: vites.value, Durum: durum.value};

        $.ajax({
            url: '/Arac/guncelle',
            data: dataBilgi,
            type: 'POST',
            success: function (cevap) {
                bootbox.alert('Bilgiler guncellendi');
            }
        })
    }

    else {
        bootbox.alert('Alanlari bos birakmayiniz');
    }
}


function musteriSil(kullanici_id) {

    bootbox.confirm('Kullanıcıyı silmek istiyor musunuz?', function (cevap) {

        if (cevap) {

            $.ajax({
                //JSON
                url: '/Musteri/sil',
                data: { id: kullanici_id },
                success: function (sonuc) {
                    //AJAX ile web sayfası yüklendikten sonra, sunucu üzerine veri göndermek ve sunucudan veri almak mümkündür.Böylece, sayfa yenilenmeden, sayfanın belirli bir bölümünün, sunucu tarafından alınan verilerle yenilenebilir.

                    bootbox.alert(sonuc);
                    $('#satir_' + kullanici_id).remove();
                },
                error: function () {

                }
            });

        }
        else {
            bootbox.alert('Silme işlemi iptal edildi.');
        }

    })
}

function musteriGuncelle(satir_id) {
    var Ad_Soyad = document.getElementById('Ad_Soyad_' + satir_id);
    var Email = document.getElementById('Email_' + satir_id);
    var dogumYili = document.getElementById('Dogum_Yili_' + satir_id);
    var telefon = document.getElementById('telefon_' + satir_id);
    if ((Ad_Soyad.value != '') && (Email.value != '')) {
        var dataBilgi = {};
        dataBilgi.musteri = { id: satir_id, Ad_Soyad: Ad_Soyad.value , Email: Email.value, Dogum_Yili: dogumYili.value, Telefon: telefon.value };

        $.ajax({
            url: '/Musteri/guncelle',
            data: dataBilgi,
            type: 'POST',
            success: function (cevap) {
                bootbox.alert('Bilgiler guncellendi');
            }
        })
    }

    else {
        bootbox.alert('Alanlari bos birakmayiniz');
    }
}

function fotoDegistir(satir_id) {
    var formData = new FormData();
    var foto = document.getElementById("foto_" + satir_id);
    var logo = document.getElementById("logo_" + satir_id);

    for (i = 0; i < foto.files.length; i++) {
        formData.append(foto.files[i].name, foto.files[i]);
    }


    formData.append("id", satir_id);

    var xhr = new XMLHttpRequest();
    //XML
    xhr.open('POST', '/Arac/fotoDegistir');
    xhr.send(formData);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {

            logo.src = '/images/' + foto.files[0].name;
            bootbox.alert("Foto yenilendi");

        }
    }

}

function ilceSec() {
    var sehirid = $('#sehir').val();

    $.ajax({
        url: "/Musteri/ilceList",
        type: "GET",
        dataType: "JSON",
        data: { id: sehirid },
        success: function (cevap) {
            $('#ilce').html("");
            var myOptions = {
                val1: 'text1',
                val2: 'text2'
            };
            $.each(cevap, function (i, Ilce) {
                $('#ilce').append(new Option(Ilce.Text), Ilce.Value);
            });
        }
    });
}