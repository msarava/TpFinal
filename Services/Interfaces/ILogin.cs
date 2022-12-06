namespace LeBonCoin_Toulouse.Services.Interfaces
{
    public interface ILogin
    {
        // add interface for login with JWT
        public string Login(string mail, string password);
    }
}
