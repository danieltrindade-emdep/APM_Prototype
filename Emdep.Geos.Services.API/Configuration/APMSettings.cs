namespace Emdep.Geos.Services.API.Configuration
{
    public class APMSettings
    {
        public ImageSettings Images { get; set; }
    }

    public class ImageSettings
    {
        public string BaseUrlRounded { get; set; }
        public string BaseUrlNormal { get; set; }
        public string BaseUrlCountries { get; set; }
    }
}
