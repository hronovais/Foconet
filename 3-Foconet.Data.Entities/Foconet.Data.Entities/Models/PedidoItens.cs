using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Entities.Models
{
    public class PedidoItens
    {
        public int Id { get; set; }

        [DisplayName("Pedido")]
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        [Required(ErrorMessage = "Informe a quantidade.")]
        public int Quantidade { get; set; }

        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [DisplayName("Material")]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
