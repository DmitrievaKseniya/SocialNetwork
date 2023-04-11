using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsShowAllView
    {
        UserService UserService;
        FriendService friendService;

        public FriendsShowAllView(UserService userService, FriendService friendService)
        {
            this.UserService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            Console.WriteLine("ВАШИ ДРУЗЬЯ");

            IEnumerable<Friend> friends = friendService.GetFriendsBuIserId(user.Id);

            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас пока нет друзей");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine($"{friend.NameFriend} ({friend.FriendEmail})");
            });
            Console.WriteLine();
        }
    }
}
