using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Services
{
    public interface IDenonciationReponseService
    {
        Task<IEnumerable<Denonciation>> GetUnansweredDenonciation(IDenonciationParameters parameters);
        Task<Denonciation> FindDenonciation(string denonciationId);
        Task<Denonciation> SetReponseInDenonciation(string denonciationId, string reponseId);
        Task<string> CreateReponse(string denonciationId, TypeReponse type, int retribution);
        Task<bool> IncreaseWarningNumber(string informateurId, Personne informateur);
        Task<bool> SetCalomniateurType(string informateurId);
    }
}
