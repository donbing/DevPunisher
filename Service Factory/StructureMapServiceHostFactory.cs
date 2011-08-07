using System;
using System.ServiceModel.Activation;
using System.ServiceModel;
using StructureMap;

namespace Service_Factory
{
    public class StructureMapServiceHostFactory : ServiceHostFactoryBase
    {
        readonly IContainer container;

        public StructureMapServiceHostFactory()
        {
            container = new Container(factory => 
                factory.Scan(x => {
                    x.AssembliesFromApplicationBaseDirectory();
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                })
            );
        }

        protected ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new StructureMapServiceHost(container, serviceType, baseAddresses);
        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var t = Type.GetType(constructorString, true);
            
            return CreateServiceHost(t, baseAddresses);
        }
    }
}
