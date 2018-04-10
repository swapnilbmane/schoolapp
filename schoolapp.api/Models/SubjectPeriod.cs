using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class SubjectPeriod
    {
        [Key]
        public int SubjectPeriodId { get; set; }
        public SubTeachStdRel SubTeachStdRelation { get; set; }
        public DateTime SchecduledFrom { get; set; }
        public DateTime SchecduledTo { get; set; }
        public Person CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
