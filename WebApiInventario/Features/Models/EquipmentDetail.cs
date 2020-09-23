using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiInventario.Features.Models
{
    public class EquipmentDetail
    {
        [Key]
        public int Id { get; set; }
        public int idEquipo { get; set; }
        public string nombreEquipo { get; set; }
        public string Tipo { get; set; }
        public Equipment Equipments { get; set; }
    }
}
