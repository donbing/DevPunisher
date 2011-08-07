using System;
using System.Xml.Linq;
using System.Configuration;

namespace BuildFetcher
{
    public interface IHudsonJobXmlFetcher
    {
        XDocument GetJobXmlFor(string jobName);
    }
	
	public class HudsonJobXmlFetcher : IHudsonJobXmlFetcher
    {
		private readonly string rootUri;
           
		public HudsonJobXmlFetcher ()
		{
			this.rootUri = ConfigurationManager.AppSettings["rootUri"];
		}
		
        public XDocument GetJobXmlFor(string jobName)
        {
            string jobUri = string.Format("{0}/job/{1}/api/xml", rootUri, jobName);

            return XDocument.Load(jobUri);
        }

	}
}

