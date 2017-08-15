using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Entities.Models
{
    [Table("Material")]
    public class Material
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do material.")]
        [DisplayName("Material")]
        public string Nome { get; set; }

        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
