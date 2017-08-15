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
    [Table("Pedido")]
    public class Pedido
    {
        public int Id { get; set; }        

        [DisplayName("Solicitante")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public DateTime Data { get; set; }

        public bool Finalizado { get; set; }

        public virtual ICollection<PedidoItens> PedidoItens { get; set; }
    }
}
