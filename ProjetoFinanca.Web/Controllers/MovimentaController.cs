using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using ProjetoFinanca.Infra;
using ProjetoFinanca.Modelo;
using ProjetoFinanca.Web.Models;

namespace ProjetoFinanca.Web.Controllers
{
    public class MovimentaController : Controller
    {
        private FinancaContexto db = new FinancaContexto();

        // GET: Movimenta
        public ActionResult Index()
        {
            var movimentos = db.Movimentos.Include(m => m.Categoria);
            return View(movimentos.ToList().OrderByDescending(x => x.Data));
        }

        // GET: Movimenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimentacao movimentacao = db.Movimentos.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacao);
        }

        // GET: Movimenta/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.PeriodoId = new SelectList(db.Periodos.Where(x => x.Situacao.Equals(false)), "Id", "Nome");
            return View();
        }

        // POST: Movimenta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.Movimentos.Add(movimentacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", movimentacao.CategoriaId);
            ViewBag.PeriodoId = new SelectList(db.Periodos.Where(x => x.Situacao.Equals(false)), "Id", "Nome");
            return View(movimentacao);
        }

        [HttpPost]
        public string Criar(List<Movimentacao> movimento)
        {
            int count = 0;
            foreach (var variable in movimento)
            {
                var result = (db.Movimentos.Where(us =>
                    us.Data.Equals(variable.Data) && us.Descricao.Equals(variable.Descricao) &&
                    us.Valor.Equals(variable.Valor))).FirstOrDefault<Movimentacao>();
                if (result == null)
                {
                    db.Movimentos.Add(variable);
                    db.SaveChanges();
                    count++;
                }
                else
                {
                    count++;
                }
            }
            if (count > 0)
            {
                return "Alguns lançamentos já existem";
            }
            else
            {
                return "OK";
            }
        }
        // GET: Movimenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimentacao movimentacao = db.Movimentos.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", movimentacao.CategoriaId);
            ViewBag.PeriodoId = new SelectList(db.Periodos.Where(x => x.Situacao.Equals(false)), "Id", "Nome");
            return View(movimentacao);
        }

        // POST: Movimenta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", movimentacao.CategoriaId);
            ViewBag.PeriodoId = new SelectList(db.Periodos.Where(x => x.Situacao.Equals(false)), "Id", "Nome");
            return View(movimentacao);
        }

        // GET: Movimenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimentacao movimentacao = db.Movimentos.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacao);
        }

        // POST: Movimenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movimentacao movimentacao = db.Movimentos.Find(id);
            db.Movimentos.Remove(movimentacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RelacaoCategoria()
        {
            //Selecionar todos nomes categorias
            var categorias = db.Categorias.Select(x => x.Nome).ToList();

            //Seleciona todos os nomes dos períodos
            var periodos = db.Periodos.OrderBy(x => x.Id).Select(x => x.Nome).ToList();

            //Relação de todos os movimentos
            var list = db.Movimentos.ToList();
            

            // ==========================================================================

            //receber os movimentos selecionados de acordo com o periodo
            var movimentoPeriodoSelect = new List<Movimentacao>();
            //var movimentoCategoria = new decimal();

            //View movimentoPeriodo
            //Lista movimentos dos períodos
            var MovPer = new List<MovimentoPeriodo>();



            foreach (var Periodo in periodos)
            {
                var _movimentoPeriodo = new MovimentoPeriodo();

                _movimentoPeriodo.periodo = Periodo;
                //Seleciona todos os movimentos do determinado periodo
                movimentoPeriodoSelect = list.Where(x => x.Periodo.Nome == Periodo).OrderBy(x => x.Id).ToList();
                foreach (var categoria in categorias)
                {
                    //subclasse movimento categoria
                    var _movimentoCategoria = new MovimentoCategoria();

                    _movimentoCategoria.categoria = categoria;
                    //Somar o valor de acordo com as categorias do movimento selecionado
                    _movimentoCategoria.Valor = movimentoPeriodoSelect.Where(x => x.Categoria.Nome == categoria).Sum(x => x.Valor);
                    _movimentoPeriodo._movimentoCategoria.Add(_movimentoCategoria);

                }
                MovPer.Add(_movimentoPeriodo);
                //lisat.Add(new KeyValuePair<string, decimal>(Periodo, new KeyValuePair<string, decimal>(c)));
                //lisat.Add(new KeyValuePair<string, decimal>(Periodo, list.Where(x => x.Categoria.Nome == Periodo).Sum(x => x.Valor)));
            }



            return Json(MovPer, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult RelacaoMovPer(int i)
        {
            var periodo = db.Periodos.FirstOrDefault(x => x.Id.Equals(i));
            var list = db.Movimentos.ToList();
            var query = list.OrderByDescending(n => n.Data).Where(x => periodo != null && (x.Data >= periodo.DataInicio && x.Data <= periodo.DataFim))
                .Select(x => new
                {
                    Lancamento = x.Data.ToString("dd/MM"),
                    x.Valor,
                    x.Categoria.Nome
                }).ToList();

            //Montar Grafico Pie-Area

            var soma = new List<decimal>();
            var teste = list.Select(x => x.Categoria.Nome).Distinct();

            foreach (var item in teste)
            {
                soma.Add(query.Where(x => x.Nome == item).Sum(x => x.Valor));
            }

            var grupo = new List<object>();

            grupo.Add(query);
            grupo.Add(soma);
            grupo.Add(teste);

            return Json(grupo, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
