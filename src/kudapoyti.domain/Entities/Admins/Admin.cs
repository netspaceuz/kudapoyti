﻿using kudapoyti.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Domain.Entities.Admins
{
    public class Admin:BaseEntity
    {
        [Required]
        public string FullName { get; set; }=String.Empty;

        public string Email { get; set; }=String.Empty;

        public string PhoneNumber { get; set; }= String.Empty;

        public string TelegramLink { get; set; }= String.Empty;

        public string Description { get; set; } = String.Empty;

        public string PasswordHash { get; set; }=String.Empty;
        
        public string Salt { get; set; }=String.Empty;

        public bool IsHead { get; set; }=false;
    }
}
