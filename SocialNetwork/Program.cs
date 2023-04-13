using Microsoft.Extensions.Hosting;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    internal class Program
    {
        static MessageService messageService;
        static UserService userService;
        static FriendService friendService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static FriendAddNewView addNewFriendView;
        public static FriendsShowAllView friendsShowAllView;
        static void Main(string[] args)
        {
            IFriendRepository friendRepository = new FriendRepository();
            IUserRepository userRepository = new UserRepository();
            IMessageRepository messageRepository = new MessageRepository();

            userService = new UserService(userRepository, messageRepository);
            messageService = new MessageService(messageRepository, userRepository);
            friendService = new FriendService(friendRepository, userRepository);

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            addNewFriendView = new FriendAddNewView(userService, friendService);
            friendsShowAllView = new FriendsShowAllView(userService, friendService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}