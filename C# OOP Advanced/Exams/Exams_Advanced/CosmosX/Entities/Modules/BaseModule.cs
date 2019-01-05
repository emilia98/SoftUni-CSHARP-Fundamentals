using CosmosX.Entities.Modules.Contracts;

namespace CosmosX.Entities.Modules
{
    public abstract class BaseModule : IModule
    {
        // private static int id = 0;
        protected BaseModule(int id)
        {
            // id++;
            this.Id = id;
        }

        // public int Id => id;
        public int Id { get;}

        public override string ToString()
        {
            return $"{this.GetType().Name} Module - {this.Id}\n";
        }
    }
}