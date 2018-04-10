using System.ComponentModel.DataAnnotations;

namespace schoolapp.api.models
{
    //SubjectTeacherStandardRelation
    public class SubTeachStdRel
    {
        [Key]
        public int Id { get; set; }
        public Standard Standard { get; set; }
        public Subject Subject { get; set; }
        public Person Teacher { get; set; }
    }
}
