using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CDisplayEvents
/// </summary>
public class CDisplayEvents
{
	public CDisplayEvents()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Hämta in ett EventModel objekt
    /// </summary>
    public MEvent displayOneEvent(int id) 
    {
        MEvent oneEvent = new MEvent();
        GetDataService.GetDataClient GetClient = new GetDataService.GetDataClient();
        GetDataService.EventModel getModel = new GetDataService.EventModel();

        getModel = GetClient.getSingle(id);
        oneEvent.id = getModel.Id;
        oneEvent.title = getModel.Title;
        oneEvent.creator = getModel.Creator;
        oneEvent.content = getModel.Content;
        oneEvent.category = getModel.Category;
        oneEvent.date = getModel.Date;
        oneEvent.location = getModel.Location;
        oneEvent.image = getModel.Image;
        oneEvent.city = getModel.City;
        return oneEvent;
    }

    public void displayMultiplyEvents() 
    {
    
    }
	
}