using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class StudentExam
    {
        [Key]
        public int StudentExamId { get; set; }
        public SubjectExam SubjectExam { get; set; }
        public Student Student { get; set; }
        public bool IsPresent { get; set; }
        public DateTime AttendedOn { get; set; }
        public int MarksObtained { get; set; }
        public Person CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
