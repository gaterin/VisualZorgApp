using System;
using MySql.Data.MySqlClient;

namespace VisualZorgApp.DataModels
{
    // DataModel base class
    // Uses SQL
    // initializes database class
    // Parent class for all Datamodels
    // Reader executes are defined in the child classes 
    public class DataModel
    {
        private DBConnection db = new DBConnection();
        private string errorMsg;

        public void ExecNonQry(MySqlCommand qry)
        {
            try
            {
                db.con.Open();
                qry.ExecuteNonQuery();
                db.con.Close();
            }
            catch (Exception e)
            {
                errorMsg = e.Message.ToString();
            }
        }

        public string GetErrorMsg()
        {
            return errorMsg;
        }
        public void SetErrorMsg(string errorMsg)
        {
            this.errorMsg = errorMsg;
        }

        public DBConnection GetDBConnection()
        {
            return db;
        }

    }
}
