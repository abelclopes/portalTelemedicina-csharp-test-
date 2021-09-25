using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTelemedicina_test_csharp.Domain.Models
{
    public class User
    {
        public User()
        {

        }
        public User(int Id, string Name, int Age, bool IsActive)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.IsActive = IsActive;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
