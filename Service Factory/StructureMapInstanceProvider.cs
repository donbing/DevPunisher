using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;
using StructureMap;

namespace Service_Factory
{
    public class StructureMapInstanceProvider : IInstanceProvider
    {
        private readonly IContainer container;
        private readonly Type serviceType;

        public StructureMapInstanceProvider(IContainer container, Type serviceType)
        {
            this.container = container;
            this.serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
			var foob = container.GetInstance(serviceType);
            return foob;
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
