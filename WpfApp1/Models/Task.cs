using System;
using System.Collections.Generic;

namespace WpfApp1
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Desk { get; set; } = null!;
        public DateTime DateOfPublic { get; set; }
        public int IdCreator { get; set; }
        public int? IdAccepted { get; set; }
        public int IdStatusTask { get; set; }

        public virtual User? IdAcceptedNavigation { get; set; }
        public virtual User IdCreatorNavigation { get; set; } = null!;
        public virtual StatusTask IdStatusTaskNavigation { get; set; } = null!;
    }
}
