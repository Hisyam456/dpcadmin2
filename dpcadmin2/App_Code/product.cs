using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for product
/// </summary>
public class product
{
	public product()
	{
		
	}

    public int pID { get; set; }
    public string pName { get; set; }
    public string pCat { get; set; }
    public string pStatus { get; set; }
    public string pDesc { get; set; }
    public string pNotes { get; set; }
    public string pImage { get; set; }
    public DateTime pCreatedOn { get; set; }
    public DateTime pEditedOn { get; set; }
    
}