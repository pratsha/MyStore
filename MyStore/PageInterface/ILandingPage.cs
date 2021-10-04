using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.PageInterfaces
{
    interface ILandingPage:IPage
    {
        string ContactUs();
       
        string SearchWithEnterKey(string text);
        string SearchWithSearchButton(string text);

        bool HoverOnProduct(int index);

        bool LandingPage_AddToCart(int index);
        bool LandingPage_VerifySliderImages();

        bool VerifyHTMLDiv_Images();

    }
}
