using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Build_Fetcher;

namespace Service_Factory.Registrys
{
    class BuildServiceRegistry : Registry
    {
        public BuildServiceRegistry()
        {
            For<IBuildMapper>().Use<BuildMapper>();
            For<IHudsonXmlFetcher>().Use<HudsonXmlFetcher>();
            For<IJobMapper>().Use<JobMapper>();
        }
    }
}
