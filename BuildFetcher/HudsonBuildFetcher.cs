﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Build_Fetcher.AutoGeneratedClasses;

namespace Build_Fetcher
{
    public interface IHudsonBuildFetcher
    {
        Build GetBuildFor(string jobName, int buildNumber);
    }

    public class HudsonBuildFetcher : XmlDeserialzer<Build>, IHudsonBuildFetcher
    {
        IHudsonBuildXmlFetcher xmlFetcher;

        public HudsonBuildFetcher(IHudsonBuildXmlFetcher xmlFetcher) {
            this.xmlFetcher = xmlFetcher;
        }

        public Build GetBuildFor(string jobName, int buildNumber)
        {
            var buildXml = xmlFetcher.GetBuildXmlFor(jobName, buildNumber);

            var build = DeserializeXml(buildXml);

            return build;
        }
    }
}
