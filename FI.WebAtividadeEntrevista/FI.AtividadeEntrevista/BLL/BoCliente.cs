using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoCliente
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public void Incluir(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            long idCliente = cli.Incluir(cliente);

            if (cliente.Beneficiarios != null)
            {
                DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
                ben.Incluir(cliente.Beneficiarios, idCliente);
            }
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public void Alterar(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Alterar(cliente);

            if (cliente.Beneficiarios != null)
            {
                DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
                ben.Excluir(cliente.Id);
                ben.Incluir(cliente.Beneficiarios, cliente.Id);
            }
        }

        /// <summary>
        /// Consulta o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public DML.Cliente Consultar(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            var cliente = cli.Consultar(id);

            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            cliente.Beneficiarios = ben.Consultar(cliente.Id);

            return cliente;
        }

        /// <summary>
        /// Excluir o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Excluir(id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Listar()
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Listar();
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            CPF.Replace(".", "").Replace("-", "");
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.VerificarExistencia(CPF);
        }
    }
}
