using System.ServiceModel;
using Build_Fetcher;

namespace Build_Service
{
    [ServiceContract]
    public interface IBuildFetcherService
    {
        [OperationContract]
        Build GetCurrentBuild(string jobName);
        
        [OperationContract]
        Build GetBuild(string jobName, int buildnumber);
    }

    public class BuildService : IBuildFetcherService
    {
        private readonly IHudsonXmlFetcher xmlFetcher;
        private readonly IBuildMapper buildMapper;
        private readonly IJobMapper jobMapper;

        public BuildService() : this(new HudsonXmlFetcher(), new BuildMapper(), new JobMapper())
        {
        }

        public BuildService(IHudsonXmlFetcher xmlFetcher, IBuildMapper buildMapper, IJobMapper jobMapper)
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