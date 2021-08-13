﻿using Entities.Abstract;
using System;

namespace Entities.Dtos.UserDtos
{
    public class UserDetailDto:IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public float CardLimit { get; set; }
    }
}
