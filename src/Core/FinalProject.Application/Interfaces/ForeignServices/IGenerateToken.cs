using FinalProject.Domain.Models;
using System.Security.Claims;


namespace FinalProject.Application.Interfaces.ForeignServices
{
    public interface IGenerateToken
    {
        Token CreateAccessToken(int minute, List<Claim> claims);
    }
}
