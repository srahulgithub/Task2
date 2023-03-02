using System.Collections.Generic;
using MvcMongoDB.Models;
using MongoDB.Driver;

namespace MvcMongoDB.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
    }

    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("test");
            _users = database.GetCollection<User>("users");
        }

        public void AddUser(User user)
        {
            _users.InsertOne(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users.Find(user => true).ToList();
        }
    }
}