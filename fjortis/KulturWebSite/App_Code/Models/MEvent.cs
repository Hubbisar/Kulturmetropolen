using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MEvent
/// </summary>
public class MEvent
{
	public MEvent()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int id { get; set; }
    public string creator {get; set;}
    public string title {get; set;}
    public string content {get; set;}
    public string category {get; set;}
    public string date {get; set;}
    public string image {get; set;}
    public string city {get; set;}
    public string location { get; set; }
}