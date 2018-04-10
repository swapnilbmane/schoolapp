using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class EventNotification
    {
        [Key]
        public int EventNotificationId { get; set; }
        public SchoolEvent SchoolEvent { get; set; }
        public Person TaggedPerson { get; set; }
        public bool IsNotified { get; set; }
        public DateTime ScheduledOn { get; set; }
    }
}
