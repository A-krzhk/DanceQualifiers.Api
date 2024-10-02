

using DanceQualifiers.Core.Models;

namespace DanceQualifiers.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(AppUser user);
    }
}
