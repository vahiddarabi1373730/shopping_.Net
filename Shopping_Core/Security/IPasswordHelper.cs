namespace Shopping_Core.Security
{
    public interface IPasswordHelper
    {
        string EncodePasswordMd5(string password);
    }
}
