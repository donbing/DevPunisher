using System.Xml.Linq;
using System.Configuration;
namespace BuildFetcher
{
    public interface IHudsonBuildXmlFetcher
    {
        XDocument GetBuildXmlFor(string jobName, int buildNumber);
    }

	public class HudsonBuildXmlFetcher : IHudsonBuildXmlFetcher
	{
        private readonly string rootUri;

		public HudsonBuildXmlFetcher ()
		{
			this.rootUri = ConfigurationManager.AppSettings["rootUri"];
		}
		
        

		public XDocument GetBuildXmlFor(string jobName, int buildNumber)
        {
            string buildUri = string.Format("{0}/job/{1}/{2}/api/xml", rootUri, jobName, buildNumber);

            return XDocument.Load(buildUri);
        }
	}
}