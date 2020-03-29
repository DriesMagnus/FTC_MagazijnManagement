using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTC_MagazijnManagement.Business;

namespace FTC_MagazijnManagementWeb.Users
{
    public partial class Apparaten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller c = (Controller)Session["controller"];
            var leveringen = c.GetApparaatList();

            grvLeveringen.DataSource = leveringen;
            grvLeveringen.DataBind();
            lblTotaal.Text = $"Totaal aantal leveringen: {BerekenTotaal(leveringen)}";
        }

        public decimal BerekenTotaal(List<Apparaat> apparaten)
        {
            int totaal = 0;
            foreach (Apparaat apparaat in apparaten)
            { totaal += apparaat._leveringen.Count; }
            return totaal;
        }

        protected void grvLeveringen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0 && e.NewPageIndex < grvLeveringen.PageCount)
            {
                grvLeveringen.PageIndex = e.NewPageIndex;
                grvLeveringen.DataBind();
            }
        }

        protected void grvLeveringen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["apparaatnr"] = ((int)grvLeveringen.SelectedValue);
            Response.Redirect("Leveringen.aspx");
        }

        protected void grvLeveringen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rijnr = e.RowIndex;
            GridViewRow row = grvLeveringen.Rows[rijnr];
            int apparaatnr = (int)grvLeveringen.DataKeys[rijnr].Value;

            Controller c = (Controller)Session["controller"];
            c.RemoveApparaat(apparaatnr);
            List<Apparaat> leveringen = c.GetApparaatList();
            grvLeveringen.DataBind();
            lblTotaal.Text = $"Totaal aantal leveringen: {BerekenTotaal(leveringen)}";
        }

        protected void grvLeveringen_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvLeveringen.EditIndex = e.NewEditIndex;
            grvLeveringen.DataBind();
        }

        protected void grvLeveringen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvLeveringen.EditIndex = -1;
            grvLeveringen.DataBind();
        }

        protected void grvLeveringen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grvLeveringen.Rows[e.RowIndex];
            string nieuwenaam = ((TextBox)row.Cells[1].Controls[0]).Text;
            string nieuwtype = ((TextBox)row.Cells[2].Controls[0]).Text;
            int ledenlijstindex = row.DataItemIndex;
            int apparaatid = (int)grvLeveringen.DataKeys[ledenlijstindex].Value;
            Controller c = (Controller)Session["controller"];
            
            c.UpdateApparaat(apparaatid, nieuwenaam, nieuwtype);
            grvLeveringen.EditIndex = -1;
            grvLeveringen.DataBind();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}