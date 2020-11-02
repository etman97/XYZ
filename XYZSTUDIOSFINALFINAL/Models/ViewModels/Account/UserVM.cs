using System.ComponentModel.DataAnnotations;
using XYZSTUDIOSFINALFINAL.Models.Data;

namespace XYZSTUDIOSFINALFINAL.Models.ViewModels.Account
{
    public class UserVM
    {
        public UserVM()
        {
        }

        public UserVM(UserDTO row)
        {
            Id = row.Id;
            FirstName = row.FirstName;
            LastName = row.LastName;
            EmailAddress = row.EmailAddress;
            Username = row.Username;
            PhoneNumber = row.PhoneNumber;
            Password = row.Password;
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}