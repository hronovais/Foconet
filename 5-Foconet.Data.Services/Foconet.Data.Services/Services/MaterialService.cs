using Foconet.Data.Entities.Models;
using Foconet.Data.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Services.Services
{
    public class MaterialService
    {
        private MaterialRepository materialRepository;

        public MaterialService()
        {
            materialRepository = new MaterialRepository();
        }

        public List<Material> GetAll()
        {
            return materialRepository.GetAll().ToList();
        }

        public async Task<IList<Material>> GetAllAsync()
        {
            return await materialRepository.GetAllAsync();
        }

        public void Add(Material material)
        {
            materialRepository.Add(material);
        }

        public Material Find(int id)
        {
            return materialRepository.Find(id);
        }

        public void Update(Material material)
        {
            materialRepository.Update(material);
        }
    }
}
