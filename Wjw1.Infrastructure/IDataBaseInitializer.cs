using Microsoft.AspNetCore.Builder;

namespace Wjw1.Infrastructure
{
    public interface IDataBaseInitializer
    {
        void SeedData(IApplicationBuilder app);
    }
}
