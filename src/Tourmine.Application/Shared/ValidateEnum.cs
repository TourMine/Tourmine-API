using Tourmine.Application.Requests.Auth;

namespace Tourmine.Application.Shared
{
    public static class ValidateEnum
    {
        public static bool ValidateUserType(int userType)
        {
            // Valida se o valor recebido é um valor válido do enum EUserType
            return Enum.IsDefined(typeof(EUserType), userType);
        }
    }
}
