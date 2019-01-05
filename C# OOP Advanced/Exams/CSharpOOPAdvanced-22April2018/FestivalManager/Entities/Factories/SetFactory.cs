namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
			if (type == "Short")
			{
				return new Short(name);
			}
			else if (type == "Medium")
			{
				return new Medium(name);
			}
			else if (type == "Long")
			{
				return new Long(name);
			}
            return null;
		}
	}
}
