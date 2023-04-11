using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public int User_id { get; }
        public string FriendEmail { get; }
        public string NameFriend { get;  }

        public Friend(int id, int user_id, string friendEmail, string nameFriend)
        {
            this.Id = id;
            this.User_id = user_id;
            this.FriendEmail = friendEmail;
            this.NameFriend = nameFriend;
        }

        
    }
}
