using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jsgrid_test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [System.Web.Services.WebMethod]
        public static string GetInvList() {
            List<ColumnsTable> oList = new List<ColumnsTable>();
            DataTable dtres = new DataTable();
            dtres = clsData.InvLocList_Get();
            if (dtres == null) return "Nema podataka!";
            foreach (DataRow dr in dtres.Rows) {
                oList.Add(new ColumnsTable {
                    colDokument = dr[0].ToString(),
                    colLocName = dr[1].ToString(),
                    colItmPrcs = dr[2].ToString(),
                    colItmTotl = dr[3].ToString(),
                    colPrcPrcs = dr[4].ToString(),
                    colFirstScn = dr[5].ToString(),
                    colLastScn = dr[6].ToString()
                });
            }

            fastJSON.JSON.Parameters.UseOptimizedDatasetSchema = true;
            fastJSON.JSON.Parameters.SerializeNullValues = true;
            fastJSON.JSON.Parameters.UseExtensions = true;

            return fastJSON.JSON.ToJSON(oList);
        }

        public class ColumnsTable {
            public string colDokument { get; set; }
            public string colLocName { get; set; }
            public string colItmPrcs { get; set; }
            public string colItmTotl { get; set; }
            public string colPrcPrcs { get; set; }
            public string colFirstScn { get; set; }
            public string colLastScn { get; set; }
        }
    }
}