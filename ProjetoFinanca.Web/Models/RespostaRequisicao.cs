using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace ProjetoFinanca.Web.Models
{
    public class RespostaRequisicao
    {
        public const string RESPOSTA_OK = "OK";
        public const string RESPOSTA_VALIDACAO = "VALIDACAO";
        public const string RESPOSTA_ERRO = "ERRO";
        public const string RESPOTA_BRANCO = "Em branco";
        public const string RESPOTA_ALTERADO = "ALTERADO";

        public string Resposta { get; set; }

        public object Mensagem { get; set; }
        public int Codigo { get; set; }


        public static RespostaRequisicao ModelState(ModelStateDictionary modelState)
        {
            RespostaRequisicao resposta = new RespostaRequisicao();
            resposta.Resposta = RespostaRequisicao.RESPOSTA_VALIDACAO;
            resposta.Mensagem = new List<object>();

            foreach (KeyValuePair<string, ModelState> state in modelState)
            {
                ModelError error = state.Value.Errors.SingleOrDefault();

                if (error != null)
                {
                    (resposta.Mensagem as List<object>).Add(new
                    {
                        Campo = state.Key,
                        Mensagem = state.Value.Errors.SingleOrDefault().ErrorMessage
                    });
                }
            }

            return resposta;
        }

        public static RespostaRequisicao MensagemErro(string msgErro)
        {
            return new RespostaRequisicao()
            {
                Resposta = RESPOSTA_ERRO,
                Mensagem = msgErro
            };
        }

        public static RespostaRequisicao MensagemOK(string msg)
        {
            return new RespostaRequisicao()
            {
                Resposta = RESPOSTA_OK,
                Mensagem = msg
            };
        }

        public static RespostaRequisicao MensagemOK(string msg, int codigo)
        {
            return new RespostaRequisicao()
            {
                Resposta = RESPOSTA_OK,
                Mensagem = msg,
                Codigo = codigo
            };
        }

        public static RespostaRequisicao MensagemBranco(string msg)
        {
            return new RespostaRequisicao()
            {
                Resposta = RESPOTA_BRANCO,
                Mensagem = msg
            };
        }

        public static RespostaRequisicao MensagemAlterado(string msg)
        {
            return new RespostaRequisicao()
            {
                Resposta = RESPOTA_ALTERADO,
                Mensagem = msg
            };
        }
    }
}