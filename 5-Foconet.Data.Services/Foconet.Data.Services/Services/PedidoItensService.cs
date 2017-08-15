using Foconet.Data.Entities.Models;
using Foconet.Data.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Services.Services
{
    public class PedidoItensService
    {
        private PedidoItensRepository pedidoItensRepository;

        public PedidoItensService()
        {
            pedidoItensRepository = new PedidoItensRepository();
        }

        public void Add(PedidoItens pedidoItens)
        {
            pedidoItensRepository.Add(pedidoItens);
        }

        public List<PedidoItens> Get(int pedidoId)
        {
            return pedidoItensRepository.Get(s => s.PedidoId == pedidoId, m => m.Material)
                .ToList();
        }

        public bool ExistePedidoNaoFinalizadoParaMaterial(int materialId)
        {
            if(pedidoItensRepository.Get(x => x.Pedido.Finalizado == false && x.Material.Id == materialId).Count() > 0)
            {
                return true;
            }

            return false;
        }

        public PedidoItens Find(int id)
        {
            return pedidoItensRepository.Find(id);
        }

        public void Update(PedidoItens pedidoItens)
        {
            pedidoItensRepository.Update(pedidoItens);
        }

        public void Delete(PedidoItens pedidoItem)
        {
            pedidoItensRepository.Delete(x => x.Id == pedidoItem.Id);
        }
    }
}
