
function GetUrl(url) {
    $("#title").html(url)
    console.log($("#title"))
    url = url;
    $.ajax({
        url: url,
        type: 'GET',
        success: function (response) {
            
            $("#mostraNaTela").html(response)
        },
        error: function () {
            alert('Ocorreu um erro!');
        }
    });
}

function PreencherPlayer(callback, id) {
    $.ajax({
        url: "PlayerMusica/PreencherPlayer?id="+ id,
        type: 'GET',
        success: function (dados) {
           callback(dados)      
        },
        error: function () {
            alert('Ocorreu um erro!');
        }
    });
}