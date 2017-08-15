using Foconet.Data.Entities.Models;
using Foconet.Data.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Services.Services
{
    public class PedidoService
    {
        private PedidoRepository pedidoRepository;

        public PedidoService()
        {
            pedidoRepository = new PedidoRepository();
        }

        public List<Pedido> GetAll()
        {
            var pedidos = pedidoRepository.Get(x => x.Id > 0, c => c.Cliente)
                .ToList();
            return pedidos;
        }

  
        public void Add(Pedido pedido)
        {
            pedidoRepository.Add(pedido);
        }

        public Pedido Find(int id)
        {
            return pedidoRepository.Find(id);
        }

        public void Update(Pedido pedido)
        {
            pedidoRepository.Update(pedido);
        }
    }
}
