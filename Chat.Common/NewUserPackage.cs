using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Common
{
    using System.Collections.ObjectModel;

    [Serializable]
    public class NewUserPackage
    {
        public NewUserPackage()
        {
            Users = new ObservableCollection<User>();
        }
        public ObservableCollection<User> Users { get; set; }
    }
    [Serializable]
    public class User
    {
        public Guid Identity { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
