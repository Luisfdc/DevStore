using System.Data.Entity;
using System.Web;

namespace DevStore.Infra.DataContexts
{
    public class ContextMenager
    {
        private const string ContextKey = "ContextMenager.Context";

        public DbContext Context
        {
            get
            {
                if(HttpContext.Current.Items[ContextKey] == null)
                {
                    HttpContext.Current.Items[ContextKey] = new DevStoreDataContexts();
                }

                return (DevStoreDataContexts)HttpContext.Current.Items[ContextKey];
            }
        }
    }
}
