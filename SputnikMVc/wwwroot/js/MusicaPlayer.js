var MusicaPlayer = document.getElementById('MusicaPlayer');
var Timer = document.getElementById('time')
var timeModificado = "";
let volumeSlider = document.querySelector("#volume-slider");

//Verificar se houve alguma atualizacao da musica
MusicaPlayer.addEventListener("timeupdate", function () {
    if (!MusicaPlayer.paused) {
        var currentTime = MusicaPlayer.currentTime;
        var duration = MusicaPlayer.duration;
        console.log(document.getElementById('MusicaPlayer').currentTime)
        localStorage.setItem('CurrentTime', MusicaPlayer.currentTime);
        var percent = (currentTime / duration) * 100;

        var tempoPercorrido = formattedTime(currentTime)
        var tempoDuracao = formattedTime(duration);

        timeModificado = `${tempoPercorrido} /${tempoDuracao}`
        Timer.innerText = timeModificado
        document.getElementById('progress-bar').style.width = percent + "%";
    }
   
});

volumeSlider.addEventListener("input", function () {
    MusicaPlayer.volume = volumeSlider.value / 100;
});

//Conversores
function formattedTime(currentTime) {
    debugger
    if (Number.isNaN(currentTime))
        return "0:00";
    
    var minutes = Math.floor(currentTime / 60);
    var seconds = Math.floor(currentTime % 60);
    var formattedTime = minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
    return formattedTime
}
function FormatterName(name) {
    debugger
    if (name.length > 30) {
        return name.slice(0, 30);
    } else {
        return name
    }
}
//Funcoes do player 
function playMusica(id, CurrentTime) {
    // declare variáveis
    GetPreenchePlayer(id);
    
    const baseUrl = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ":" + window.location.port : "");
    const xhr = new XMLHttpRequest();
    const MusicaPlayer = document.getElementById('MusicaPlayer');

    // cria solicitação GET para o arquivo de música
    xhr.open('GET', `${baseUrl}/Musica/GetArquivoMp3?id=${id}`, true);
    xhr.responseType = 'arraybuffer';

    // manipulador de resposta da solicitação XMLHttpRequest
    xhr.onload = function () {
        if (xhr.status === 200) {
            // cria um objeto Blob a partir da resposta
            const blob = new Blob([xhr.response], { type: 'audio/mpeg' });
            const url = URL.createObjectURL(blob);

            // verifica se o objeto MusicaPlayer está definido antes de usá-lo
            if (MusicaPlayer) {
                MusicaPlayer.setAttribute('src', url);

                // define a posição atual da música se CurrentTime estiver definido
                if (CurrentTime != null) {
                    MusicaPlayer.currentTime = CurrentTime;
                }

                // inicia a música e armazena o URL no localStorage
                MusicaPlayer.play();
                localStorage.setItem('UrlMusica', url);
                
            }
        } else {
            // manipulador de erro da solicitação XMLHttpRequest
            console.error(`Erro ${xhr.status} ao carregar o arquivo de música`);
        }
    };

    // manipulador de erro da solicitação XMLHttpRequest
    xhr.onerror = function () {
        console.error('Erro ao carregar o arquivo de música');
    };

    xhr.send();
}
function GetPreenchePlayer(id) {
    debugger
    var url = `PlayerMusica/PreencherPlayer?id=${id}`
    objtMusicaPlayer = PreencherPlayer(function (data) {
        console.log(data);
        console.log(document.getElementById('nomeMusica').innerText = FormatterName(data.name))
    }, id)
}
function MuteAudio() {
    if (MusicaPlayer.volume == 0) {
        MusicaPlayer.volume = volumeSlider.value / 100;
    } else {
        MusicaPlayer.volume = 0;
    }
    

}

