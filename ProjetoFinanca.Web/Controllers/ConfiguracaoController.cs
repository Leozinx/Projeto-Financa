using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinanca.Infra;
using ProjetoFinanca.Web.Models;

namespace ProjetoFinanca.Web.Controllers
{
    public class ConfiguracaoController : Controller
    {
        // GET: Configuracao
        private FinancaContexto db = new FinancaContexto();
        public ActionResult Configuracao()
        {
            ViewBag.PeriodoId = new SelectList(db.Periodos.Where(x => x.Situacao.Equals(false)), "Id", "Nome");
            return View(new List<MovimentaModel>());
        }

        [HttpPost]
        public ActionResult Configuracao(HttpPostedFileBase postedFile)
        {
            ModelState.Clear();
            var customers = new List<MovimentaModel>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        var datas = row.Split(';')[0];
                        customers.Add(new MovimentaModel
                        {
                            Data_Mov = row.Split(';')[0],
                            Valor_Mov = row.Split(';')[1],
                            Descri_Mov = row.Split(';')[2],
                            Categoria_Mov = row.Split(';')[3]
                        });
                    }
                }
            }
            ViewBag.Nome = postedFile.FileName;
           
            return View(customers);
        }
    }
}