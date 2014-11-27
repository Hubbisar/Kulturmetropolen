using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KMService
{
    [ServiceContract]
    public interface ISetData
    {
        [OperationContract]
        string createEvent(Profile id, string[] indata);

        [OperationContract]
        void updateEvent(int id, string[] indata);

        [OperationContract]
        void deleteEvent(int id);

        [OperationContract]
        void updateProfile(string id, string[] indata);

        [OperationContract]
        string createAdmin(Profile id, string[] indata);
    }


    // *********************************************  OBJECT  *************************************************
    [DataContract]
    public class Profile
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Authorization  { get; set;    }
    }

    [DataContract]
    public class AdminProfile
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Authorization  { get; set; }
    }

    [DataContract]
    public class EventModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Creator { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Date { get; set; }
        }
    
}
