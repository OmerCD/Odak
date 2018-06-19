using System;
using System.Collections.Generic;
using System.Linq;
using ListviewProje.Models.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ListviewProje.Classes.CRUD
{
    public class CRUD<T> : IRepositoryMain<T> where T : DbObject, new()
    {
        private readonly IMongoDatabase _database;
        protected IMongoCollection<BsonDocument> Table;

        protected static BsonDocument GenerateDayCheckDocument(DateTime date)
        {
            var highDate = date.AddDays(1);
            highDate = new DateTime(highDate.Year, highDate.Month, highDate.Day, 0, 0, 0);
            return new BsonDocument
            {
                {
                    "$gte",
                    new DateTime(date.Year, date.Month, date.Day, 0, 0, 0)
                },

                {
                    "$lt", highDate
                }
            };
        }


        public CRUD(IMongoCollection<BsonDocument> tableInstance)
        {
            _database = DbFactory.Database;
            Table = tableInstance;
        }

        public CRUD()
        {
            var typeName = typeof(T).Name;
            var testProp = typeof(DbFactory).GetProperty(typeName);
            var factoryValue = testProp?.GetValue(null);

            Table = (IMongoCollection<BsonDocument>)factoryValue;
        }
        // ReSharper disable once UnusedMember.Global
        /// <summary>
        /// Returns the all names and ids if collection has a Name column.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> GetNameList()
        {
            var list = new Dictionary<string, string>();
            var nameList = new HashSet<string> { "ALL" };
            list.Add("ALL", "ALL"); // Tüm data için
            foreach (dynamic item in GetAll(new BsonDocument { { "IsDeleted", 0 } }))
            {
                string name = item.Name ?? "";
                if (nameList.Contains(name) == false)
                {
                    list.Add(item._id, name);
                    nameList.Add(name);
                }

            }

            return list;
        }


        public virtual bool Upsert(T entity)
        {
            try
            {
                var filter = new BsonDocument { { "_id", entity._id } };
                var updateOption = new UpdateOptions {IsUpsert = true};
                Table.ReplaceOne(filter, entity.ToBsonDocument(), updateOption);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public virtual bool NameCheck(string name)
        {
            try
            {
                var filter = new BsonDocument { { "Name", name } };
                var cursor = Table.FindSync(filter);
                cursor.MoveNext();
                return cursor.Current.Any();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return true;
            }
        }
        public virtual bool Delete(string id)
        {
            try
            {
                var filter = new BsonDocument { { "_id", id } };
                var builder = Builders<BsonDocument>.Update.Set("IsDeleted", 1);

                Table.UpdateOne(filter, builder);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public virtual List<T> GetAll()
        {
            if (Table != null)
            {


                var filter = new BsonDocument {{"IsDeleted", 0}};
                var results = new List<T>();
                var found = Table.FindSync(filter);
                while (found.MoveNext())
                {
                    var batch = found.Current;
                    results.AddRange(batch.Select(item => BsonSerializer.Deserialize<T>(item)));
                }
                return results;
            }
            return new List<T>();
        }
        /// <summary>
        /// Removes all content from collection.
        /// </summary>
        public void ClearColection()
        {
            _database.DropCollection(typeof(T).Name);
        }
        /// <summary>
        /// Returns number of rows from collection which is not marked as deleted.
        /// </summary>
        public long Count => Table.Count(new BsonDocument { { "IsDeleted", 0 } });
        /// <summary>
        /// Returns number of rows from collection.
        /// </summary>
        public long CountAll => Table.Count(new BsonDocument());
        /// <summary>
        /// Returns all data based on given filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual List<T> GetAll(BsonDocument filter)
        {
            try
            {
                if (filter == null) filter = new BsonDocument { { "IsDeleted", 0 } };
                var results = new List<T>();
                var found = Table.FindSync(filter);
                while (found.MoveNext())
                {
                    var batch = found.Current;
                    results.AddRange(batch.Select(item => BsonSerializer.Deserialize<T>(item)));
                }
                return results;
            }
            catch (Exception ex)
            {

                return new List<T>();
            }

        }

        #region GetOne

        public virtual T GetOne(string id)
        {
            if (id=="ALL")
            {
                return new T {_id = null};
            }
                var filter = new BsonDocument { { "_id", id }, { "IsDeleted", 0 } };
                var cursor = Table.FindSync(filter);
                cursor.MoveNext();
                var batch = cursor.Current;
                return BsonSerializer.Deserialize<T>(batch.FirstOrDefault());


        }

        public List<T> Search(string column, string value)
        {

            BsonDocument GetFilter()
            {
                return new BsonDocument { { column, new BsonDocument { { "$regex", "(?i)"+value+"(?-i)" } } } };
            }

            var cursor = Table.FindSync(GetFilter());
            cursor.MoveNext();
            var batch = cursor.Current;
            List<T> results = new List<T>();
            results.AddRange(batch.Select(item => BsonSerializer.Deserialize<T>(item)));
            return results;
        }

        public List<T> MultipleColumnSearch(string value, IEnumerable<string> columns)
        {
            if (!columns.Any())
            {
                return null;
            }
            BsonDocument GetFilter(string column)
            {
                return new BsonDocument { { column, new BsonDocument { { "$regex", "(?i)" + value + "(?-i)" } } } };
            }
            var filterArray = new BsonArray();
            foreach (var column in columns)
            {
                filterArray.Add(GetFilter(column));
            }
            var bsonOr = new BsonDocument{
            {
                "$or",
                filterArray
            }};

            //var bsonResult = new BsonDocument{{"$match",bsonOr}};
            var cursor = Table.FindSync(bsonOr);
            cursor.MoveNext();
            var batch = cursor.Current;
            List<T> results = new List<T>();
            results.AddRange(batch.Select(item => BsonSerializer.Deserialize<T>(item)));
            return results;
        }

        public virtual T GetOne(string columnName, string value)
        {
            try
            {
                var filter = new BsonDocument { { columnName, value } };
                var cursor = Table.FindSync(filter);
                cursor.MoveNext();
                var batch = cursor.Current;
                var enumerable = batch as BsonDocument[] ?? batch.ToArray();
                if (!enumerable.Any())
                {
                    return new T { _id = null };
                }
                return BsonSerializer.Deserialize<T>(enumerable.FirstOrDefault());

            }
            catch (Exception)
            {

                return new T { _id = null };
            }

        }
        public virtual T GetOne(string columnName, int value)
        {
            try
            {
                var filter = new BsonDocument { { columnName, value } };
                var cursor = Table.FindSync(filter);
                cursor.MoveNext();
                var batch = cursor.Current;
                return BsonSerializer.Deserialize<T>(batch.FirstOrDefault());

            }
            catch (Exception)
            {

                return new T { _id = null };
            }

        }
        public virtual T GetOne(string columnName, bool value)
        {
            try
            {
                var filter = new BsonDocument { { columnName, value } };
                var cursor = Table.FindSync(filter);
                cursor.MoveNext();
                var batch = cursor.Current;
                return BsonSerializer.Deserialize<T>(batch.FirstOrDefault());

            }
            catch (Exception)
            {

                return new T { _id = null };
            }

        }

        #endregion

        /// <summary>
        /// Marks rows as undeleted if consistent with the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<T> BringBack(BsonDocument filter)
        {
            try
            {
                var results = new List<T>();
                using (var cursor = Table.FindSync(filter))
                {
                    var x = cursor.ToList();
                    results.AddRange(x.Select(item => BsonSerializer.Deserialize<T>(item)));
                }
                return results;
            }
            catch (Exception)
            {

                return new List<T>();
            }
        }

        public virtual bool Insert(T entity)
        {
                Table.InsertOne(entity.ToBsonDocument());
                return true;
        }
        public virtual bool InsertMany(params T[] entities)
        {
            try
            {
                Table.InsertMany(entities.Select(x => x.ToBsonDocument()));
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        /// <summary>
        /// Updates a choosen entity. Note that it can also change _id property of entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Update(string id, T entity)
        {
            try
            {
                var filter = new BsonDocument { { "_id", id } };
                var bsonEntity = entity.ToBsonDocument();
                var update = new BsonDocument { { "$set", bsonEntity } };
                Table.UpdateOne(filter, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
