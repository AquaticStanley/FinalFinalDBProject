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
    public partial class RealmInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDataTables();
        }

        private void PopulateDataTables()
        {
            PopulateRealmCountLabel();
            PopulateRealmPopulationsListview();
        }

        private void PopulateRealmCountLabel()
        {
            DataTable realmCount = new DataTable();
            string sqlString = "select count(realm.Name) from sys.realm";
            realmCount = SQL.RunSQL(sqlString);
            RealmCountLabel.Text = "Active Realms: " + realmCount.Rows[0].ItemArray[0].ToString();
        }

        private string GetRealmCount()
        {
            return "59";
        }

        private void PopulateRealmPopulationsListview()
        {
            DataTable RealmPopulationsTable = new DataTable();
            string sqlString = "Select sys.realm.Name as Realm, sys.realm.Region, sys.realm.Type, (select count(sys.character.Name) AS Alliance FROM sys.character WHERE sys.character.Realm_Name = sys.realm.Name AND (sys.character.race = 'Night Elf' OR sys.character.race = 'Human' OR sys.character.race = 'Dwarf' OR sys.character.race = 'Gnome')) as Alliance, (select count(sys.character.Name) AS Horde FROM sys.character WHERE sys.character.Realm_Name = sys.realm.Name AND (sys.character.race = 'Orc' OR sys.character.race = 'Troll' OR sys.character.race = 'Undead' OR sys.character.race = 'Tauren')) as Horde from sys.realm; ";

            RealmPopulationsTable = SQL.RunSQL(sqlString);

            //Append to each entry the percentage of players on each faction
            //for (int i = 0; i < RealmPopulationsTable.Rows.Count; i++)
            //{
            //    float numAlliance = float.Parse(RealmPopulationsTable.Rows[i].ItemArray[3].ToString());
            //    float numHorde = float.Parse(RealmPopulationsTable.Rows[i].ItemArray[4].ToString());

            //    RealmPopulationsTable.Rows[i].SetField("Alliance", RealmPopulationsTable.Rows[i].ItemArray[1].ToString() + " (" + (numAlliance / (numAlliance + numHorde) * 100).ToString() + "%)");
            //    RealmPopulationsTable.Rows[i].SetField("Horde", RealmPopulationsTable.Rows[i].ItemArray[2].ToString() + " (" + (numHorde / (numAlliance + numHorde) * 100).ToString() + "%)");
            //}

            //Add extra rows to fill gaps
            AddDummyRows(RealmPopulationsTable, 15);

            DataView view = RealmPopulationsTable.DefaultView;
            RealmLookupListview.DataSource = view;
            RealmLookupListview.DataBind();
        }

        private void AddDummyRows(DataTable table, int minimumRows)
        {
            while (table.Rows.Count < minimumRows)
            {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}