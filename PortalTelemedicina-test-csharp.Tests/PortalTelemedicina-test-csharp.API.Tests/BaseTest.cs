using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortalTelemedicina_test_csharp.Infraestructure.Repositories;
using System.Linq;
using Xunit;

namespace PortalTelemedicina_test_csharp.API.Tests
{
    public class BaseTest
    {
        protected ApplicationContext ctx;
        public BaseTest(ApplicationContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }
        protected ApplicationContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;

            ApplicationContext dbContext = new ApplicationContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
        protected void CheckError<T>(AbstractValidator<T> validator, int ErrorCode, T vm)
        {
            var val = validator.Validate(vm);
            Assert.False(val.IsValid);

            if (!val.IsValid)
            {
                bool hasError = val.Errors.Anny(a => a.ErrorCode.Equals(ErrorCode.ToString()));
                Assert.True(hasError);
            }
        }
    }
}
