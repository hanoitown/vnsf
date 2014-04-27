using System.Data.Entity;

namespace Vnsf.Data.EF
{
    public abstract class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        //static BaseContext()
        //{
        //    Database.SetInitializer<TContext>(null);
        //}
        protected BaseContext()
            : base("name=Vnsf")
        { }
    }
}
