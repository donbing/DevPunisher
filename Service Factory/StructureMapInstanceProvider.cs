using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;
using StructureMap;

namespace Service_Factory
{
    public class StructureMapInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;

        public StructureMapInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
			var foob = ObjectFactory.GetInstance(_serviceType);
            return foob;
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
