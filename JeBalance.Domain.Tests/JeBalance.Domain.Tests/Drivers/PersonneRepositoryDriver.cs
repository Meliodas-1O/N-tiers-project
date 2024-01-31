using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Repository;

namespace JeBalance.Domain.Tests.Drivers
{
    public class PersonneRepositoryDriver : IPersonneRepository
    {
        public List<Personne> Personnes;
        public PersonneRepositoryDriver()
        {
            Personnes = new List<Personne>();
        }

        public Task<Personne> ChangeStatus(string id, TypePersonne type)
        {
            Personne personne = Personnes.Single(personne => personne.Id == id);
            var index = Personnes.IndexOf(personne);
            Personnes[index] = new Personne(id, personne.Prenom.Value, personne.Nom.Value, type, personne.NombreAvertissement, personne.Adresse);
            return Task.FromResult(Personnes[index]);
        }

        public Task<string> Create(Personne T)
        {
            string id = (Personnes.Count + 1).ToString();
            Personnes.Add(new Personne(id, T.Prenom.Value, T.Nom.Value, T.TypePersonne, T.NombreAvertissement, T.Adresse));
            return Task.FromResult(id);
        }

        public Task<bool> Delete(string id)
        {
            Personnes.RemoveAll(personne => personne.Id == id);
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<Personne>> Find(int limit, int offset, Specification<Personne> specification)
        {
            var places = Personnes
                .Where(specification.IsSatisfiedBy)
                .Skip(offset)
                .Take(limit);
            return places;
        }

        public Task<Personne?> FindOneVIP(string id)
        {
            try
            {
                return Task.FromResult(Personnes.Single(personne
                    => personne.Id == id && personne.TypePersonne == TypePersonne.VIP));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Task<Personne?> GetOne(string id)
        {
            try { 
                return Task.FromResult(Personnes.Single(personne
            => personne.Id == id));
            } 
            catch (Exception ex) {
                return null;
            }
        }
          
        public Task<Personne> Update(string id, Personne T)
        {
            Personne personne = Personnes.Single(personne => personne.Id == id);
            int index = Personnes.IndexOf(personne);
            Personnes[index] = new Personne(T.Prenom.Value, T.Nom.Value, personne.TypePersonne, T.NombreAvertissement,T.Adresse);
            return Task.FromResult(T);
        }
    }
}
