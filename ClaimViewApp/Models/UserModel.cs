using System;
using Dapper.Contrib.Extensions;

namespace ClaimViewApp.Models
{
    [Table("Users")]
    public class UserModel
    {
        public int UserId { get; set; }
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
    }
}
