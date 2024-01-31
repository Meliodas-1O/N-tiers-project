using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Repository;
using JeBalance.Infrastructure.Data;
using JeBalance.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.Repositories
{
    public class DenonciationRepositorySQLite : IDenonciationRepository
    {
        private readonly DatabaseContext _context;

        public DenonciationRepositorySQLite (DatabaseContext context)
        {
            _context = context;
        }
        public async Task<string?> Create(Denonciation denonciation)
        {
				var denonciationToSave = denonciation.ToSQLite();
				await _context.Denonciations.AddAsync(denonciationToSave);
				await _context.SaveChangesAsync();
				return denonciationToSave.Id;
		}

        public async Task<bool> Delete(string id)
        {
            try{
                var denonciationToDelete = await _context.Denonciations.FirstOrDefaultAsync(denonciation => denonciation.Id.Equals(id));

                if (denonciationToDelete == null)
                    return true;

                _context.Remove(denonciationToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<IEnumerable<Denonciation>> Find(int limit, int offset, Specification<Denonciation> specification)
        {
            var results = _context.Denonciations
                .Apply(specification.ToSQLiteExpression<Denonciation, DenonciationSQLite>())
				.OrderByDescending(d => d.Horodatage)
				.Skip(offset)
                .Take(limit)
                .Include(d => d.Informateur)
                .Include(d => d.Suspect)
                .Include(d => d.Reponse)
                .AsEnumerable()
				.Select(denonciation => denonciation.ToDomain());

			return Task.FromResult(results);
		}

        public async Task<Denonciation?> GetOne(string id)
        {
            try
            {
                var denonciation = await _context.Denonciations
                    .Include(d => d.Informateur)
                    .Include(d => d.Suspect)
                    .Include(d => d.Reponse)
                    .FirstOrDefaultAsync(personne => personne.Id.Equals(id));
                return denonciation.ToDomain();
            }
            catch {
                return null;
            }
		}

        public async Task<Denonciation> SetReponse(string denonciationId, string reponseId)
        {
            var denonciationToUpdate =  await _context.Denonciations.FirstOrDefaultAsync(denonciation =>  denonciation.Id.Equals(denonciationId));
            denonciationToUpdate.ReponseId = reponseId;
            await _context.SaveChangesAsync();
            return denonciationToUpdate;
        }

        public async Task<Denonciation> Update(string id, Denonciation denonciation)
        {
            var denonciationToUpdate = _context.Denonciations.First(denonciation => denonciation.Id.Equals(id));
            denonciationToUpdate.Delit = denonciation.Delit.ToString();
            denonciationToUpdate.PaysEvasion = denonciation.PaysEvasion.Value;

            await _context.SaveChangesAsync();
            return denonciationToUpdate;
        }
    }
}
