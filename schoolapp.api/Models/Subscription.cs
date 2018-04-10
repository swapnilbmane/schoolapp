using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public Student Student { get; set; }
        public DateTime SubscribedDate { get; set; }
        public bool IsActive { get; set; }
        public int Amount { get; set; }
    }
}
