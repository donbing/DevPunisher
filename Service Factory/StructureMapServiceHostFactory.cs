using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;
using StructureMap;

namespace Service_Factory
{
    public class StructureMapServiceHostFactory : ServiceHostFactory
    {
        public StructureMapServiceHostFactory()
        {
            ObjectFactory.Initialize(factory =>{
				factory.Scan(x => {
					x.AssembliesFromApplicationBaseDirectory();
					x.TheCallingAssembly();
					x.WithDefaultConventions();
				
				});
			});
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new StructureMapServiceHost(serviceType, baseAddresses);
        }
    }
}
