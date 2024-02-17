using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Tests.Drivers
{
    public class ReponseRepositoryDriver : IReponseRepository
    {
        public List<DenonciationReponse> _denonciationReponses;

        public ReponseRepositoryDriver()
        {
            _denonciationReponses = new List<DenonciationReponse>();
        }

        public Task<string> Create(DenonciationReponse T)
        {
            T.Id = _denonciationReponses.Count.ToString();
            _denonciationReponses.Add(T);
            return Task.FromResult(T.Id);
        }

        public Task<bool> Delete(string id)
        {
            var reponse = _denonciationReponses.FirstOrDefault(r => r.Id == id);
            if (reponse != null)
            {
                _denonciationReponses.Remove(reponse);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<IEnumerable<DenonciationReponse>> Find(int limit, int offset, Specification<DenonciationReponse> specification)
        {
            var reponses = _denonciationReponses.Where(specification.IsSatisfiedBy).Skip(offset).Take(limit);
            return Task.FromResult(reponses);
        }

        public Task<DenonciationReponse?> GetOne(string id)
        {
            var reponse = _denonciationReponses.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(reponse);
        }

        public Task<DenonciationReponse?> Update(string id, DenonciationReponse T)
        {
            var reponse = _denonciationReponses.FirstOrDefault(r => r.Id == id);
            if (reponse != null)
            {
                reponse.Timestamp = T.Timestamp;
                reponse.Type = T.Type;
                reponse.Retribution = T.Retribution;
                return Task.FromResult(reponse);
            }
            return Task.FromResult((DenonciationReponse?)null);
        }
    }

}
