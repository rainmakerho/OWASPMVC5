using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Products Order WebMethods 
/// </summary>
[WebService(Namespace = "http://www.rmtech.com/")]
[WebServiceBinding()]
[System.Web.Script.Services.ScriptService]
public class Products : System.Web.Services.WebService
{

    public Products()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string Order(string productOrder)
    {
        var xmlDoc = new XmlDocument();
        //.net 4.5.2 previous version
        //todo: Session-6.2 Fix XXE Product.cs WebService
        //xmlDoc.XmlResolver = null;
        xmlDoc.LoadXml(productOrder);
        //process order ....
        var email = xmlDoc.SelectSingleNode("//email").InnerText;
        var orderNumber = xmlDoc.SelectSingleNode("//order_id").InnerText;
        var result = string.Format("Thank you [{0}], . Your order [{1}] has been placed."
            , email, orderNumber);
        return result;
    }

}
