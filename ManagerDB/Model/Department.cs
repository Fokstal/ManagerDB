using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDB.Model
{
    public class Department
    {
        public int ID { get; set; }
		public string? Name { get; set; }

        private List<Position>? _positions = new List<Position>();
		public List<Position>? Positions { get => _positions; set => _positions = value; }
    }
}
