using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Repository;
using JeBalance.Infrastructure.Data;
using JeBalance.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.Repositories
{
    public class DenonciationRepositorySQLite : IDenonciationRepository
    {
        private readonly DatabaseContext _context;

        public DenonciationRepositorySQLite (DatabaseContext context)
        {
            _context = context;
        }
        public async Task<string> Create(Denonciation denonciation)
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

        public async Task<IEnumerable<Denonciation>> Find(int limit, int offset, Specification<Denonciation> specification)
        {
            throw new NotImplementedException();
        }

        public async Task<Denonciation?> GetOne(string id)
        {
            var denonciation = _context.Denonciations
                .Include(d => d.Informateur)
                .Include(d => d.Suspect)
                .FirstOrDefault(personne => personne.Id.Equals(id));
			if (denonciation != null)
			{
				return denonciation.ToDomain();
			}
			else
			{
				return null;
			}
		}

        public async Task SetReponse(DenonciationReponse newReponse)
        {
            var denonciationToUpdate = _context.Denonciations.FirstOrDefault(denonciation =>  denonciation.Id.Equals(newReponse.DenonciationId));
            denonciationToUpdate.ReponseId = newReponse.Id;
            await _context.SaveChangesAsync();
        }

        public async Task<string> Update(string id, Denonciation denonciation)
        {
            var denonciationToUpdate = _context.Denonciations.First(denonciation => denonciation.Id.Equals(id));
            denonciationToUpdate.Delit = denonciation.Delit.ToString();
            denonciationToUpdate.PaysEvasion = denonciation.PaysEvasion.Value;

            await _context.SaveChangesAsync();
            return id;
        }
    }
}
