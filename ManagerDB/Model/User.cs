using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDB.Model
{
    public class User
    {
        public int ID { get; set; }
		public string Name { get => Name; set => Name = value; }
		public string Surname { get => Surname; set => Surname = value; }
        public string Phone { get => Phone; set => Phone = value; }
        public int PositionID { get; set; }
        public Position Position { get => Position; set => Position = value; }
	}
}
