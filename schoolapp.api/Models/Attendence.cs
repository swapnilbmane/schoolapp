using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class Attendence
    {
        [Key]
        public int AttendenceId { get; set; }
        public string Title { get; set; }
        public SubTeachStdRel SubTeachStdRelation { get; set; }
        public Student Student { get; set; }
        public bool IsPresent { get; set; }
        public Person CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
