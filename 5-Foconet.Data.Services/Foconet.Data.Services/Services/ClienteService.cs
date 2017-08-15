using Foconet.Data.Entities.Models;
using Foconet.Data.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Services.Services
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;

        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }

        public List<Cliente> GetAll()
        {
            return clienteRepository.GetAll().ToList();
        }

        public void Add(Cliente cliente)
        {
            clienteRepository.Add(cliente);
        }

        public Cliente Find(int id)
        {
            return clienteRepository.Find(id);
        }

        public void Update(Cliente cliente)
        {
            clienteRepository.Update(cliente);
        }
    }
}
