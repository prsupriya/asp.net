using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace MyDbApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
           {
                if (Request["msg"] != null && Request["msg"]=="added")
                {
                    lblMsg.Text ="The new city has been added.";
                }else if (Request["msg"] != null && Request["msg"] == "edited")
                {
                    lblMsg.Text = "The city has been Edited.";
                }else if (Request["msg"] != null && Request["msg"] == "deleted")
                {
                    lblMsg.Text = "The city has been deleted";
                }
                string cs = ConfigurationManager.ConnectionStrings["SupDBConn"].ConnectionString;

                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select Id,City From Cities",cn);
                    ddlCities.DataSource = cmd.ExecuteReader();
                    ddlCities.DataTextField = "City";
                    ddlCities.DataValueField = "ID";
                    ddlCities.DataBind();
                    ListItem li = new ListItem("-- Cities --", "0");
                    ddlCities.Items.Insert(0,li);

                }

            }
        }
        protected void btnEnter_Click(object sender, EventArgs e )
        {
            string cs = ConfigurationManager.ConnectionStrings["SupDBConn"].ConnectionString.ToString();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cs);
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Cities(City) VALUES('" + txtCity.Text + "')";
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        Response.Write("Added");
                        Response.Redirect("CitiesForm.aspx?msg=added");
                    }
                    else
                    {
                        Response.Write("Error");
                    }

                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        protected void ddlCities_IndexChanged(object sender, EventArgs e)
        {
            txtCity.Text = ddlCities.Items[ddlCities.SelectedIndex].Text;
        }
        protected void btnEdit_Click(Object sender, EventArgs e)
        {

            
            String cs = ConfigurationManager.ConnectionStrings["SupDBConn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Update Cities set City='" + txtCity.Text + "' where Id=" + ddlCities.SelectedValue, cn);
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected == 1)
                {
                    Response.Redirect("CitiesForm.aspx?msg=edited");
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["SupDBConn"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("DELETE from Cities where ID = " + ddlCities.Items[ddlCities.SelectedIndex].Value,cn);
                cmd.ExecuteNonQuery();

                Response.Redirect("CitiesForm.aspx?msg=deleted");

            }
        }
    }
}