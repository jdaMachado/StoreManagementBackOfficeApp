using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UserResponseDTO
    {
        public Guid ID { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsAdmin { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
