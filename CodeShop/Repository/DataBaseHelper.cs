using CodeShop.Repository.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CodeShop.Repository
{
    internal static class DataBaseHelper
    {
        public static void ModelCreate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);

            modelBuilder.Entity<Carrinho>().HasKey(x => x.Id);

            modelBuilder.Entity<Item>().HasKey(x => x.Id);

            modelBuilder.Entity<Produto>().HasKey(x => x.Id);
        }

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario[] {
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
                    Cargo = "Admin"
                }
            });
        }
    }
}
