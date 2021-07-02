using Dominio.Entidades;
using Dominio.IRepositories;
using Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencias
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly Context _context;

        public ImovelRepository(Context context)
        {
            _context = context;
        }

        public async Task Criar(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(Imovel imovel)
        {
            _context.Update(imovel);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Imovel imovel)
        {
            _context.Remove(imovel);
            await _context.SaveChangesAsync();
        }

        public async Task<Imovel> BuscarPorId(int id)
        {
            var imovel = await _context.Imoveis.FirstOrDefaultAsync(x => x.id == id);
            return imovel;
        }

        public async Task<IEnumerable<Imovel>> ListarTodosImoveis()
        {
            return await _context.Imoveis.AsNoTracking().ToListAsync();
        }
    }
}