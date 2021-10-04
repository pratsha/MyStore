using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.PageInterfaces
{
    public interface ISearch:IPage
    {
        int GetSearchResultCount();
        int GetSearchResults();
        int GetDisplyedProductCount();
        List<string> GetDisplayedProductNames();
        bool IsImageDisplayed();
        bool HoverOnProduct(int index);
        bool Search_AddToCart(int index);
    }
}
