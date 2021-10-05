using MyStore.PageInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.PageInterface
{
    public interface IWomenPage:IPage
    {
        bool Expand_FirstTreeNode();
        bool Expand_SecondTreeNode();
    }
}
