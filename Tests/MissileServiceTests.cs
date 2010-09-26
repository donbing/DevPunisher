using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissileLauncher.Interfaces;
using Rhino.Mocks;
using StructureMap;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Rhino.Mocks.Constraints;
using System.Xml;
using System.Diagnostics;
using MissileLauncher.Service;
using MissileLauncher.Service.ServiceFactory;

namespace Tests
{
    [TestClass]
    public class WhenMissileLauncherServiceRecievesCommands
    {
        protected ServiceHost svcHost;
        protected Binding endpointBinding = new NetTcpBinding();
        protected const string uri = "net.tcp://localhost:8000";

        [TestInitialize]
        public void PerTestSetup()
        {
            svcHost = new StructureMapServiceHost(typeof(MissileLauncherService), new Uri(uri));
            svcHost.AddServiceEndpoint(typeof(IMissileLauncherService), endpointBinding, uri);
            svcHost.Open();
        }

        [TestCleanup]
        public void PerTestCleanup()
        {
            svcHost.Close();
        }

        [TestMethod]
        public void Teasfast()
        {
            AssertCommandCausesAction(new FireCommand(), lnc => lnc.Fire());
            AssertCommandCausesAction(new StopCommand(), lnc => lnc.Stop());
            AssertCommandCausesAction(new LeftCommand(), lnc => lnc.Left());
            AssertCommandCausesAction(new RightCommand(), lnc => lnc.Right());
            AssertCommandCausesAction(new UpCommand(), lnc => lnc.Up());
            AssertCommandCausesAction(new DownCommand(), lnc => lnc.Down());
        }

        private void AssertCommandCausesAction(MissileLauncherCommand command, Action<IMissileLauncher> launcherMethod)
        {
            ObjectFactory.Inject(MockRepository.GenerateMock<IMissileLauncher>());

            using (var factory = new ChannelFactory<IMissileLauncherService>(endpointBinding, new EndpointAddress(uri)))
            {
                IMissileLauncherService svcClient = factory.CreateChannel();
                svcClient.DoCommand(command);
            }

            ObjectFactory.GetInstance<IMissileLauncher>().AssertWasCalled(launcherMethod);
        }
    }
}

