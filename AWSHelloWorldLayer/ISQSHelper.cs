using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSHelloWorldLayer
{
    public interface ISQSHelper
    {
        Task<bool> SendMessageAsync(string message);
    }
}
