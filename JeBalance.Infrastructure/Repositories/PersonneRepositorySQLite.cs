﻿using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Repository;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.Data;
using JeBalance.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace JeBalance.Infrastructure.Repositories
{
    public class PersonneRepositorySQLite : IPersonneRepository
    {
		private readonly DatabaseContext _context;

		public PersonneRepositorySQLite(DatabaseContext context)
		{
			_context = context;
		}
		public async Task<string> Create(Personne personne)
        {
			var personneToSave = personne.ToSQLite();
			await _context.Personnes.AddAsync(personneToSave);
			await _context.SaveChangesAsync();
			return personneToSave.Id;
		}

        public async Task<bool> Delete(string id)
        {
			try
			{
				var personne = await _context.Personnes.FirstOrDefaultAsync(personne => personne.Id == id);

				if (personne == null)
					return true;

				_context.Remove(personne);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

        public Task<IEnumerable<Personne>> Find(int limit, int offset, Specification<Personne> specification)
        {
			var results = _context.Personnes
				.Apply(specification.ToSQLiteExpression<Personne, PersonneSQLite>())
				.Skip(offset)
				.Take(limit)
				.AsEnumerable()
				.Select(place => place.ToDomain());

			return Task.FromResult(results);
		}
		public Task<IEnumerable<Personne>> FindAllVIP()
		{
			var results = _context.Personnes
				.Where(p => p.TypePersonne.Equals("VIP"))
				.AsEnumerable()
				.Select(place => place.ToDomain());

			return Task.FromResult(results);
		}
		public async Task<Personne?> GetOne(string id)
        {
			var personne = _context.Personnes.FirstOrDefault(p => p.Id.Equals(id));
			if (personne != null)
			{
				return personne.ToDomain();
			}
			else
			{
				return null;
			}
		}

		public async Task<string> Update(string id, Personne personne)
        {
			var personneToUpdate = _context.Personnes.First(personne => personne.Id.Equals(id));
			personneToUpdate.Prenom = personne.Prenom.Value;
			personneToUpdate.Nom = personne.Nom.Value;
			personneToUpdate.Adresse = personne.Adresse.Value;

			await _context.SaveChangesAsync();
			return id;
		}

	}
}
