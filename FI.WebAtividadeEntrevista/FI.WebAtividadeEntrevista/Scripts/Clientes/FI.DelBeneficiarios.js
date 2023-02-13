(function ($) {
    excluirBeneficiario = function (value) {

        let cpf = value.dataset.id;

        let obj = JSON.parse(sessionStorage.beneficiarios);
        let excluir = obj.findIndex(x => x.CPF_B == cpf);
        obj.splice(excluir, 1);

        sessionStorage.clear();
        sessionStorage.setItem("cliente_beneficiarios", []);
        sessionStorage.setItem("cliente_beneficiarios", JSON.stringify(obj));

        var tr = $(value).closest('tr');
        tr.remove();
        return false;
    };
})(jQuery);