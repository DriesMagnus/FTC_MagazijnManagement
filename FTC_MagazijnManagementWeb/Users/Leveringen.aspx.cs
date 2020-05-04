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
    public partial class Leveringen : System.Web.UI.Page
    {
        private Controller c;

        protected void Page_Load(object sender, EventArgs e)
        {
            c = (Controller)Session["controller"];
            var leveringen = c.GetApparaatList();

            if (!IsPostBack)
            {
                ddlApparaten.DataSource = leveringen;
                ddlApparaten.DataTextField = "Naam";
                ddlApparaten.DataValueField = "Id";
                ddlApparaten.DataBind();
                if (leveringen.Count != 0)
                {
                    ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
                }
                else
                {
                    grvLeveringen.DataSource = null;
                    grvLeveringen.DataBind();
                }
            }
            else
            {
                grvLeveringen.DataSource =  c.GetApparaat(Convert.ToInt32(ddlApparaten.SelectedValue))._leveringen;
                grvLeveringen.DataBind();
            }

            if (Session["apparaatnr"] != null)
            {
                var lidNr = (int)Session["apparaatnr"];
                Session["apparaatnr"] = null;
                var item = ddlApparaten.Items.FindByValue(lidNr.ToString());
                ddlApparaten.SelectedIndex = ddlApparaten.Items.IndexOf(item);
                ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
            }
        }

        private void ToonInfo(int id = 0)
        {
            c = (Controller)Session["controller"];
            var apparaat = c.GetApparaat(id);
            if (apparaat != null)
            {
                grvLeveringen.DataSource = apparaat._leveringen;
                grvLeveringen.DataBind();
                lblTotaal.Text = apparaat.ToString();
            }
            else
            {
                grvLeveringen.DataSource = null;
                lblTotaal.Text = "";
            }
        }

        protected void ddlApparaten_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
        }

        protected void grvLeveringen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0 && e.NewPageIndex < grvLeveringen.PageCount)
            {
                grvLeveringen.PageIndex = e.NewPageIndex;
                grvLeveringen.DataBind();
            }
        }

        protected void grvLeveringen_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvLeveringen.EditIndex = e.NewEditIndex;
            ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
        }

        protected void grvLeveringen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvLeveringen.EditIndex = -1;
            ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
        }

        protected void grvLeveringen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var apparaatid = Convert.ToInt32(ddlApparaten.SelectedValue);
            var aantal = Convert.ToInt32(e.NewValues["Aantal"]);
            var locatie = e.NewValues["Locatie"].ToString();

            c.UpdateLevering(e.RowIndex, aantal, locatie);
            grvLeveringen.EditIndex = -1;
            grvLeveringen.DataSource = c.GetAllLeveringen(c.GetApparaat(apparaatid));
            grvLeveringen.DataBind();
            ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
        }

        protected void grvLeveringen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowindex = e.RowIndex;
            GridViewRow row = grvLeveringen.Rows[rowindex];
            int dataitemindex = grvLeveringen.Rows[rowindex].DataItemIndex;
            int apparaatid = Convert.ToInt32(ddlApparaten.SelectedValue);
            c.RemoveLevering(apparaatid, ((TextBox)row.Cells[2].Controls[0]).Text);
            ToonInfo(apparaatid);
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}