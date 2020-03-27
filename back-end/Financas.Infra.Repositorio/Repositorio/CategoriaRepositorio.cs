﻿using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Categorias
                    .ToList();
            }
        }

        public async Task<Categoria> CriarCategoria(Categoria categoria)
        {
            using (var context = new FinancasContext())
            {
                context.Add(categoria);
                context.SaveChanges();

                return categoria;
            }
        }
    }
}
