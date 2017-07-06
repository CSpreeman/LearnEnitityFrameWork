using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearnEF.Models
{
    [Table("Appointment")]
    public class Appointment : User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Appointment_Id { get; set; }
        public string AppointmentType { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? RequestedDateTime { get; set; }
        public int AppointmentStatus { get; set; }

    }
}