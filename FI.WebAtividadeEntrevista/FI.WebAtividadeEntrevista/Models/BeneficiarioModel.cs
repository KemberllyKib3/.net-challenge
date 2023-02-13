using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAtividadeEntrevista.Validations;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Beneficiário
    /// </summary>
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required]
        [MaxLength(14)]
        [RegularExpression(@"[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}", ErrorMessage = "Mal formatado - 111.222.333-45")]
        [CPFValid]
        public string CPF { get; set; }
    }
}