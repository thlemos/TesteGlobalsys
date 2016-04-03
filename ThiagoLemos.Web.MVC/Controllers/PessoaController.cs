using System;
using System.Linq;
using System.Web.Mvc;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;
using ThiagoLemos.Domain.Interfaces.Services;
using ThiagoLemos.Domain.Services;
using ThiagoLemos.Infra;
using ThiagoLemos.Infra.Contextos;
using ThiagoLemos.Web.MVC.Models;

namespace ThiagoLemos.Web.MVC.Controllers
{
    public class PessoaController : Controller
    {
        private IPessoaService service;
        public PessoaController()
        {
            var db = new Contexto();
            var repo = new PessoaRepository(db);
            service = new PessoaService(repo);
        }
        //
        // GET: /Pessoa/

        public ActionResult Index()
        {
            var lista = service.ObterTodos();
            var lista2 = (from p in lista
                select new PessoaViewModel
                {
                    Id= p.Id,
                    Nome = p.Nome,
                    DataNascimento = p.DataNascimento,
                    Cpf = p.Cpf
                }).ToList();


            return View(lista2);
        }




        //
        // GET: /Pessoa/Create

        public ActionResult Create()
        {
            var model = new PessoaViewModel();
            return View(model);
        }

        //
        // POST: /Pessoa/Create

        [HttpPost]
        public ActionResult Create(PessoaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoa = new Pessoa(model.Nome, model.DataNascimento.Value, model.Cpf);

                    service.AdicionarNovaPessoa(pessoa);
                    TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Criar);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro :" + ex.Message;
                return View();
            }
        }

        //
        // GET: /Pessoa/Create

        public ActionResult Edit(int id)
        {
            var obj = service.ObterPorId(id);

            var model = new PessoaViewModel
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Cpf=obj.Cpf,
                DataNascimento = obj.DataNascimento,
                DataCadastro = obj.DataCadastro
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(PessoaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoa = service.ObterPorId(model.Id);
                    pessoa.Nome = model.Nome;
                    pessoa.DataNascimento = model.DataNascimento.Value;
                    pessoa.Cpf = Replace(model.Cpf);

                    service.AtualizarPessoa(pessoa);
                    TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Alterar);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro :" + ex.Message;
                return View();
            }
        }


        //
        // GET: /Pessoa/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                var obj = service.ObterPorId(id);
                service.ExcluirPessoa(obj);
                TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Excluir);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        private string Replace(string p)
        {
            return p.Replace(".", "").Replace("/", "").Replace("-", "");
        }
    }
}
