using System.Collections.Generic;
using System.Linq;
using ListviewProje.Models.Entity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ListviewProje.Models
{
    public class StudentDAO
    {
        private MongoClient mongoClient;
        private IMongoCollection<Student> studentCollection;

        public StudentDAO()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("mydata");
            studentCollection = database.GetCollection<Student>("students");
        }

        public List<Student> FindAll()
        {
            var students = studentCollection.AsQueryable().ToList();
            return students;
        }

        public List<Student> Find(int pageNumber, int limit, int pageSize)
        {
            var skips = limit* (pageNumber - 1);
            var students = studentCollection.Find(new BsonDocument()).
                Skip(skips).Limit(limit).ToList();
            return students;
        }

        public Student FindOne(string id)
        {
            var studentId = new ObjectId(id);
            var student = studentCollection.AsQueryable().SingleOrDefault(s => s.Id == studentId);
            return student;
        }

        public long Count()
        {
            long count = studentCollection.Count(new BsonDocument());
            return count;
        }

        public void Insert(Student student)
        {
            studentCollection.InsertOne(student);
        }


        public UpdateResult Update(Student student)
        {
            var updateResult = studentCollection.UpdateOne(Builders<Student>.Filter.Eq
                ("_id", ObjectId.Parse(student.Id.ToString())), Builders<Student>.Update
                .Set("name", student.Name)
                .Set("surname", student.Surname)
                );
            return updateResult;
        }

        public DeleteResult Delete(string id)
        {
            var deleteResult = studentCollection.DeleteOne(Builders<Student>.Filter.Eq("_id", ObjectId.Parse(id)));
            return deleteResult;
        }
    }
}
