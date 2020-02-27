using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    class DrugList
    {
        public List<Drug> drugs = new List<Drug>();
        private DBConnection db = new DBConnection();
        public void SqlAllDrugsToList()
        {
            MySqlCommand qry = ExecuteSql("SELECT * FROM drug");
            db.con.Open();
            MySqlDataReader reader = qry.ExecuteReader();

            while (reader.Read())
            {

                drugs.Add(new Drug
                {
                    id = (int)reader["id"],
                    name = reader["name"].ToString(),
                    description = reader["description"].ToString(),
                    type = reader["type"].ToString(),
                    dosage = reader["dosage"].ToString()
                });


            }
        }
        public MySqlCommand ExecuteSql(string sql)
        {

            MySqlCommand cmd = new MySqlCommand(sql, db.con);
            return cmd;
        }
    }

}
