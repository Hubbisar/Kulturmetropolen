using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EventManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void submit_Click(object sender, EventArgs e)
    {
        CForm validateForm = new CForm();
        validateForm.validateEvent(title);
       
    }
}