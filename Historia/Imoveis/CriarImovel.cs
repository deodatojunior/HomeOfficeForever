using Dominio.Entidades;
using Dominio.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historia.Imoveis
{
    public class CriarImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public CriarImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public async Task Executar(Imovel imovel)
        {
            await _imovelRepository.Criar(imovel);
        }
    }
}
