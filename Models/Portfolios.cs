using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Portfolio_system.Models
{
    [Table("Portfolios")]
    public class Portfolios
    {
        [Key]
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Describe { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}
