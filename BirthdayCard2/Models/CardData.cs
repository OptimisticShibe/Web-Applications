using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BirthdayCard2.Models
{
    public class CardData
    {
        [Required(ErrorMessage = "Please enter a recipient")]
        public string Recipient { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Sender { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
    }
}