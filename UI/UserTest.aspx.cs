using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DOM;

namespace UI
{
    public partial class UserTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserManager manager = new UserManager();
            GridView1.DataSource = manager.loadUsers();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserManager manager = new UserManager();
           
            String userName = TextBox1.Text;
            String email = TextBox2.Text;
            String password = TextBox3.Text;
            User u = manager.loadUserByUserName(userName);
            if (u == null)
            {
                Label1.Text = "no existe";
            }
            else {
                Label1.Text = "existe";
            }
            




        }
    }
}