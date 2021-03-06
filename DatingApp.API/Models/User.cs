using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DatingApp.API.Models
{   
    // TODO: add Country property
    public class User
    {
        public int Id {get; set;}
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Intrests { get; set; }

        public string City { get; set; }

        // this defines one-to-many relationship
        public ICollection<Photo> Photos { get; set; }

        public User(){
            Photos = new Collection<Photo>();
        }

        public ICollection<Like> Likers { get; set; }

        public ICollection<Like> Likees { get; set; }

        public ICollection<Message> MessagesSent { get; set; }

        public ICollection<Message> MessagesReceived { get; set; }
    }
}