﻿namespace SnippersAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[0];

        public byte[] PasswordSalt { get; set; } = new byte[0];



    }
}
