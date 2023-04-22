using System;
using System.Collections.Generic;
using System.Linq;
using ManagerDB.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagerDB.Model
{
	public static class DataWorker
	{
		private static readonly string codeUser = "user";
		private static readonly string codePosition = "position";
		private static readonly string codeDepartment = "department";

		//Department
		public static string AddNewValue(string? name)
		{
			string result = $"This {codeDepartment} exists";

			if (name is null) return "Your data contains null value!";

			using (ApplicationContext db = new())
			{
				bool checkIsExist = db.Departments.Any(el => el.Name == name);

				if (!checkIsExist && name is not null)
				{
					Department newDepartment = new() { Name = name };

					db.Departments.Add(newDepartment);
					db.SaveChanges();

					result = $"Adding a new {codeDepartment} is succeeded";
				}
			}

			return result;
		}
		public static string DeleteValue(Department value)
		{
			string result = $"This {codeDepartment}({value.Name}) is not exists";

			using (ApplicationContext db = new ApplicationContext())
			{
				bool checkIsExist = db.Departments.Contains(value); ;

				if (checkIsExist)
				{
					db.Departments.Remove((Department)value);
					db.SaveChanges();

					result = $"This {codeDepartment}({value.Name}) hase been delete";
				}
			}

			return result;
		}
		public static string EditValue(Department oldValue, string newName)
		{
			string result = $"This {codeDepartment}({oldValue.Name}) is not exists";

			using (ApplicationContext db = new ApplicationContext())
			{
				Department? value = db.Departments.FirstOrDefault(v => v.ID == oldValue.ID);

				if (value != null)
				{
					value.Name = newName;

					db.SaveChanges();

					result = $"Done! This {codeDepartment}({oldValue.Name}) has been changed";
				}
			}

			return result;
		}
		public static List<Department> GetAllDepartment()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Departments.ToList();
			}
		}

		//Position
		public static string AddNewValue(string? name, decimal salary, int maxNumber, Department? department)
		{
			string result = $"This {codePosition} exists";

			if (name is null || department is null) return "Your data contains null value!";

			using (ApplicationContext db = new ApplicationContext())
			{
				bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);

				if (!checkIsExist)
				{
					Position newPosition = new Position()
					{
						Name = name,
						Salary = salary,
						MaxNumber = maxNumber,
						DepartmentID = department.ID
					};

					db.Positions.Add(newPosition);
					db.SaveChanges();

					result = $"Adding a new {codePosition} is succeeded";
				}
			}

			return result;
		}
		public static string DeleteValue(Position value)
		{
			string result = $"This {codePosition}({value.Name}) is not exists";

			using (ApplicationContext db = new ApplicationContext())
			{
				bool checkIsExist = db.Positions.Contains(value); ;

				if (checkIsExist)
				{
					db.Positions.Remove((Position)value);
					db.SaveChanges();

					result = $"This {codeDepartment}({value.Name}) hase been delete";
				}
			}

			return result;
		}
		public static string EditValue(Position oldValue, string newName, decimal newSalary, int newMaxNumber, Department newDepartment)
		{
			string result = $"This {codePosition}({oldValue.Name}) is not exists";

			using (ApplicationContext db = new ApplicationContext())
			{
				Position? value = db.Positions.FirstOrDefault(v => v.ID == oldValue.ID);

				if (value != null)
				{
					value.Name = newName;
					value.Salary = newSalary;
					value.MaxNumber = newMaxNumber;
					value.DepartmentID = newDepartment.ID;

					db.SaveChanges();

					result = $"Done! This {codePosition}({oldValue.Name}) has been changed";
				}
			}

			return result;
		}
		public static List<Position> GetAllPosition()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Positions.ToList();
			}
		}

		//User
		public static string AddNewValue(string? name, string? surname, string? phone, Position? position)
		{
			string result = $"This {codeUser} exists";

			if (name is null || surname is null || phone is null || position is null) return "Your data contains null value!";

			using (ApplicationContext db = new ApplicationContext())
			{
				bool checkIsExist = db.Users.Any(el => el.Name == name && el.Surname == surname && el.Position == position);

				if (!checkIsExist)
				{
					User newUser = new User()
					{
						Name = name,
						Surname = surname,
						Phone = phone,
						PositionID = position.ID
					};

					db.Users.Add(newUser);
					db.SaveChanges();

					result = $"Adding a new {codeUser} is succeeded";
				}
			}

			return result;
		}
		public static string DeleteValue(User value)
		{
			string result = $"This {codeUser}({value.Name}) is not exists";

			using (ApplicationContext db = new ApplicationContext())
			{
				bool checkIsExist = db.Users.Contains(value); ;

				if (checkIsExist)
				{
					db.Users.Remove((User)value);
					db.SaveChanges();

					result = $"This {codeUser}({value.Name}) hase been delete";
				}
			}

			return result;
		}
		public static string EditValue(User oldValue, string newName, string newSurname, string newPhone, Position newPosition)
		{
			string result = $"This {codeUser}({oldValue.Name}) is not exists";

			using (ApplicationContext db = new ApplicationContext())
			{
				User? value = db.Users.FirstOrDefault(v => v.ID == oldValue.ID);

				if (value != null)
				{
					value.Name = newName;
					value.Surname = newSurname;
					value.Phone = newPhone;
					value.PositionID = newPosition.ID;

					db.SaveChanges();

					result = $"Done! This {codeUser}({oldValue.Name}) has been changed";
				}
			}

			return result;
		}
		public static List<User> GetAllUser()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Users.ToList();
			}
		}
	}
}
