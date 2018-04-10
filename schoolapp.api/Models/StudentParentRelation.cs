using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class StudentParentRelation
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public Person Parent { get; set; }
    }
}
