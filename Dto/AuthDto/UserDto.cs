﻿namespace Dto.AuthDto
{
    public class UserDto
    {
        public string PhoneNumber { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public string? Lastname { get; set; }

        public string Address { get; set; }

        public string? Avatar { get; set; } = null;
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; } = null!;

        public DateTime LoggedDate { get; set; }

        public bool IsAdmin { get; set; } = false;

    }
}
