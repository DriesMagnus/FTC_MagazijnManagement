using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTC_MagazijnManagement.Business;

namespace FTC_MagazijnManagementWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var foutboodschap = (Label)LoginView1.FindControl("foutboodschap");
                foutboodschap.Text = "";
                foutboodschap.Visible = false;
            }
        }

        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            var foutboodschap = (Label)LoginView1.FindControl("foutboodschap");
            var gebruikersnaam = Request.Form["gebruikersnaam"];
            var paswoord = Request.Form["paswoord"];
            Controller c = (Controller)Session["controller"];

            //Aanmelden
            if (c.Aanmelden(gebruikersnaam, paswoord))
            {
                Session["User"] = gebruikersnaam;
                FormsAuthentication.RedirectFromLoginPage(gebruikersnaam, false);
                Response.Redirect("Users/Apparaten.aspx");
            }
            else
            {
                foutboodschap.Text = "Foutieve inloggegevens";
                foutboodschap.Visible = true;
            }
        }
    }
}