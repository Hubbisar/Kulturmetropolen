using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KMService
{
    public class CSetData : ISetData
    {
        //Skapa event
        public string createEvent(Profile id, string[] indata)
        {
            indata = new string[5]; //det är 5st fält som man fyller i för att skapa ett nytt event

            using (KMEntity dbcon = new KMEntity())
            {                
               var profileInfo = (from e in dbcon.tblCreator
                              where e.Id == id.Id
                              select e).FirstOrDefault();

                if (profileInfo != null)
                {
                    tblEvent newEvent = new tblEvent(); 
                    newEvent.Creator = profileInfo.Id; //ska sättas in automatiskt eftersom de är den inloggade som är skapare
                    newEvent.Title = indata[0];
                    newEvent.Content = indata[1];
                    newEvent.Category = indata[2];
                    newEvent.Date = indata[3];
                    newEvent.Location = indata[4];
                    newEvent.Image = indata[5];

                    dbcon.tblEvent.Add(newEvent);
                    dbcon.SaveChanges();
                    return "Sparad!";
                }

                else
                {
                    return "Misslyckades att skapa event.";
                }
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

            using(KMEntity dbcon = new KMEntity())
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
