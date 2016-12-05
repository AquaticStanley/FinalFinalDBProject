using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace WoWSimulator
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void stepButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DataTable Battletags = GetBattletags();
            int willPlay = -1;

            //For each battletag
            for (int i = 0; i < Battletags.Rows.Count; i++)
            {
                string workingBattletag = Battletags.Rows[i].ItemArray[0].ToString();
                willPlay = -1;

                //Check if the player is already playing
                //string alreadyPlayingString = "select game_session.Battletag from game_session where game_session.Battletag = '" + workingBattletag + "' AND game_session.End_Time > NOW();";
                //if (SQL.RunSQL(alreadyPlayingString).Rows.Count == 0)
                //{
                    //For each hour
                    for (int k = 0; k < 24; i++)
                    {
                        //Get random number
                        int random = rnd.Next(1, 11);
                        if (random == 1)
                        {
                            willPlay = i;
                            break;
                        }
                    }

                    if (willPlay >= 0)
                    {
                        //Player is playing today, starting hour is contained in 'willPlay'

                        //Find out which character this player will play on
                        DataTable characterTable = new DataTable();
                        string charactersqlstring = "select sys.character.name, sys.character.Realm_Name from sys.character where sys.character.Battletag = '" + workingBattletag + "'";
                        characterTable = SQL.RunSQL(charactersqlstring);
                        int random = rnd.Next(0, characterTable.Rows.Count);

                        //If 0, the player will create a new character then play on a random character for 3 hours
                        if (random == 0)
                        {
                            CreateNewCharacter(workingBattletag);

                            Play(workingBattletag, characterTable.Rows[random].ItemArray[0].ToString(), characterTable.Rows[random].ItemArray[1].ToString(), willPlay);
                        }

                        //Else, the player will play on the character found in the character table
                        else
                        {
                            Play(workingBattletag, characterTable.Rows[random - 1].ItemArray[0].ToString(), characterTable.Rows[random].ItemArray[1].ToString(), willPlay);
                        }
                    }
                //}
                
            }

            //Simulate new players joining the game to start playing the following day
            int randomNum = rnd.Next(1, 10);
            for (int i = 0; i < randomNum; i++)
            {
                CreateNewAccount();
            }
        }

        //Creates a new account and one character
        private void CreateNewAccount()
        {
            string latestBattletagString = "select sys.game_account.Battletag from sys.game_account order by sys.game_account.Battletag desc";
            DataTable table = SQL.RunSQL(latestBattletagString);

            if(table.Rows.Count>0)
            {
                string latestBattletag = table.Rows[0].ItemArray[0].ToString().Substring(9, table.Rows[0].ItemArray[0].ToString().Length - 9);
                int battletagNum = Int32.Parse(latestBattletag);
                latestBattletag = "Battletag" + (battletagNum + 1).ToString();

                string sqlString = "insert into sys.game_account values('" + latestBattletag + "', 'Email1', 'TestName');";
                SQL.RunSQL(sqlString);
                CreateNewCharacter(latestBattletag);
            }
            else
            {
                //First account being created
                string latestBattletag = "Battletag1";
                string sqlString = "insert into sys.game_account values('" + latestBattletag + "', 'Email1', 'TestName');";
                SQL.RunSQL(sqlString);
                CreateNewCharacter(latestBattletag);
            }

        }

        private void Play(string workingBattletag, string characterName, string realmName, int startHour)
        {
            //Get latest day of anybody playing
            string dateSql = "select CAST(sys.game_session.End_Time AS DATE) from sys.game_session order by sys.game_session.End_Time desc limit 1;";
            DataTable dateTable = SQL.RunSQL(dateSql);

            if (dateTable.Rows.Count > 0)
            {
                string date = dateTable.Rows[0].ItemArray[0].ToString();

                ///
                ///
                ///
                ///
                ///
                ///
                ///
                DateTime startingDate = DateTime.Parse(date).AddDays(1);
                DateTime endingDate = startingDate.AddHours(3);

                string playSql = "insert into sys.game_session values('" + startingDate.ToString("yyyy-MM-dd H:mm:ss") + "', '" + endingDate.ToString("yyyy-MM-dd H:mm:ss") + "', '" + workingBattletag + "', '" + characterName + "', '" + realmName + "')";
                SQL.RunSQL(playSql);

                string levelUpSql = "Update sys.character SET sys.character.Level = sys.character.Level + 3 where sys.character.Battletag = '" + workingBattletag + "' AND sys.character.Realm_Name = '" + realmName + "' AND sys.character.Name='" + characterName + "'; Update sys.character Set sys.character.Level = CASE WHEN sys.character.Level > 60 then 60 else sys.character.Level END where sys.character.Battletag = '" + workingBattletag + "' AND sys.character.Realm_Name = '" + realmName + "' AND sys.character.Name='" + characterName + "';";
                SQL.RunSQL(levelUpSql);
            }
            else
            {
                string playSql = "insert into sys.game_session values('" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "', '" + DateTime.Now.AddHours(3).ToString("yyyy-MM-dd H:mm:ss") + "', '" + workingBattletag + "', '" + characterName + "', '" + realmName + "')";
                SQL.RunSQL(playSql);

                string levelUpSql = "Update sys.character SET sys.character.Level = sys.character.Level + 3 where sys.character.Battletag = '" + workingBattletag + "' AND sys.character.Realm_Name = '" + realmName + "' AND sys.character.Name='" + characterName + "'; Update sys.character Set sys.character.Level = CASE WHEN sys.character.Level > 60 then 60 else sys.character.Level END where sys.character.Battletag = '" + workingBattletag + "' AND sys.character.Realm_Name = '" + realmName + "' AND sys.character.Name='" + characterName + "';";
                SQL.RunSQL(levelUpSql);
            }
        }

        private string GetStartHour(int startHour)
        {
            if (startHour < 10)
            {
                return "0" + startHour.ToString();
            }
            else
            {
                return startHour.ToString();
            }
        }

        private void CreateNewCharacter(string workingBattletag)
        {
            DataTable realmCount = new DataTable();
            string sqlString = "select realm.name from sys.realm";
            realmCount = SQL.RunSQL(sqlString);

            for (int i = 0; i < realmCount.Rows.Count; i++)
            {
                string numCharactersString = "select count(sys.character.Name) from sys.character where sys.character.Battletag = '" + workingBattletag + "' AND sys.character.Realm_Name='" + realmCount.Rows[i].ItemArray[0].ToString() + "'";
                int numCharactersOnRealm = int.Parse(SQL.RunSQL(numCharactersString).Rows[0].ItemArray[0].ToString());
                if (numCharactersOnRealm < 6)
                {
                    //Create character on that realm

                    //What race?
                    Random rnd = new Random();
                    int rand = rnd.Next(0, 8);
                    string race;
                    string faction;
                    switch (rand)
                    {
                        case 0:
                            race = "Human";
                            break;
                        case 1:
                            race = "Night Elf";
                            break;
                        case 2:
                            race = "Dwarf";
                            break;
                        case 3:
                            race = "Gnome";
                            break;
                        case 4:
                            race = "Orc";
                            break;
                        case 5:
                            race = "Troll";
                            break;
                        case 6:
                            race = "Undead";
                            break;
                        case 7:
                            race = "Tauren";
                            break;
                        default:
                            race = "Tauren";
                            break;
                    }

                    if (rand < 4)
                    {
                        faction = "Alliance";
                    }
                    else
                    {
                        faction = "Horde";
                    }

                    //Get last character name on realm
                    string characterName;
                    string characterNameString = "select sys.character.Realm_Name, sys.character.Name from sys.character where sys.character.Realm_Name = '" + realmCount.Rows[i].ItemArray[0].ToString() + "' order by Creation_Date DESC limit 1";
                    DataTable lastCharacterTable = SQL.RunSQL(characterNameString);
                    if (lastCharacterTable.Rows.Count > 0)
                    {
                        //Get last number
                        string resultString = lastCharacterTable.Rows[0].ItemArray[1].ToString().Substring(9, lastCharacterTable.Rows[0].ItemArray[1].ToString().Length - 9);
                        int characterNum = Int32.Parse(resultString);
                        characterName = "Character" + (characterNum + 1).ToString();
                    }
                    else
                    {
                        //Fresh Realm; give the character a name of character1
                        characterName = "Character1";
                    }

                    string createCharacter = "insert into sys.character " +
                    "values('" + characterName + "', '" + workingBattletag + "', '" + realmCount.Rows[i].ItemArray[0].ToString() + "', '" + race + "', 1, '" + faction + "', Now())";
                    SQL.RunSQL(createCharacter);
                    break;
                }
            }
        }

        private int GetNumRealms()
        {
            string numRealmSql = "select count(sys.realm.Name) from sys.realm";
            return (int.Parse(SQL.RunSQL(numRealmSql).ToString()));
        }

        private DataTable GetBattletags()
        {
            string sqlString = "select Battletag from sys.game_account";
            return (SQL.RunSQL(sqlString));
        }
    }
}