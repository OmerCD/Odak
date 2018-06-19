using System.Linq;
using ListviewProje.Models.Entity;
using MongoDB.Bson;

namespace ListviewProje.Classes.CRUD
{
    public class PaymentDocumentCRUD : CRUD<PaymentDocument>
    {
        public override bool Insert(PaymentDocument entity)
        {
#if DEBUG
            if (entity.Firm._id==null)
            {
                entity.Firm._id = "0";
            }
#endif
            BsonDocument filter = new BsonDocument { { "DocumentDate", entity.DocumentDate }, { "DocumentNo", entity.DocumentNo }, { "Firm._id", entity.Firm._id }, { "AccountCode", entity.AccountCode } };
            var cursor = Table.FindSync<BsonDocument>(filter);
            cursor.MoveNext();
            var batch = cursor.Current;
            if (!batch.Any())
            {
                Table.InsertOne(entity.ToBsonDocument());
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
