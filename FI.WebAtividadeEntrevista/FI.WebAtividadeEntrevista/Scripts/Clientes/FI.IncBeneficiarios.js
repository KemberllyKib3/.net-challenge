(function ($) {
    incluirBeneficiario = $('#formBeneficiarios').submit(function (e) {
        e.preventDefault();

        const cpf = $('#CPF_B').val();
        const nome = $('#Nome_B').val();

        if (BeneficiarioExists(cpf)) {
            ModalDialog("Ocorreu um erro", "CPF já cadastrado");
        } else {

            let beneficiarios = sessionStorage.getItem("cliente_beneficiarios") == "" ? [] : JSON.parse(sessionStorage.getItem("cliente_beneficiarios"));

            let novoBeneficiario = { "CPF": cpf, "Nome": nome };
            beneficiarios.push(novoBeneficiario);

            sessionStorage.setItem("cliente_beneficiarios", JSON.stringify(beneficiarios));

            let contentRow = `<tr id="${e.CPF}">                                  
                                <td>${novoBeneficiario.CPF}</td>                               
                                <td>${novoBeneficiario.Nome}</td>                               
                                <td class="text-center mx-auto">                                 
                                   <button id="alterarBeneficiario" name="alterarBeneficiario" class="btn btn-primary" data-id="${e.CPF}" onclick="alterarBeneficiario("${novoBeneficiario.CPF}", "${novoBeneficiario.Nome}")">Alterar</button>
                                   <button id="excluirBeneficiario" name="excluirBeneficiario" class="btn btn-danger" data-id="${e.CPF}" onclick="excluirBeneficiario(this)">Excluir</button>
                                </td >                                                          
                             </tr >`;

            $('#gridBeneficiarios tbody').append(contentRow);

            $('#CPF_B').val('');
            $('#Nome_B').val('');
        }

    });

})(jQuery);