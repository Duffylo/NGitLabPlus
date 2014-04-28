﻿using System;
using NGitLab.Models;
using NUnit.Framework;

namespace NGitLab.Tests
{
    public class UsersTests
    {
        private readonly IUserClient _users;

        public UsersTests()
        {
            _users = GitLabClient.Connect(Config.ServiceUrl, Config.Secret).Users;
        }

        [Test]
        public void Current()
        {
            var session = _users.Current;

            Assert.AreNotEqual(default(DateTime), session.CreatedAt);
            Assert.NotNull(session.Email);
            Assert.NotNull(session.Name);
            Assert.NotNull(session.PrivateToken);
            Assert.NotNull(session.PrivateToken);
        }

        [Test]
        public void GetUsers()
        {
            var users = _users.All;

            CollectionAssert.IsNotEmpty(users);
        }

        [Test]
        public void GetUser()
        {
            var user = _users[1];

            Assert.AreEqual("user", user.Username);
            Assert.AreEqual(true, user.CanCreateGroup);
        }
    }
}