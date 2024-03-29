namespace HackathonDGTU.Services.Exceptions;

public class NoneAuthorizedException : Exception
{
    public NoneAuthorizedException () : base("Пользователь не авторизован!")
    {

    }
}