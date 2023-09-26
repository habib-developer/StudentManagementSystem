using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.API.DomainModels
{
	public class Student
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
