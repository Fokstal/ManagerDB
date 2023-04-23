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
		public string? Name { get; set; }
		public string? Surname { get; set; }
        public string? Phone { get; set; }
        public int PositionID { get; set; }
        public Position? Position { get; set; }
	}
}
