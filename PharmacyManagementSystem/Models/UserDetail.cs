﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyManagementSystem.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Contact { get; set; }
        public string UserAddress { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
