using System.ComponentModel.DataAnnotations;

namespace shopapp.webui.Models
{
    public class ContactModel
    {
        public int Id { get; set;}

        [Required(ErrorMessage="The name field cannot be empty.")]
        [StringLength(20,MinimumLength=5,ErrorMessage="You must enter a value between 5 and 20 for the message.")] 
        public string Name { get; set;}

        [Required(ErrorMessage="The email field cannot be left empty.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}

        [Required(ErrorMessage="The message field cannot be left empty.")]
        [StringLength(1000,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 1000 characters for the message.")] 
        public string Message { get; set;}
    }
}