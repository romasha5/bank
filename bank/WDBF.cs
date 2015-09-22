using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace bank
{
    class WorkDBF
    {
        public DataTable getTable(string path, string nam)
        {
            try {
                DataTable dt = new DataTable();
                string constring = "Provider=VFPOLEDB.1;Data Source=" +
                    path + ";Extended Properties=dBase IV;User Id=Admin;Password=";

                    //@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                    //";Extended Properties=dBASE IV;User ID=;Password=;";
                OleDbConnection con = new OleDbConnection(constring);
                con.Open();
                string sel = "SELECT * FROM " + nam;
                OleDbDataAdapter da = new OleDbDataAdapter(sel, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                dt = ds.Tables[0];
                return dt;
            }
            catch(OleDbException exp)
            {
                MessageBox.Show(exp.Message);
                return null;
            }
        }
    }
}

