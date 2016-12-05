using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;

namespace WoWSimulator
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDatatables();
        }

        private void PopulateDatatables()
        {
            PopulatePlayerCountLabel();
            PopulatePlayerOnlineStatusListview();
            PopulateRealmPopulationsListview();
        }

        private void PopulatePlayerCountLabel()
        {
            ActivePlayerCountLabel.Text = "Active Player Count: " + GetPlayerCount();
        }

        private string GetPlayerCount()
        {
            string sqlString = "select count(sys.game_account.Battletag) from sys.game_account";
            return (SQL.RunSQL(sqlString).Rows[0].ItemArray[0].ToString());

            //Populating labels is a little different. You'll want to do it as follows.
            //string sqlString = "Select blah blah from blah blah";
            //DataTable PlayerCountTable = SQL.RunSQL(sqlString);
            //ActivePlayerCountLabel.Text = PlayerCountTable.Rows[0].ItemArray[0].ToString();
        }

        private void PopulateRealmPopulationsListview()
        {
            DataTable RealmPopulationTable = new DataTable();
            string sqlString = "select sys.realm.Name as Realm, (select count(DISTINCT sys.character.Battletag) from sys.character where sys.character.Realm_Name = sys.realm.Name) as PlayerCount from sys.realm; ";

            RealmPopulationTable = SQL.RunSQL(sqlString);

            //Add extra rows to fill gaps
            AddDummyRows(RealmPopulationTable, 15);

            DataView view = RealmPopulationTable.DefaultView;
            RealmLookupListview.DataSource = view;
            RealmLookupListview.DataBind();
        }

        private void PopulatePlayerOnlineStatusListview()
        {
            string sqlString = "select sys.game_account.Battletag from sys.game_account";
            DataTable OnlinePlayerTable = new DataTable();
            OnlinePlayerTable = SQL.RunSQL(sqlString);

            //Add extra rows to fill gaps
            AddDummyRows(OnlinePlayerTable, 10);

            DataView view = OnlinePlayerTable.DefaultView;
            BattletagLookupListview.DataSource = view;
            BattletagLookupListview.DataBind();
        }

        private void AddDummyRows(DataTable table, int minimumRows)
        {
            while (table.Rows.Count < minimumRows)
            {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
            }
        }

        protected void CharacterInfoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CharacterInfo.aspx");
        }

        protected void searchButton2_Click(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}