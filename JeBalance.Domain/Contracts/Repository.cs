using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Contracts
{
	public interface Repository<T> where T : Entity
	{
		public Task<IEnumerable<T>> Find(int limit, int offset, Specification<T> specification);
		public Task<T> GetOne(string id);
		public Task<string> Create(T T);
		public Task<T> Update(string id, T T);
		public Task<bool> Delete(string id);
	}
}
