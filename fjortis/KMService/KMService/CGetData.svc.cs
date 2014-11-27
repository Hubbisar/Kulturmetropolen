using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace KMService
{
    public class CGetData : IGetData, ISetData
    {
        //*********************************************  GET SINGLE  ********************************************
        public EventModel getSingle(int id)
        {
            EventModel newEvent = new EventModel();
            using (KMEntity dbcon = new KMEntity())
            {
                var oneEvent = (from e in dbcon.tblEvent
                               where e.Id == id
                               select e).FirstOrDefault(); //hämta ett objekt

                newEvent.Title = oneEvent.Title;
                newEvent.Content = oneEvent.Content;
                newEvent.Category = oneEvent.Category;
                newEvent.Date = oneEvent.Date.ToString();
                newEvent.Location = oneEvent.Location;
                newEvent.Image = oneEvent.Image;
                //TODO: Anropa CDisplayEvents och fyll alla fält på hemsidan
            }
            return newEvent;
        }



        //******************************************  GET CHOSEN CLICK  ****************************************

        public EventModel[] getChosenClick(string userThing) //den ska returnera en array av objekten "EventModel"
        {
            EventModel[] objectEvent = null;
            using (KMEntity dbcon = new KMEntity())
            {                
                if (userThing.StartsWith("cit")) //alla länkar som länkar till en stad ska börja med "c"
                {
                    //City
                   var chosenClick = from e in dbcon.tblEvent
                                  where e.City == userThing
                                  select e;

                    //skapar nytt array-objekt av ett event
                    //eftersom de tas emot i en array måste objekt-"mallen" också va en array
                    objectEvent = new EventModel[chosenClick.Count()]; 

                    for (int i = 0; i < chosenClick.Count(); i++) //lopa igenom arrayen och ta varje objekt där i
			        {       			 
                       foreach (var eo in chosenClick) //sätter in ny data på varje attribut i objektet
	                    {
                           objectEvent[i].Id = eo.Id;
                           objectEvent[i].Creator = eo.Creator;
                           objectEvent[i].Title = eo.Title;
                           objectEvent[i].Content = eo.Content;
                           objectEvent[i].Image = eo.Image;
                           objectEvent[i].Category = eo.Category;
                           objectEvent[i].City = eo.City;  
                           objectEvent[i].Location = eo.Location;
                           objectEvent[i].Date = eo.Date.ToString();
	                    }
                    }
                    return objectEvent;
                }
                   
                //Category
                else if (userThing.StartsWith("cat"))
                {
                    var chosenClick = from e in dbcon.tblEvent
                                  where e.Category == userThing
                                  select e;

                    objectEvent = new EventModel[chosenClick.Count()]; 

                    for (int i = 0; i < chosenClick.Count(); i++) 
			        {       			 
                       foreach (var eo in chosenClick) 
	                    {
                           objectEvent[i].Id = eo.Id;
                           objectEvent[i].Creator = eo.Creator;
                           objectEvent[i].Title = eo.Title;
                           objectEvent[i].Content = eo.Content;
                           objectEvent[i].Image = eo.Image;
                           objectEvent[i].Category = eo.Category;
                           objectEvent[i].City = eo.City;  
                           objectEvent[i].Location = eo.Location;
                           objectEvent[i].Date = eo.Date.ToString();
	                    }
                    }
                    return objectEvent;
                }

                //Date
                else if (userThing.StartsWith("dat"))
                {
                    var chosenClick = from e in dbcon.tblEvent
                                  where e.Category == userThing
                                  select e;

                    objectEvent = new EventModel[chosenClick.Count()]; 

                    for (int i = 0; i < chosenClick.Count(); i++) 
			        {       			 
                       foreach (var eo in chosenClick) 
	                    {
                           objectEvent[i].Id = eo.Id;
                           objectEvent[i].Creator = eo.Creator;
                           objectEvent[i].Title = eo.Title;
                           objectEvent[i].Content = eo.Content;
                           objectEvent[i].Image = eo.Image;
                           objectEvent[i].Category = eo.Category;
                           objectEvent[i].City = eo.City;  
                           objectEvent[i].Location = eo.Location;
                           objectEvent[i].Date = eo.Date.ToString();
	                    }
                    }
                    return objectEvent;
                }

                else
                {
                    return objectEvent;
                }
            }
        }

        //Avancerad sökning
        public void getFiltred()
        {
            
        }

        //Login
        public string getLogin(string username, string pass)
        {
            using (KMEntity dbcon = new KMEntity())
            {
                var login = (from li in dbcon.tblCreator
                                 where (li.Id == username && li.Password == pass)
                                 select li).FirstOrDefault();

                if (login != null)
                {
                    return "You are now successfully logged in!";
                }
                else
                {
                    return "Login denied.";
                }
            }
        }

        //Kommun
        public string getKommun(string link)
        {
            using (KMEntity dbcon = new KMEntity())
            {
                var kommun = (from e in dbcon.tblLink
                              where e.State == link
                              select e).FirstOrDefault();
                
                return kommun.Link;
            }
        }

        //Profil
        public Profile getProfile(string id)
        {

            Profile newProfile = new Profile();
            using(KMEntity dbcon = new KMEntity())
            {
                var oneProfile = (from e in dbcon.tblCreator
                                  where e.Id == id
                                  select e).FirstOrDefault();

                newProfile.Id = oneProfile.Id;
                newProfile.ContactPerson = oneProfile.ContactPerson;
                newProfile.Email = oneProfile.Email;
                newProfile.Authorization = oneProfile.Authorization;
                newProfile.Password = oneProfile.Password;
            }
            return newProfile;
        }


        //----------------------------------------------------------------------------------------------------
        //--------------------------------------- CSetData ---------------------------------------------------
        //----------------------------------------------------------------------------------------------------
        

        public string createEvent(Profile id, string[] indata)
        {
            //indata = new string[6]; //det är 5st fält som man fyller i för att skapa ett nytt event

            using (KMEntity dbcon = new KMEntity())
            {
                var profileInfo = (from e in dbcon.tblCreator
                                   where e.Id == id.Id
                                   select e).FirstOrDefault();
                    tblEvent newEvent = new tblEvent();
                    newEvent.Creator = profileInfo.Id; //ska sättas in automatiskt eftersom de är den inloggade som är skapare
                    newEvent.Title = indata[0];
                    newEvent.Content = indata[1];
                    newEvent.Category = indata[2];
                    newEvent.Date = indata[3];
                    newEvent.Location = indata[4];
                    newEvent.City = indata[5];
                    newEvent.Image = indata[6];
                    

                    dbcon.tblEvent.Add(newEvent);
                  
                    dbcon.SaveChanges();
                    return "Klart bitchess";
            }
        }

        //Uppdatera event
        public void updateEvent(int id, string[] indata) //tar in en array då de fälten ska (måste) fyllas i i rätt ordning. precis som när man skapar nytt event
        {
            CGetData getEvent = new CGetData(); //skapa nytt objekt av CGetData-klassen för att kunna använda funktionerna där i
            EventModel updateEvent = new EventModel(); //skapa nytt objekt av event 
            updateEvent = getEvent.getSingle(id); //ropa på en funktion i CGetData-klassen och värdet som den returnerar ska läggas direkt i det nya objektet

            indata = new string[5];

            using (KMEntity dbcon = new KMEntity())
            {
                var eventToUpdate = (from e in dbcon.tblEvent
                                     where e.Id == id
                                     select e).FirstOrDefault();

                eventToUpdate.Creator = updateEvent.Creator;
                eventToUpdate.Title = indata[0];
                eventToUpdate.Content = indata[1];
                eventToUpdate.Category = indata[2];
                eventToUpdate.Date = indata[3];
                eventToUpdate.Location = indata[4];
                eventToUpdate.Image = indata[5];
                dbcon.SaveChanges();
            }
        }

        //Ta bort event
        public void deleteEvent(int id)
        {
            EventModel ev = new EventModel();

            using (KMEntity dbcon = new KMEntity())
            {
                var deleteEvent = (from e in dbcon.tblEvent
                                   where e.Id == id
                                   select e).FirstOrDefault();

                dbcon.tblEvent.Remove(deleteEvent);
                dbcon.SaveChanges();
            }
        }

        //Uppdatera profil
        public void updateProfile(string id, string[] indata)
        {
            CGetData getUpdatedProfile = new CGetData();
            Profile updateProfile = new Profile();
            updateProfile = getUpdatedProfile.getProfile(id);

            indata = new string[3];

            using (KMEntity dbcon = new KMEntity())
            {
                var profileToUpdate = (from e in dbcon.tblCreator
                                       where e.Id == id
                                       select e).FirstOrDefault();

                profileToUpdate.Id = indata[0];
                profileToUpdate.ContactPerson = indata[1];
                profileToUpdate.Email = indata[2];
                profileToUpdate.Password = indata[3];
                profileToUpdate.Authorization = updateProfile.Authorization;
                dbcon.SaveChanges();
            }
        }

        //Skapa administratör
        public string createAdmin(Profile id, string[] indata)
        {
            tblCreator newAdminProfile = new tblCreator();
            indata = new string[4];

            using (KMEntity dbcon = new KMEntity())
            {
                if (id.Authorization == "2") //eftersom man redan är inloggad behöver man bara kolla så inloggningsuppgifterna är en "2" på authorization
                {
                    newAdminProfile.Id = indata[0];
                    newAdminProfile.ContactPerson = indata[1];
                    newAdminProfile.Email = indata[2];
                    newAdminProfile.Password = indata[3];
                    newAdminProfile.Authorization = indata[4];

                    dbcon.tblCreator.Add(newAdminProfile); //lägg till den nyskapta ojektet i databasen
                    dbcon.SaveChanges();
                    return "Profil sparad!";
                }

                else
                {
                    return "Misslyckades att skapa profil";
                }
            }
        }
    }
}
