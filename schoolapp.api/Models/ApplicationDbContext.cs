using System;
using Microsoft.EntityFrameworkCore;

namespace schoolapp.api.models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Person> Persons {get; set;}
        public DbSet<Attendence> Attendences {get; set;}
        public DbSet<CommunicationMessage> CommunicationMessages {get; set;}
        public DbSet<EventNotification> EventNotifications {get; set;}
        public DbSet<Exam> Exams {get; set;}
        
        public DbSet<Plan> Plans {get; set;}
        public DbSet<SchoolEvent> SchoolEvents {get; set;}
        public DbSet<Standard> Standards {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<StudentExam> StudentExams {get; set;}
        public DbSet<StudentParentRelation> StudentParentRelations {get; set;}
        public DbSet<Subject> Subjects {get; set;}
        public DbSet<SubjectExam> SubjectExams {get; set;}
        public DbSet<SubjectPeriod> SubjectPeriods {get; set;}
        public DbSet<SubTeachStdRel> SubTeachStdRelations {get; set;}
        public DbSet<Subscription> Subscriptions {get; set;}

    }
}
