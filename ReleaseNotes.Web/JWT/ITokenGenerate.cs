using ReleaseNotes.Web.ViewModel;

namespace ReleaseNotes.Web.JWT
{
    public interface ITokenGenerate
    {
        UserToken LoginTokenGenerate(LoginViewModel login);
        UserToken RegisterTokenGenerate(RegisterViewModel register);
    }
}
