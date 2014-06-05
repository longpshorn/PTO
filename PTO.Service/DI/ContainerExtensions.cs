using Autofac;
using Geocoding;
using Geocoding.Google;

namespace PTO.Service.DI
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder RegisterServiceDependencies(this ContainerBuilder builder)
        {
            return builder
                .RegisterAppServices()
                .RegisterGeolocator();
        }

        public static ContainerBuilder RegisterAppServices(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IUserService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            return builder;
        }

        public static ContainerBuilder RegisterGeolocator(this ContainerBuilder builder)
        {
            //register your geocoder implementation here -- note: it will use the last one registered

            //http://msdn.microsoft.com/en-us/library/ff428642.aspx
            //builder.Register(c => new BingMapsGeocoder("my-bing-maps-key")).As<IGeocoder>();

            //http://developer.yahoo.com/boss/geo/BOSS_Signup.pdf
            //builder.Register(c => new YahooGeocoder("my-yahoo-consumer-key", "my-yahoo-consumer-secret")).As<IGeocoder>();

            //https://developers.google.com/maps/documentation/javascript/tutorial#api_key
            //a server key is optional with Google
            builder.Register(c =>
                new GoogleGeocoder
                {
                    //ApiKey = "google-api-key-is-optional"
                })
                .As<IGeocoder>();

            return builder;
        }
    }
}
