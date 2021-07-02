using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Factories
{
    public static class ImovelFactory
    {
        public static ImovelViewModel MapearImovelViewModel(Imovel imovel)
        {
            var imovelViewModel = new ImovelViewModel
            {
                id = imovel.id,
                cidade = imovel.cidade,
                bairro = imovel.bairro,
                quantidade = imovel.quantidade,
                valor = imovel.valor
            };

            return imovelViewModel;
        }

        public static Imovel MapearImovel(ImovelViewModel imovelViewModel)
        {
            var imovel = new Imovel(
                imovelViewModel.cidade,
                imovelViewModel.bairro,
                imovelViewModel.quantidade,
                imovelViewModel.valor
                );

            return imovel;
        }

        public static IEnumerable<ImovelViewModel> MapearListaImovelViewModel(IEnumerable<Imovel> imoveis)
        {
            var lista = new List<ImovelViewModel>();
            foreach (var item in imoveis)
            {
                lista.Add(MapearImovelViewModel(item));
            }
            return lista;
        }
    }
}