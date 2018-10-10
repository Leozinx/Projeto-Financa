function OnsuccessLogar(response) {
    if (response.Resposta === "OK") {
        alert("Bem vindo!!!");
        location.href = ('/Home/Index');
    }
    else if (response.Resposta === "ERRO") {

        if (typeof ($("div.log-alerta")) !== "undefined") {
            $(".alerta").append('<div class="alert alert-danger alert-dismissable fade in text-center log-alerta"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>' +
                'Nome de usuário e senha inválidos.</div>');
        }
        //alert("Credêncial inválida, favor verificar");
        $("#Username").val('');
        $("#Password").val('');
    } else if (response.Resposta === "ERRO BD") {
        alert("Erro ao tentar validar as informações fornecidas. \nNão foi possível se comunicar com a Base de dados");
    }

}
function OnBeginLogar() {
    $('.login-form').addClass('desfocado');
}
function OnCompleteLogar() {
    $('.login-form').removeClass('desfocado');
    setTimeout(function () {
        $(".alerta").fadeOut().empty();
    }, 5000);
}
function OnFaiulureLogar() {

}