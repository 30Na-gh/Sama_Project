using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace fr_fr_sama_project.DataManagement;

public class MyData
{
    public string Con1 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
    public string Command;

    public DataTable ShowData()
    {
        SqlConnection Sqlcon = new SqlConnection(Con1);
        SqlDataAdapter da = new SqlDataAdapter(Command, Sqlcon);
        DataTable dt = new DataTable();
        da.Fill(dt);
        Sqlcon.Close();
        return dt;
    }

    public void ManData()
    {
        SqlConnection sqlcon = new SqlConnection(Con1);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(Command, sqlcon);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                MessageBox.Show("این شماره قبلا وارد شده است");
            }
            else
            {
                MessageBox.Show("خطا: " + ex.Message);
                return;
            }
        }



    }
}