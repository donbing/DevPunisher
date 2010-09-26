using System.ServiceModel;
using BuildFetcher;

namespace BuildFetcherService
{
    [ServiceContract]
    public interface IBuildFetcherService
    {
        [OperationContract]
        Build GetCurrentBuild(string jobName);
        
        [OperationContract]
        Build GetBuild(string jobName, int buildnumber);
    }

    public class HudsonBuildFetcher : IBuildFetcherService
    {
        private readonly IHudsonXmlFetcher xmlFetcher;
        private readonly IBuildMapper buildMapper;
        private readonly IJobMapper jobMapper;

        public HudsonBuildFetcher() : this(new HudsonXmlFetcher(), new BuildMapper(), new JobMapper())
        {
        }

        public HudsonBuildFetcher(IHudsonXmlFetcher xmlFetcher, IBuildMapper buildMapper, IJobMapper jobMapper)
        {
            this.xmlFetcher = xmlFetcher;
            this.buildMapper = buildMapper;
            this.jobMapper = jobMapper;
        }

        public Build GetCurrentBuild(string jobName)
        {
            var jobXml = xmlFetcher.GetJobXmlFor(jobName);

            var job = jobMapper.CreateJobFrom(jobXml);

            return GetBuild(jobName, job.LastBuildNumber);
        }

        public Build GetBuild(string jobName, int buildnumber)
        {
            var buildXml = xmlFetcher.GetBuildXmlFor(jobName, buildnumber);

            var build = buildMapper.CreateBuildFrom(buildXml);

            return build;
        }
    }
}