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
        IUserRepository UserRepository;
        IFriendRepository FriendRepository;

        public FriendService(IFriendRepository friendRepository, IUserRepository userRepository) 
        {
            UserRepository = userRepository;
            FriendRepository = friendRepository;
        }
        public IEnumerable<Friend> GetFriendsByIserId(int userId)
        {
            var friends = new List<Friend>();

            FriendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var userUserEntity = UserRepository.FindById(f.user_id);
                var friendUserEntity = UserRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, userUserEntity.id, friendUserEntity.email, friendUserEntity.firstname));
            });

            return friends;
        }

        public void CreateNewFriend(string friendEmail, int userId)
        {
            var findUserEntity = this.UserRepository.FindByEmail(friendEmail);
            if (findUserEntity == null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = userId,
                friend_id = findUserEntity.id
            };

            if (this.FriendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
