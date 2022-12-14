using ArrnowConstruct.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Tests.Mocks
{
    public class DatabaseMock
    {
        public static ArrnowConstructDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ArrnowConstructDbContext>()
                    .UseInMemoryDatabase("ArrnowConstructInMemoryDb"
                    +DateTime.Now.Ticks.ToString())
                    .Options;

                return new ArrnowConstructDbContext(dbContextOptions, false);
            }
        }
    }
}
