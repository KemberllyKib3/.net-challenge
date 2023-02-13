(function ($) {
    alterarBeneficiario = function (valueCPF, valueNome) {

        let cpf = valueCPF;
        let nome = valueNome;

        $('#CPF_B').val(cpf);
        $('#Nome_B').val(nome);

    };
})(jQuery);