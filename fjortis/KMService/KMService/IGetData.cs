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
    public interface IGetData
    {
        [OperationContract]
        EventModel getSingle(int id);

        [OperationContract]
        EventModel[] getChosenClick(string userThing);

        [OperationContract]
        void getFiltred();

        [OperationContract]
        string getLogin(string username, string pass);

        [OperationContract]
        string getKommun(string link);

        [OperationContract]
        Profile getProfile(string id);
    }
}
