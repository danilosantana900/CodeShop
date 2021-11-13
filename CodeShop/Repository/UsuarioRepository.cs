using CodeShop.Repository.DataModel;
using System.Collections.Generic;

namespace CodeShop.Repository
{
    public static class UsuarioRepository
    {
        public static List<Usuario> Usuarios = new List<Usuario>()
        {
            new Usuario()
            {
                Id = 1,
                Nome = "Danilo",
                Senha = "senha1",
                Cargo = ""
            },

            new Usuario()
            {
                Id = 2,
                Nome = "Debora",
                Senha = "senha2",
                Cargo = "Funcionario"
            },
            
            new Usuario()
            {
                Id = 3,
                Nome = "Joao",
                Senha = "senha3",
                Cargo = "Cliente"
            },

            new Usuario()
            {
                Id = 4,
                Nome = "Melissa",
                Senha = "senha4",
                Cargo = "Funcionario"
            }
        };
    }
}
