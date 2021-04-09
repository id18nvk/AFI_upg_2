using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrenumerantSystem.Models
{
    public class PrenumerantMethods
    {

        public PrenumerantDetails GetPrenumerant(int pr_Id, out string errormsg)
        {
            //SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //koppling
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrenumeranterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //sqlstring och lägg till en skribent i databasen
            String sqlstring = "SELECT * FROM Tbl_Prenumeranter WHERE (pr_Id = @pr_Id)";

            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //Skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            PrenumerantDetails pd = new PrenumerantDetails();

            dbCommand.Parameters.Add("pr_Id", SqlDbType.Int).Value = pr_Id;


            try
            {
                dbConnection.Open();

                myAdapter.Fill(myDS, "Prenumerant");
                int count = 0;
                int i = 0;

                count = myDS.Tables["Prenumerant"].Rows.Count;

                if (count > 0)
                {
                    pd.pr_Id = Convert.ToInt16(myDS.Tables["Prenumerant"].Rows[i]["pr_Id"]);
                    pd.pr_Firstname = myDS.Tables["Prenumerant"].Rows[i]["pr_Firstname"].ToString();
                    pd.pr_Lastname = myDS.Tables["Prenumerant"].Rows[i]["pr_Lastname"].ToString();
                    pd.pr_Tlfnr = myDS.Tables["Prenumerant"].Rows[i]["pr_Tlfnr"].ToString();
                    
                    errormsg = "";
                    return pd;
                }
                else
                {
                    errormsg = "ingen med det id";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

    }
}
