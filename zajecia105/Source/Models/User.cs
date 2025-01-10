using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zajecia105.Source.Enums;
using static zajecia105.Source.Program;

namespace zajecia105.Source.Models
{
    public class User
    {
        public string Username { get; set; }
        public List<Role> Roles { get; set; }

        public User(string username)
        {
            Username = username;
            Roles = new List<Role>();
        }

        public void AddRole(Role role)
        {
            if (!Roles.Contains(role))
            {
                Roles.Add(role);
            }
        }

       
    }
}
