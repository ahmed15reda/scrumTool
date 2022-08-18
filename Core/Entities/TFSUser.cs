using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class TFSUser
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public string TFSName { get; set; }
        public Department Department { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Minimem length must be at least 6 charcters")]
        [MaxLength(8, ErrorMessage = "Maximum length must be at least 8 charcters")]
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        [Required]
        public int UserRoleId { get; set; }
        public string ImageURL { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public TFSUser Creator { get; set; }
        public Squad Squad { get; set; }
        public int SquadId { get; set; }
        public int Ordering { get; set; }
    }
}
