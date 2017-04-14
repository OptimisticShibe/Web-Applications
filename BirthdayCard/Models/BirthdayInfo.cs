using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    

namespace BirthdayCard.Models
{
    public class BirthdayInfo
    {
        [Required(ErrorMessage = "Please enter from field")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please enter to field")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please enter message field")]
        public string Message { get; set; }
    }
}