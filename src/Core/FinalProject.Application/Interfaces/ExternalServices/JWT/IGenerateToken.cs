using FinalProject.Domain.Models;
using System.Security.Claims;


namespace FinalProject.Application.Interfaces.ExternalServices.JWT
{
    public interface IGenerateToken
    {
        Token CreateAccessToken(int minute, List<Claim> claims);
    }
}
