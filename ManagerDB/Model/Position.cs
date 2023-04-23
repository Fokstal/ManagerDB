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
		public string? Name { get; set; }
		public decimal Salary { get; set; }
		public int MaxNumber { get; set; }

		private List<User>? _users = new List<User>();
		public List<User>? Users { get => _users; set => _users = value; }
		public int DepartmentID { get; set; }
		public virtual Department? Department { get; set; }
	}
}
