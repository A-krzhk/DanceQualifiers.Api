using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceQualifiers.Application.Interfaces
{
    public interface IRoleSeeder
    {
        Task SeedRolesAsync();
    }
}
