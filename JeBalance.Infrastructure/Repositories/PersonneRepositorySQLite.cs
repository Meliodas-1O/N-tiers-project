using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Repository;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.Repositories
{
    public class PersonneRepositorySQLite : IPersonneRepository
    {
        Task<int> Repository<Personne>.Create(Personne T)
        {
            throw new NotImplementedException();
        }

        Task<bool> Repository<Personne>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Personne>> Repository<Personne>.Find(int limit, int offset, Specification<Personne> specification)
        {
            throw new NotImplementedException();
        }

        Task<Personne> Repository<Personne>.GetOne(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> Repository<Personne>.Update(int id, Personne T)
        {
            throw new NotImplementedException();
        }
    }
}
