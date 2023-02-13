function BeneficiarioExists(cpf) {

    let resultado = false;

    let beneficiarios = sessionStorage.getItem("cliente_beneficiarios") == "" ? [] : JSON.parse(sessionStorage.getItem("cliente_beneficiarios"));

    if (beneficiarios.length > 0) {
        beneficiarios.some(function (e) {
            if (e.CPF_B == cpf) {
                resultado = true;
                return true;
            }
        })
    }

    return resultado;
}