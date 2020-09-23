using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiInventario.Features.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Marca { get; set; }
        public DateTime Fecha { get; set; }
        public List<EquipmentDetail> DetailsList { get; set; }
    }
}
