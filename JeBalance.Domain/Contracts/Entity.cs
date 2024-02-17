using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Contracts
{
	public abstract class Entity
	{
		[Key]
		public string Id { get; set; }
		public Entity(string id) => Id = id;
	}
}
