using Dominio.Entidades;
using Dominio.IRepositories;
using System.Threading.Tasks;

namespace Historia.Imoveis
{
    public class AlterarImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public AlterarImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public async Task Executar(int id, Imovel imovel)
        {
            var dadosDoImovel = await _imovelRepository.BuscarPorId(id);

            dadosDoImovel.AtualizarImovel(imovel.cidade, imovel.bairro, imovel.quantidade, imovel.valor);

            await _imovelRepository.Alterar(dadosDoImovel);
        }
    }
}
