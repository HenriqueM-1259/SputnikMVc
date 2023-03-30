//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.
//var myDiv = document.querySelector(".card");
//console.log(myDiv)
//debugger
//// Obtenha a referência ao elemento de áudio
//const audioElement = document.getElementById('MusicaPlayer');

//// Obtenha o estado atual da música do localStorage
//const audioURL = localStorage.getItem('audioURL');

//// Se o tempo atual da música existir no localStorage, defina-o no elemento de áudio
//if (audioURL !== null) {
//    MusicaPlayer.setAttribute('src', audioURL);
//    MusicaPlayer.play();
//}



//function playMusica(id) {
//    debugger
//    var MusicaPlayer = document.getElementById('MusicaPlayer');
//    var baseUrl = window.location.protocol + "//" + window.location.hostname;
//    if (window.location.port) {
//        baseUrl += ":" + window.location.port;
//    }
//    debugger
//    var xhr = new XMLHttpRequest();
//    xhr.open('GET', `${baseUrl}/Musica/GetArquivoMp3?id=${id}`, true);
//    xhr.responseType = 'arraybuffer';

//    xhr.send();
//    xhr.onload = function () {
//        if (xhr.status === 200) {
//            debugger
//            var blob = new Blob([xhr.response],
//                { type: 'audio/mpeg' });
//            var url = URL.createObjectURL(blob);
//            var audio = new Audio(url);
//            //audio.play();
//            MusicaPlayer.setAttribute('src', url);
//            MusicaPlayer.play();

//        }
//    };
//    localStorage.setItem('audioURL', url);
//}