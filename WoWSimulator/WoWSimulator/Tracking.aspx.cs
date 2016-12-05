using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;

namespace WoWSimulator
{
    public partial class Tracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDatatables();
        }

        private void PopulateDatatables()
        {
            PopulateTrackingTable();
        }

        private void PopulateTrackingTable()
        {
            string sqlString = "select * from sys.tracking";
            DataTable CharacterInfoTable = new DataTable();
            CharacterInfoTable = SQL.RunSQL(sqlString);

            //Add extra rows to fill gaps
            AddDummyRows(CharacterInfoTable, 15);

            DataView view = CharacterInfoTable.DefaultView;
            TrackingListview.DataSource = view;
            TrackingListview.DataBind();
        }

        private void AddDummyRows(DataTable table, int minimumRows)
        {
            while (table.Rows.Count < minimumRows)
            {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
            }
        }
    }
}