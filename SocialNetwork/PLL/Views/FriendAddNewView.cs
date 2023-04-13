using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddNewView
    {
        UserService userService;
        FriendService friendService;

        public FriendAddNewView(UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        { 
            Console.Write("Введите емайл нового друга:");
            string friendEmail = Console.ReadLine();

            try
            {
                friendService.CreateNewFriend(friendEmail, user.Id);
                SuccessMessage.Show("Теперь вы друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким емайл не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении нового друга!");
            }
            
        }
    }
}
