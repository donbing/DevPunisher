using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;
using StructureMap;
using Service_Factory.Registrys;

namespace Service_Factory
{
    public class StructureMapServiceHostFactory : ServiceHostFactory
    {
        public StructureMapServiceHostFactory()
        {
            ObjectFactory.Initialize(factory =>{
                factory.AddRegistry(new BuildServiceRegistry());
                factory.AddRegistry(new MissileLauncherRegistry());
            });
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new StructureMapServiceHost(serviceType, baseAddresses);
        }
    }
}
