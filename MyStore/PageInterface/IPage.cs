using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.PageInterfaces
{
    public interface IPage
    {
        bool LoadPage();
        string GetTitle();
        string NavigateBack();
        IWebElement GetHeaderContainer();
        IWebElement GetColumnContainer();
        IWebElement GetFooterContainer();
        IWebElement NavigationPipe();
        bool NavigateHome();
        bool MoveToWomenNav();
        bool MoveToDressesNav();
        bool MoveToTShirtNav();
        IWebElement GetDialogLayerCart_ContinueShopping();
        IWebElement GetDialogLayerCart();
        IWebElement GetCenterColumn();
        bool ContinueShopping();
        string SingIn();

        IWebElement GetCart();

        bool Hover_Cart();

        string Navigate_WomenPage();
        string Navigate_DressesPage();
        string Navigate_TShirtPage();

    }
}
