using System.Data.Entity;
using System.Linq;
using DevStore.Domain;
using DevStore.Infra.DataContexts;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private DevStoreDataContexts db;

        public Service1()
        {
            db = new DevStoreDataContexts();
        }

        public void Details(int id)
        {
            using (db)
            {
                Product products = db.Product.Single(x => x.Id == id);
                products.Title = "Mudei";
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /*public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/
    }
}
