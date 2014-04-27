using AutoMapper;
namespace Vnsf.WebHost.Infrastructure.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMapping(IConfiguration configuration);
    }
}