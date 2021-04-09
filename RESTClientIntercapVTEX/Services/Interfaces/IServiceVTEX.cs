using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Services.Interfaces
{
    public interface IServiceVTEX
    {
        Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken);
    }
}
