using P335_BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace P335_BackEnd.Areas.Admin.Models
{
	public class ContactInfoVM
	{
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
       
    }
}
