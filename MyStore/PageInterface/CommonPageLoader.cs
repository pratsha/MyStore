using System;
using System.Collections.Generic;


namespace MyStore.PageInterface
{
    public class CommonPageLoader : ITestPageFactory
    {
        protected Dictionary<Type, Lazy<object>> map = new Dictionary<Type, Lazy<object>>();
        public T GetPageFactory<T>()
        {
            if(this.map.ContainsKey(typeof(T)))
            {
                return (T)this.map[typeof(T)].Value;
            }

            throw new System.NotImplementedException();
        }
    }
}
