using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearnEF.Models
{
    [Table("User")]
    public class User : Animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}