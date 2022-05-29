using System;
using System.Collections.Generic;

namespace WpfApp1
{
    public partial class User
    {
        public User()
        {
            TaskIdAcceptedNavigations = new HashSet<Task>();
            TaskIdCreatorNavigations = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Task> TaskIdAcceptedNavigations { get; set; }
        public virtual ICollection<Task> TaskIdCreatorNavigations { get; set; }
    }
}
