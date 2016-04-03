using System;
using System.Linq;
using System.Web.Mvc;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;
using ThiagoLemos.Domain.Interfaces.Services;
using ThiagoLemos.Domain.Services;
using ThiagoLemos.Infra.Contextos;
using ThiagoLemos.Infra.Repositories;
using ThiagoLemos.Web.MVC.Models;

namespace ThiagoLemos.Web.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        //private IEmpresaRepository repo;
        private IEmpresaService servico;
        public EmpresaController()
        {
            var db = new Contexto();
            var repo = new EmpresaRepository(db);
            servico = new EmpresaService(repo);
            
        }
        //
        // GET: /Empresa/

        public ActionResult Index()
        {
            var lista = servico.ObterTodos();
            var lista2 = (from p in lista
                select new EmpresaViewModel
                {
                    Id= p.Id,
                    Nome = p.Nome,
                    RazaoSocial = p.RazaoSocial,
                    Cnpj = p.Cnpj
                }).ToList();


            return View(lista2);
        }




        //
        // GET: /Empresa/Create

        public ActionResult Create()
        {
            var model = new EmpresaViewModel();
            return View(model);
        }

        //
        // POST: /Empresa/Create

        [HttpPost]
        public ActionResult Create(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empresa = new Empresa(model.Nome,model.RazaoSocial,model.Cnpj);

                    servico.AdicionarNovaEmpresa(empresa);
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


        public ActionResult Edit(int id)
        {
            var obj = servico.ObterPorId(id);

            var model = new EmpresaViewModel
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Cnpj = obj.Cnpj,
                RazaoSocial = obj.RazaoSocial,
                DataCadastro = obj.DataCadastro
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empresa = servico.ObterPorId(model.Id);
                    empresa.Nome = model.Nome;
                    empresa.RazaoSocial = model.RazaoSocial;
                    empresa.Cnpj = Replace(model.Cnpj);

                    servico.AtualizarEmpresa(empresa);
                    TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Alterar); ;
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

        private string Replace(string p)
        {
            return p.Replace(".", "").Replace("/", "").Replace("-", "");
        }


        //
        // GET: /Empresa/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                var obj = servico.ObterPorId(id);
                servico.ExcluirEmpresa(obj);
                TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Excluir); ;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
