﻿using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public async Task<IEnumerable<Categoria>> Obter()
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Categorias
                    .ToList();
            }
        }

        public async Task<Categoria> ObterPorId(int id)
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Categorias
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public async Task<Categoria> Inserir(Categoria entidade)
        {
            using (var context = new FinancasContext())
            {
                context.Add(entidade);
                await context.SaveChangesAsync();

                return entidade;
            }
        }

        public async Task<Categoria> Alterar(Categoria entidade)
        {
            using (var context = new FinancasContext())
            {
                context.Update(entidade);
                await context.SaveChangesAsync();

                return entidade;
            }
        }

        public async Task Excluir(int id)
        {
            using (var context = new FinancasContext())
            {
                context.Remove(new Categoria() { Id = id });
                await context.SaveChangesAsync();
            }
        }
    }
}
