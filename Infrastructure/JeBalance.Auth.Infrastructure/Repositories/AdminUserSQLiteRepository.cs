using JeBalance.Auth.Infrastructure.Data;
using JeBalance.Auth.Infrastructure.Repositories;
using JeBalance.Domain.Models.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Auth.Infrastructure.Repositories
{
	public class AdminUserSQLiteRepository
	{

		private readonly AuthDbContext _context;
		public AdminUserSQLiteRepository(AuthDbContext context)
		{
			_context = context;
		}

		public async Task<string> Create(AdminPersonne admin)
		{
			var adminToSave = admin.ToSQLite();
			await _context.Admin.AddAsync(adminToSave);
			await _context.SaveChangesAsync();
			return adminToSave.Id;
		}

	}
}



public async Task<bool> Delete(string id)
{
	try
	{
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

public async Task<IEnumerable<AdminPersonne>> Find(int limit, int offset, Specification<AdminPersonne> specification)
{
	throw new NotImplementedException();
}

public async Task<AdminPersonne?> GetOne(string id)
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
	var denonciationToUpdate = _context.Denonciations.FirstOrDefault(denonciation => denonciation.Id.Equals(newReponse.DenonciationId));
	denonciationToUpdate.ReponseId = newReponse.Id;
	await _context.SaveChangesAsync();
}

public async Task<string> Update(string id, AdminPersonne denonciation)
{
	var denonciationToUpdate = _context.Denonciations.First(denonciation => denonciation.Id.Equals(id));
	denonciationToUpdate.Delit = denonciation.Delit.ToString();
	denonciationToUpdate.PaysEvasion = denonciation.PaysEvasion.Value;

	await _context.SaveChangesAsync();
	return id;
}
    }