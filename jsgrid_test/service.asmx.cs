using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace jsgrid_test
{
    /// <summary>
    /// Summary description for service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class service : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetInvList()
        {
            List<ColumnsTable> oList = new List<ColumnsTable>();
            DataTable dtres = new DataTable();
            dtres = clsData.InvLocList_Get();
            foreach (DataRow dr in dtres.Rows)
            {
                oList.Add(new ColumnsTable
                {
                    colOrgJed = dr[0].ToString(),
                    colLocName = dr[1].ToString(),
                    colItmPrcs = dr[2].ToString(),
                    colItmTotl = dr[3].ToString(),
                    colPrcPrcs = dr[4].ToString(),
                    colLastScn = dr[5].ToString()
                });
            }

            fastJSON.JSON.Parameters.UseOptimizedDatasetSchema = true;
            fastJSON.JSON.Parameters.SerializeNullValues = true;
            fastJSON.JSON.Parameters.UseExtensions = true;

            return fastJSON.JSON.ToJSON(oList);
        }
        public class ColumnsTable
        {
            public string colOrgJed { get; set; }
            public string colLocName { get; set; }
            public string colItmPrcs { get; set; }
            public string colItmTotl { get; set; }
            public string colPrcPrcs { get; set; }
            public string colLastScn { get; set; }
        }

    }
}
