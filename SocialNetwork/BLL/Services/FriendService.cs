using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService() 
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }
        public IEnumerable<Friend> GetFriendsBuIserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var userUserEntity = userRepository.FindById(f.user_id);
                var friendUserEntity = userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, userUserEntity.id, friendUserEntity.email, friendUserEntity.firstname));
            });

            return friends;
        }

        public void CreateNewFriend(FriendAddNewData friendAddNewData)
        {
            var findUserEntity = this.userRepository.FindByEmail(friendAddNewData.FriendEmail);
            if (findUserEntity == null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddNewData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
