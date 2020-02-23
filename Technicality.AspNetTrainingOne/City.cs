using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technicality.AspNetTrainingOne
{
    [Table("City")]
    public class City
    {
        public int CityId { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }
    }
}