using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.PageInterface
{
    public interface ITestPageFactory
    {
        X GetPageFactory<X>();
    }
}
