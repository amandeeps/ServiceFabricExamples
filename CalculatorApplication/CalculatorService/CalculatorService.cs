using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;

using CalculatorInterface;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;

namespace CalculatorService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class CalculatorService : StatelessService, ICalculatorService
    {
        public Task<int> Add(int a, int b)
        {
            return Task.FromResult<int>(a + b);
        }

        public Task<int> Subtract(int a, int b)
        {
            return Task.FromResult<int>(a - b);
        }

        public CalculatorService(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(initParams =>
                    new FabricTransportServiceRemotingListener(initParams, this)),
            };
        }
    }
}
