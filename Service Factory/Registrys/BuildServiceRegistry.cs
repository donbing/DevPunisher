﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Build_Fetcher;
using Build_Fetcher.AutoGeneratedClasses;

namespace Service_Factory.Registrys
{
    class BuildServiceRegistry : Registry
    {
        public BuildServiceRegistry()
        {
            For<IHudsonJobXmlFetcher>().Use<HudsonXmlFetcher>();
            For<IHudsonJobFetcher>().Use<HudsonJobFetcher>();
            For<IHudsonBuildFetcher>().Use<HudsonBuildFetcher>();
        }
    }
}
