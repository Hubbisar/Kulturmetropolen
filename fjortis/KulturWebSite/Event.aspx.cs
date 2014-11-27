using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Event : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        displayClick(9);
    }


    public void displayClick(int id)
    {
        CDisplayEvents getEvent = new CDisplayEvents();
        lblTitle.Text = getEvent.displayOneEvent(id).title;
        lblCategory.Text = getEvent.displayOneEvent(id).category;
        lblContent.Text = getEvent.displayOneEvent(id).content;
 
    }
}