using demo_DI.Abstractions;

namespace demo_DI
{
    public class DirectLink : IDirectLink
    {
        public string Ping()
        {
            return "DirectLink !";
        }
    }
}
