using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;

namespace WebAtividadeEntrevista.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(ClienteModel model)
        {
            BoCliente bo = new BoCliente();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                if (!bo.VerificarExistencia(model.CPF))
                {
                    var beneficiarios = new List<Beneficiario>();

                    if (model.Beneficiarios != null)
                    {
                        foreach (var ben_model in model.Beneficiarios)
                        {
                            beneficiarios.Add(new Beneficiario { CPF = ben_model.CPF, Nome = ben_model.Nome });
                        }
                    }

                    bo.Incluir(new Cliente()
                    {
                        Nome = model.Nome,
                        Sobrenome = model.Sobrenome,
                        Nacionalidade = model.Nacionalidade,
                        CPF = model.CPF,
                        CEP = model.CEP,
                        Estado = model.Estado,
                        Cidade = model.Cidade,
                        Logradouro = model.Logradouro,
                        Email = model.Email,
                        Telefone = model.Telefone,
                        Beneficiarios = beneficiarios
                    });

                    return Json("Cadastro efetuado com sucesso");
                }
                else
                {
                    Response.StatusCode = 400;
                    return Json("Já existe um cliente com este CPF.");
                }

            }
        }

        [HttpPost]
        public JsonResult Alterar(ClienteModel model)
        {
            BoCliente bo = new BoCliente();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var beneficiarios = new List<Beneficiario>();

                if (model.Beneficiarios != null)
                {
                    foreach (var ben_model in model.Beneficiarios)
                    {
                        beneficiarios.Add(new Beneficiario { CPF = ben_model.CPF, Nome = ben_model.Nome });
                    }
                }

                bo.Alterar(new Cliente()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    Nacionalidade = model.Nacionalidade,
                    CPF = model.CPF,
                    CEP = model.CEP,
                    Estado = model.Estado,
                    Cidade = model.Cidade,
                    Logradouro = model.Logradouro,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    Beneficiarios = beneficiarios
                });

                return Json("Cadastro alterado com sucesso");
            }
        }

        [HttpPost]
        public ActionResult Excluir(long id)
        {
            try
            {
                BoCliente bo = new BoCliente();

                bo.Excluir(id);
                return Json(new { Result = "OK", Message = "Cliente excluído" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoCliente bo = new BoCliente();
            Cliente cliente = bo.Consultar(id);
            Models.ClienteModel model = null;

            if (cliente != null)
            {
                model = new ClienteModel()
                {
                    Id = cliente.Id,
                    CEP = cliente.CEP,
                    Cidade = cliente.Cidade,
                    Email = cliente.Email,
                    Estado = cliente.Estado,
                    Logradouro = cliente.Logradouro,
                    Nacionalidade = cliente.Nacionalidade,
                    CPF = cliente.CPF,
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    Telefone = cliente.Telefone,
                    Beneficiarios = new List<BeneficiarioModel>()
                };

                if (cliente.Beneficiarios != null)
                {
                    foreach (var ben_model in cliente.Beneficiarios)
                    {
                        model.Beneficiarios.Add(new BeneficiarioModel { Id = ben_model.Id, CPF = ben_model.CPF, Nome = ben_model.Nome });
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult ClienteList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Cliente> clientes = new BoCliente().Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out int qtd);

                //Return result to jTable
                return Json(new { Result = "OK", Records = clientes, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }
    }
}