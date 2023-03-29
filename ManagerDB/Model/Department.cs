using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDB.Model
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get => Name; set => Name = value; }
        public List<Position> Positions { get => Positions; set => Positions = value; }
    }
}
