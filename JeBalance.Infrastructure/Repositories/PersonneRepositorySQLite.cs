using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Repository;
using JeBalance.Infrastructure.Data;
using JeBalance.Infrastructure.Models;
using Microsoft.Data.Sqlite;
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
			try
			{
				var personneToSave = personne.ToSQLite();
				await _context.Personnes.AddAsync(personneToSave);
				await _context.SaveChangesAsync();
				return personneToSave.Id;
			}
			catch (DbUpdateException ex ) when (ex.InnerException is SqliteException sqliteEx && sqliteEx.SqliteErrorCode == 19)
			{
				return "Les données que vous essayez d'enregistrer existent déjà. Veuillez vérifier si la dénonciation a déjà été soumise.";
			}
			catch (Exception)
			{
				return "Une erreur s'est produite lors de l'enregistrement des modifications de l'entité.";
			}
		}

        public async Task<bool> Delete(string id)
        {
			try
			{
				var personne = await _context.Personnes.FirstOrDefaultAsync(personne => personne.Id.ToString() == id);

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
				.Select(personne => personne.ToDomain());

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

		public async Task<Personne> Update(string id, Personne personne)
        {
			var personneToUpdate = _context.Personnes.First(personne => personne.Id.Equals(id));
			personneToUpdate.Prenom = personne.Prenom.Value;
			personneToUpdate.Nom = personne.Nom.Value;
			personneToUpdate.Adresse = personne.Adresse.Value;
			personneToUpdate.NombreAvertissement = personne.NombreAvertissement;

			await _context.SaveChangesAsync();
			return personneToUpdate;
		}
		public async Task<Personne?> FindOneVIP(string id)
		{
			var personne = _context.Personnes
				.Where(p => p.TypePersonne.Equals("VIP"))
				.FirstOrDefault(p => p.Id.Equals(id));
			if (personne != null)
			{
				return personne.ToDomain();
			}
			else
			{
				return null;
			}
		}

		public async Task<Personne> ChangeStatus(string id, TypePersonne type)
		{
			var personneToUpdate = _context.Personnes.First(personne => personne.Id.Equals(id));
			personneToUpdate.TypePersonne = type.ToString();
			await _context.SaveChangesAsync();
			return personneToUpdate;
		}
	}
}
