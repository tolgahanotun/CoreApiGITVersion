

using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Security
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(TUser user);

        void RevokeRefreshToken(TUser user);
    }
}