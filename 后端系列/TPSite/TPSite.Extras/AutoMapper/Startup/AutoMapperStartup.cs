using TPSite.Extras.AutoMapper.Configuration;

namespace TPSite.Extras.AutoMapper.Startup
{
    public class AutoMapperStartup
    {
        public static void Register()
        {
            AutoMapperConfiguration.Init();
        }
    }
}
