using System;
using System.Text.RegularExpressions;

namespace ManagerDB.Model
{
	public static class ControlValidators
	{
		public static ValidatorName RulesForName(this string? name) => new(name);
		public static ValidatorPhone RulesForPhone(this string? phone) => new(phone);
		public static ValidatorNumber RulesForNumber(this string numberStr) => new(numberStr);
	}

	public class BaseValidator
	{
		protected string? _content;

		protected bool _success = true;

		public BaseValidator(string? content) => _content = content;

		public virtual BaseValidator IsNull()
		{
			if (_content == null) _success = false;

			return this;
		}

		public bool Validate() => _success;
	}

	public class ValidatorName : BaseValidator
    {
		public ValidatorName(string? content) : base(content) {}

		public override ValidatorName IsNull()
		{
			base.IsNull();

			return this;
		}

		public ValidatorName Length(int minLen = Int32.MinValue, int maxLen = Int32.MaxValue)
		{
			if (_content?.Length < minLen || _content?.Length > maxLen) _success = false;

			return this;
		}

		public ValidatorName IsSpace()
		{
			if (_content?.Replace(" ", "").Length == 0) _success = false;

			return this;
		}
	}

	public class ValidatorPhone : BaseValidator
	{
		public ValidatorPhone(string? phone) : base(phone) { }

		public override ValidatorPhone IsNull()
		{
			base.IsNull();

			return this;
		}

		public ValidatorPhone CheckMask()
		{
			if (_content is not null && !new Regex(@"\+\d+ \(\d{2}\) \d{3}-\d{2}-\d{2}").IsMatch(_content)) _success = false;

			return this;
		}
	}

	public class ValidatorNumber : BaseValidator
	{
		public ValidatorNumber(string? numberStr) : base(numberStr) { }

		public ValidatorNumber IsNumber()
		{
			try
			{
				Convert.ToInt32(_content);
			}
			catch
			{
				_success = false;
			}

			return this;
		}

		public ValidatorNumber Range(int minEl = Int32.MinValue, int maxEl = Int32.MaxValue)
		{
			IsNumber();

			if (_success)
			{
				int number = Convert.ToInt32(_content);

				if (number < minEl || number > maxEl) _success = false;
			}

			return this;
		}
	}

}
