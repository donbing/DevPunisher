using System;
using System.ServiceModel;
using StructureMap;

namespace Service_Factory
{
    public class StructureMapServiceHost : ServiceHost
    {
        private readonly IContainer container;

        public StructureMapServiceHost()
        {
        }

        public StructureMapServiceHost(IContainer container, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.container = container;
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new StructureMapServiceBehavior(container));
            base.OnOpening();
        }
    }
}
