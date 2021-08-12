using Entities.Concreate.BaseEntities;
using System;

namespace Entities.Concreate
{
    public class User:AuditableEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public float CardLimit { get; set; }
    }
}
