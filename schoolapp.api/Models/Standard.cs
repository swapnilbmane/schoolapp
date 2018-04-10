using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class Standard
    {
        [Key]
        public int StandardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
