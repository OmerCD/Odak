using System.Collections.Generic;
using System.Linq;
using ListviewProje.Models.Entity;
using MongoDB.Bson;

namespace ListviewProje.Classes.CRUD
{
    public class CompanyCRUD : CRUD<Company>
    {
        public CompanyCRUD() : base(DbFactory.Company)
        {

        }

        public IEnumerable<PaymentDocument> GetLastPayments()
        {
            var filter = new BsonDocument { {"",""}, new BsonDocument{{ "LastPaymentDocument", true },{"_id",false} } };
            var cursor = Table.FindSync<PaymentDocument>(filter);
            while (cursor.MoveNext())
            {
                yield return cursor.Current.FirstOrDefault();
            }
        }
    }
}
