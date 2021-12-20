using ReleaseNotes.Identity.Controllers;

namespace ReleaseNote.Identity.JWT
{
    public interface ITokenGenerate
    {
        UserToken UserTokenGenerate(LoginViewModel model);
    }
}
