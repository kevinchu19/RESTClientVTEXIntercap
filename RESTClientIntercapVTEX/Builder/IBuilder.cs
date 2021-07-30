using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Builder
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
