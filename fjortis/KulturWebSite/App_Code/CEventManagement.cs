using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CEventManagement
/// </summary>
public class CEventManagement
{
	public CEventManagement()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   /// <summary>
   /// Funktionen hämtar och skapar ett nytt event, därför måste både getEvent-modellen och setEvent-modellen komma från samma webb-service. 
   /// Man ropar på samma webb-service men olika interface (get och set) och därmed arbetar med med två olika klienter
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    public string submitEvent_Click()
    {

        GetDataService.GetDataClient getData = new GetDataService.GetDataClient(); //skapa nytt objekt av klienten i get-interfacet
        GetDataService.Profile getProfile = new GetDataService.Profile(); //skapa nytt objekt av Profile-objektet
        GetDataService.SetDataClient setData = new GetDataService.SetDataClient(); //skapa nytt objekt av klienten i set-interfacet

        getProfile = getData.getProfile("5564479912"); //getData-klienten ropar på funktionen getProfile där id:t ska vara inparametern. värdet lagras direkt i det nya tomma objektet getProfile
        string[] inData = new string[7]; //skapa ny array då det tas in en array som inparameter i funktionen under..

        inData[0] = "hej";
        inData[1] = "detta är en text";
        inData[2] = "Festival";    
        inData[3] = "2015-04-22";
        inData[4] = "Stranden";
        inData[5] = "Torp";
        inData[6] = " ";
        return setData.createEvent(getProfile, inData); //setData-klienten ropar på funktionen createEvent 

    }

}