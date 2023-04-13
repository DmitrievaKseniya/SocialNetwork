using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetwork.Tests
{
    public class FriendServiceTests
    {
        [Fact]
        public void CreateNewFriendReturnUserNotFoundExceptionWhenFriendNotFoundByEmail()
        {
            string testFriendEmail = "test@mail.ru";
            int testUserId = 1;

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(r => r.FindByEmail(testFriendEmail)).Returns(null as UserEntity);
            var mockFriendRepository = new Mock<IFriendRepository>();

            var friendServise = new FriendService(mockFriendRepository.Object, mockUserRepository.Object);

            Assert.Throws<UserNotFoundException>(() => friendServise.CreateNewFriend(testFriendEmail, testUserId));
        }
    }
}
