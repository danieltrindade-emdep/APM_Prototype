namespace Emdep.Geos.API.Configuration;

public class APMSettings
{
    public string MailServerName { get; set; }
    public int MailServerPort { get; set; }
    public string MailFrom { get; set; }
    public APMPaths Paths { get; set; }
}

public class APMPaths
{
    public string CountryFilePath { get; set; }
    public string APMActionPlanTaskAttachments { get; set; }
    public string APMActionPlanAttachments { get; set; }
    public string EmailTemplate { get; set; }
}