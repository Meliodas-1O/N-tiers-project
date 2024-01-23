namespace JeBalance.API.Admin.Ressources
{
	public class IAdresseAPI
	{
		public int StreetNumber { get; set; }
		public string StreetName { get; set; }
		public int PostalCode { get; set; }
		public string CityName { get; set; }

		public IAdresseAPI() { }

	}
}
