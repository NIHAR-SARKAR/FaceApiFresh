using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FaceApiFresh.Detection;
using FaceApiFresh.GroupAndList;

namespace FaceApiFresh
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void FaceTest_Click(object sender, EventArgs e)
        {
            string mResponse = FaceIdentify.IdentifyTheFace().Result;
            tbResponse.Text+="\n"+ mResponse;
        }
    }
}