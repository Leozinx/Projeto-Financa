using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinanca.Infra;

namespace WebApi.Services
{
    public class UsuarioSeguranca
    {
        public static bool Login(string login, string senha)
        {
            using (FinancaContexto entities = new FinancaContexto())
            {
                return entities.Usuarios.Any(user =>
                    user.Username.Equals(login, StringComparison.OrdinalIgnoreCase)
                    && user.Senha == senha);
            }
        }
    }
}