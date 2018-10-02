using ProjetoFinanca.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjetoFinanca.Infra;

namespace ProjetoFinanca.Web.Controllers
{
    public class AccountController : Controller
    {
        private FinancaContexto db = new FinancaContexto();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(LoginViewModel usuario, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Retornar usuário caso exista de acordo com o username informado

                    //var vLogin = _usuariorepositorio.GetUsuario(usuario.Username);

                    var vLogin = db.Usuarios.FirstOrDefault(x => x.Username == usuario.Username);

                    //Verificar se foi encontrado algum usuário
                    if (vLogin != null)
                    {
                        /* Código abaixo verifica se o usuário que retornou está ativo */
                        if (Equals(vLogin.Status, true))
                        {/*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
                              do banco. Caso não cai direto no else*/
                            if (Equals(vLogin.Senha, usuario.Password))
                            {
                                FormsAuthentication.SetAuthCookie(vLogin.Username, true);
                                if (Url.IsLocalUrl(returnUrl)
                                    && returnUrl.Length > 1
                                    && returnUrl.StartsWith("/")
                                    && !returnUrl.StartsWith("//")
                                    && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }
                                /*código abaixo cria uma session para armazenar o nome do usuário*/
                                Session["Nome"] = vLogin.Nome;
                                Session["Perfil"] = vLogin.Nivel.Nome;
                                Session["Username"] = vLogin.Username;
                                ViewBag.Perfil = vLogin.Nivel.Nome;
                                /*retorna para a tela inicial do Home*/
                                return Json(RespostaRequisicao.MensagemOK("OK"), JsonRequestBehavior.AllowGet);
                                //return RedirectToAction("Index", "Home");
                            }
                            /*Else responsável da validação da senha*/
                            else
                            {
                                /*Escreve na tela a mensagem de erro informada*/
                                return Json(RespostaRequisicao.MensagemErro("ERRO"), JsonRequestBehavior.AllowGet);
                                /*Retorna a tela de login*/
                            }
                        }
                        /*Else responsável por verificar se o usuário está ativo*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            return Json(RespostaRequisicao.MensagemErro("ERRO"), JsonRequestBehavior.AllowGet);
                            /*Retorna a tela de login*/
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        return Json(RespostaRequisicao.MensagemErro("ERRO BD"), JsonRequestBehavior.AllowGet);
                        /*Retorna a tela de login*/

                    }

                }
                /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login com as mensagem dos campos*/
                return View(usuario);
            }
            catch (Exception e)
            {
                return Json(RespostaRequisicao.MensagemErro("ERRO"), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Logar", "Account");
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
