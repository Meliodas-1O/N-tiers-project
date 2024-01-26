using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;
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
        public async Task<int> Create(Denonciation denonciation)
        {
            var denonciationToSave = denonciation.ToSQLite();
            await _context.Denonciations.AddAsync(denonciationToSave);
            await _context.SaveChangesAsync();
            return denonciationToSave.Id;
        }

        public async Task<bool> Delete(int id)
        {
            try{
                var denonciationToDelete = await _context.Denonciations.FirstOrDefaultAsync(denonciation => denonciation.Id == id);

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

        public async Task<Denonciation> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SetReponse(DenonciationReponse newReponse)
        {
            var denonciationToUpdate = _context.Denonciations.FirstOrDefault(denonciation =>  denonciation.Id == newReponse.DenonciationId);
            denonciationToUpdate.ReponseId = newReponse.Id;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Denonciation denonciation)
        {
            var denonciationToUpdate = _context.Denonciations.First(denonciation => denonciation.Id == id);
            denonciationToUpdate.Informateur = denonciation.Informateur.ToSQLite();
            denonciationToUpdate.Suspect = denonciation.Suspect.ToSQLite();
            denonciationToUpdate.Delit = denonciation.Delit.ToString();
            denonciationToUpdate.PaysEvasion = denonciation.PaysEvasion.Value;

            await _context.SaveChangesAsync();
            return id;
        }
    }
}
