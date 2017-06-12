using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hehao.DesignPattern.Foundation.Context
{
    public class GenericContext
    {
        class NameBasedDictionary : Dictionary<string, object>
        { }
        [ThreadStatic]
        private static NameBasedDictionary threadCache;

        private static readonly bool isWeb = CheckWeatherIsWeb();

        private const string ContextKey = "Hehao.DesignPattern.Foundation.Context.web";


        public GenericContext()
        {
            if (isWeb && (HttpContext.Current.Items[ContextKey] == null))
            {
                HttpContext.Current.Items[ContextKey] = new NameBasedDictionary();
            }
        }

        public object this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return null;
                NameBasedDictionary cache = GetCache();
                if (cache.Count <= 0) return null;
                object result;
                if (cache.TryGetValue(name, out result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (string.IsNullOrEmpty(name)) return;
                NameBasedDictionary cache = GetCache();
                object temp;
                if (cache.TryGetValue(name, out temp))
                {
                    cache[name] = value;
                }
                else
                {
                    cache.Add(name, value);
                }
            }
        }

        private static NameBasedDictionary GetCache()
        {
            NameBasedDictionary cache;
            if (isWeb)
            {
                cache = (NameBasedDictionary)HttpContext.Current.Items[ContextKey];
            }
            else
            {
                cache = threadCache;
            }

            if (cache == null)
            {
                cache = new NameBasedDictionary();
            }
            if (isWeb)
            {
                HttpContext.Current.Items[ContextKey] = cache;
            }
            else
            {
                threadCache = cache;
            }

            return cache;
        }

        private static bool CheckWeatherIsWeb()
        {
            bool result = false;
            AppDomain domain = AppDomain.CurrentDomain;
            try
            {
                if (domain.ShadowCopyFiles)
                    result = (HttpContext.Current.GetType() != null);
            }
            catch (Exception)
            {

            }
            return result;
        }

    }
}
