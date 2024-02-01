using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Tests.Drivers
{

    public class DenonciationRepositoryDriver : IDenonciationRepository
    {
        public List<Denonciation> Denonciations;

        public DenonciationRepositoryDriver()
        {
            Denonciations = new List<Denonciation>();
        }

        public Task<string> Create(Denonciation T)
        {
            string id = (Denonciations.Count + 1).ToString();
            T.Id = id;
            Denonciations.Add(T);
            return Task.FromResult(id);
        }

        public Task<bool> Delete(string id)
        {
            Denonciations.RemoveAll(denonciation => denonciation.Id == id);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Denonciation>> Find(int limit, int offset, Specification<Denonciation> specification)
        {
            var denonciations = Denonciations.Where(specification.IsSatisfiedBy).Skip(offset).Take(limit);
            return Task.FromResult(denonciations);
        }

        public Task<Denonciation> GetOne(string id)
        {
            var denonciation = Denonciations.FirstOrDefault(d => d.Id == id);
            return Task.FromResult(denonciation);
        }

        public Task<Denonciation> SetReponse(string denonciationId, string reponseId)
        {
            var denonciation = Denonciations.FirstOrDefault(d => d.Id == denonciationId);
            if (denonciation != null)
            {
                denonciation.ReponseId = reponseId;
            }
            return Task.FromResult(denonciation);
        }

        public Task<Denonciation> Update(string id, Denonciation T)
        {
            var denonciation = Denonciations.FirstOrDefault(d => d.Id == id);
            if (denonciation != null)
            {
                int index = Denonciations.IndexOf(denonciation);
                Denonciations[index] = T;
            }
            return Task.FromResult(denonciation);
        }
    }
}
