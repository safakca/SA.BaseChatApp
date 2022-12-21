using Microsoft.AspNetCore.Identity;

namespace Presentation.Models;
//TODO: bu class ve gerekliligini kontrol et

public class CustomeIdentityValidator : IdentityErrorDescriber
{
    public override IdentityError PasswordTooShort(int length)
    {
        return new IdentityError()
        {
            Code = "PasswordTooShort",
            Description = $"Şifre en az {length} uzunluğunda olmalıdır."
        };
    }
}
