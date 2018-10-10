using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinanca.Infra;

namespace ProjetoFinanca.Web.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class HomeController : Controller
    {
        private FinancaContexto db = new FinancaContexto();
        public ActionResult Index()
        {
            ViewBag.Movimentos = db.Movimentos.OrderByDescending(x => x.Data).Take(5);

            return View();
        }

        public ActionResult Menu()
        {
            var menu = db.Menus.ToList();
            return PartialView(menu.ToList());
        }

        [HttpGet]
        public ActionResult Filtro()
        {
            //movimentos quando a situação está desmarcado
            var list = db.Movimentos.ToList().Where(x => x.Periodo.Situacao.Equals(false));

            //ultimos 5 lançamentos
            var query = list.OrderByDescending(n => n.Data).Take(5)
                .Select(x => new
                {
                    Lancamento =x.Data.ToShortDateString(),
                    x.Valor,
                    x.Categoria.Nome
                }).ToList();

            var soma = new List<decimal>();

            //Selecionando por todas as categorias
            var teste = list.Select(x => x.Categoria.Nome).Distinct();

            //somando de acordo com as categorias
            foreach (var item in teste)
            {
                soma.Add(list.Where(x => x.Categoria.Nome == item).Sum(x => x.Valor));
            }

            var grupo = new List<object>();

            grupo.Add(query);
            grupo.Add(soma);
            grupo.Add(teste);

            return Json(grupo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}