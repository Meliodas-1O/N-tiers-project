using JeBalance.API.InspectionFiscale.Ressources;

namespace JeBalance.API.InspectionFiscale.Models
{
    public class Pagination
    {
        public IEnumerable<DenonciationAPI> Data { get; set; } = null!;
        public int Length { get; set; }
    }
}
