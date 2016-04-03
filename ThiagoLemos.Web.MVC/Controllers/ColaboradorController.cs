using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Domain.Interfaces.Services;
using ThiagoLemos.Domain.Services;
using ThiagoLemos.Infra;
using ThiagoLemos.Infra.Contextos;
using ThiagoLemos.Infra.Repositories;
using ThiagoLemos.Web.MVC.Models;

namespace ThiagoLemos.Web.MVC.Controllers
{
    public class ColaboradorController : Controller
    {
        
        private PessoaRepository repoPe;
        private EmpresaRepository repoEm;
        private  IEnumerable<Pessoa> listapessoa;
        private  IEnumerable<Empresa> listaempresa;
        private IColaboradorService service;
        public ColaboradorController()
        {
            var db = new Contexto();
            var repo = new ColaboradorRepository(db);
            service = new ColaboradorService(repo);

            repoPe = new PessoaRepository(db);
            repoEm = new EmpresaRepository(db);

            listaempresa = repoEm.GetAll();
            listapessoa = repoPe.GetAll();

        }
        //
        // GET: /Colaborador/

        public ActionResult Index()
        {
            var lista = service.ObterTodos();
            var lista2 = (from p in lista
                select new ColaboradorViewModel()
                {
                    Id= p.Id,
                    Salario = p.Salario,
                    Cargo = p.Cargo,
                    Status = p.Status,
                    DataDemissao = p.DataDemissao,
                    Pessoa = p.Pessoa,
                    Empresa = p.Empresa,
                    
                }).ToList();




            return View(lista2);
        }




        //
        // GET: /Colaborador/Create

        public ActionResult Create()
        {
            var model = new ColaboradorViewModel();

            
            ViewBag.EmpresaId = new SelectList(listaempresa, "Id", "Nome");

            
            ViewBag.PessoaId = new SelectList(listapessoa, "Id", "Nome");

            return View(model);
        }

        //
        // POST: /Colaborador/Create

        [HttpPost]
        public ActionResult Create(ColaboradorViewModel model, string EmpresaId, string PessoaId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var colaborador = new Colaborador(Convert.ToInt32(PessoaId), Convert.ToInt32(EmpresaId), model.Cargo, model.Salario);

                    service.AdicionarNovoColaborador(colaborador);
                    TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Criar);
                    return RedirectToAction("Index");
                }
                RecarregarCampos(model, EmpresaId, PessoaId);
                return View();
            }
            catch (Exception ex)
            {
                RecarregarCampos(model, EmpresaId, PessoaId);
                TempData["Error"] = "Erro :" + ex.Message;
                return View();
            }
        }

        //
        // GET: /Colaborador/Create

        public ActionResult Edit(int id)
        {
            var obj = service.ObterPorId(id);

            var model = new ColaboradorViewModel
            {
                Id = obj.Id,
                Cargo = obj.Cargo,
                Salario= obj.Salario,
                Status = obj.Status,
                PessoaId = obj.PessoaId,
                EmpresaId= obj.EmpresaId,
                DataDemissao = obj.DataDemissao,
                DataCadastro = obj.DataCadastro
            };


            listaempresa = repoEm.GetAll().ToList();
            ViewBag.EmpresaId = new SelectList(listaempresa, "Id", "Nome", obj.EmpresaId.ToString());

            listapessoa = repoPe.GetAll().ToList();
            ViewBag.PessoaId = new SelectList(listapessoa, "Id", "Nome", obj.PessoaId.ToString());

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(ColaboradorViewModel model, string EmpresaId, string PessoaId)
        {
            try
            {
                Colaborador colaborador;
                if (ModelState.IsValid)
                {
                    colaborador = service.ObterPorId(model.Id);
                    colaborador.Cargo = model.Cargo;
                    colaborador.Salario = model.Salario;
                    colaborador.Status = model.Status;
                    colaborador.PessoaId = Convert.ToInt32(PessoaId);
                    colaborador.EmpresaId = Convert.ToInt32(EmpresaId);
                    service.AtualizarColaborador(colaborador);
                    
                    TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Alterar);
                    return RedirectToAction("Index");
                }
                RecarregarCampos(model,EmpresaId,PessoaId);
                return View();
            }
            catch (Exception ex)
            {
                RecarregarCampos(model, EmpresaId, PessoaId);
                TempData["Error"] = "Erro :" + ex.Message;
                return View();
            }
        }

        private void RecarregarCampos(ColaboradorViewModel model, string EmpresaId, string PessoaId)
        {
            if (PessoaId != "")
                model.PessoaId = Convert.ToInt32(PessoaId);
            if (EmpresaId != "")
                model.EmpresaId = Convert.ToInt32(EmpresaId);

            // Caso dê erro de validação, carregar os dropdowns de novo
            ViewBag.EmpresaId = new SelectList(listaempresa, "Id", "Nome", Convert.ToInt32(model.EmpresaId));

            ViewBag.PessoaId = new SelectList(listapessoa, "Id", "Nome", Convert.ToInt32(model.PessoaId));

        }


        //
        // GET: /Colaborador/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                var obj = service.ObterPorId(id);
                service.ExcluirColaborador(obj);
                
                TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Excluir);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Demitir(int id)
        {
            try
            {
                var obj = service.ObterPorId(id);
                service.Demitir(obj);

                TempData["Success"] = EnumHelper.Descricao(MensagemSucesso.Demitir);
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
