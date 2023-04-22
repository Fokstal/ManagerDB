using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDB.Model
{
    public class Position
    {
		public int ID { get; set; }
		public string Name { get => Name; set => Name = value; }
		public decimal Salary { get; set; }
		public int MaxNumber { get; set; }
		public List<User> Users { get => Users; set => Users = value; }
		public int DepartmentID { get; set; }
		public virtual Department Department { get => Department; set => Department = value; }
	}
}
