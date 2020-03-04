using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
    [Table(name: "t_users")]
    public class User
    {
        [Column(name: "id")]
        public Guid ID { get; set; }

        [Column(name: "full_name")]
        public string FullName { get; set; }

        [Column(name: "email")]
        public string Email { get; set; }

        [Column(name: "phone")]
        public string Phone { get; set; }

        [Column(name: "is_admin")]
        public bool IsAdmin {get; set; }

        [Column(name: "user_name")]
        public string UserName { get; set; }

        [Column(name: "password")]
        public string Password { get; set; }

        [Column(name: "salt")]
        public string Salt { get; set; }

        [Column(name: "created_at")]
        public DateTime CreatedAt{ get; set; }

        [Column(name: "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column(name: "deleted_at")]
        public DateTime DeletedAt { get; set; }
    }
}
