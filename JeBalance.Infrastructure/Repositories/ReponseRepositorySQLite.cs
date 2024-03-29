﻿using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Repository;
using JeBalance.Infrastructure.Data;
using JeBalance.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.Repositories
{
    public class ReponseRepositorySQLite : IReponseRepository
    {
        private readonly DatabaseContext _context;

        public ReponseRepositorySQLite(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<string> Create(DenonciationReponse Reponse)
        {
            var reponseToSave = Reponse.ToSQLite();
            reponseToSave.DenonciationId = Reponse.DenonciationId;
            await _context.Reponses.AddAsync(reponseToSave);
            await _context.SaveChangesAsync();
            return reponseToSave.Id;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var responseToDelete = await _context.Reponses.FirstOrDefaultAsync(reponse => reponse.Id == id);

                if (responseToDelete == null)
                    return true;

                _context.Remove(responseToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<IEnumerable<DenonciationReponse>> Find(int limit, int offset, Specification<DenonciationReponse> specification)
        {
            throw new NotImplementedException();
        }

        public async Task<DenonciationReponse> GetOne(string id)
        {
            var reponse = await _context.Reponses.FirstAsync(reponse => reponse.Id == id);
            return reponse.ToDomain();
        }

        public async Task<DenonciationReponse> Update(string id, DenonciationReponse reponse)
        {
            var reponseToUpdate = _context.Reponses.First(reponse => reponse.Id == id);
            reponseToUpdate.Retribution = reponse.Retribution;
            reponseToUpdate.Timestamp = DateTime.Now;
            reponseToUpdate.Type = reponse.Type.ToString();
            reponseToUpdate.DenonciationId = reponse.DenonciationId;

            await _context.SaveChangesAsync();
            return reponseToUpdate;
        }
    }
}
