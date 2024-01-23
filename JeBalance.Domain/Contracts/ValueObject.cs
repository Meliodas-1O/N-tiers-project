using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Contracts
{
	public abstract class SimpleValueObject<T>
	{
		public T Value { get; }
		public SimpleValueObject(T value) => Value = Validate(value);

		public abstract T Validate(T value);
	}

}
