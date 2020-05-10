using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTC_MagazijnManagement.Business;

namespace FTC_MagazijnManagementWeb.Users
{
    public partial class Apparaten : Page
    {
        private Controller c;

        protected void Page_Load(object sender, EventArgs e)
        {
            c = (Controller) Session["controller"];
            var apparaten = c.GetApparaatList();

            grvLeveringen.DataSource = apparaten;
            grvLeveringen.DataBind();
            lblTotaal.Text = $"Totaal aantal leveringen: {BerekenTotaal(apparaten)}";
        }

        public decimal BerekenTotaal(List<Apparaat> apparaten)
        {
            var totaal = 0;
            foreach (var apparaat in apparaten) totaal += apparaat._leveringen.Count;
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
            Session["apparaatnr"] = (int) grvLeveringen.SelectedValue;
            Response.Redirect("Leveringen.aspx");
        }

        protected void grvLeveringen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var rijnr = e.RowIndex;
            var row = grvLeveringen.Rows[rijnr];
            var apparaatnr = (int) grvLeveringen.DataKeys[rijnr].Value;

            c = (Controller) Session["controller"];
            c.RemoveApparaat(apparaatnr);
            var leveringen = c.GetApparaatList();
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
            var row = grvLeveringen.Rows[e.RowIndex];
            var nieuwenaam = ((TextBox) row.Cells[1].Controls[0]).Text;
            var nieuwtype = ((TextBox) row.Cells[2].Controls[0]).Text;
            var ledenlijstindex = row.DataItemIndex;
            var apparaatid = (int) grvLeveringen.DataKeys[ledenlijstindex].Value;
            c = (Controller) Session["controller"];

            c.UpdateApparaat(apparaatid, nieuwenaam, nieuwtype);
            grvLeveringen.EditIndex = -1;
            grvLeveringen.DataBind();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }

        protected void btnAddApparaat_Click(object sender, EventArgs e)
        {
            var naam = "";
            var type = "";
            var gelukt = true;

            try
            {
                naam = Convert.ToString(iptNaam.Value);
                if (string.IsNullOrEmpty(naam) || string.IsNullOrWhiteSpace(naam))
                {
                    foutboodschap.Text = "Dit is geen valide naam. Kijk na of u de juiste tekens heeft ingevoerd.";
                    foutboodschap.Visible = true;
                    gelukt = false;
                    iptNaam.Value = "";
                    iptType.Value = "";
                }
            }
            catch
            {
                foutboodschap.Text = "Dit is geen valide naam. Kijk na of u de juiste tekens heeft ingevoerd.";
                foutboodschap.Visible = true;
                gelukt = false;
            }

            try
            {
                type = Convert.ToString(iptType.Value);
                if (string.IsNullOrEmpty(type) || string.IsNullOrWhiteSpace(type))
                {
                    foutboodschap.Text = "Dit is geen valide type. Kijk na of u de juiste tekens heeft ingevoerd.";
                    foutboodschap.Visible = true;
                    gelukt = false;
                    iptNaam.Value = "";
                    iptType.Value = "";
                }
            }
            catch
            {
                foutboodschap.Text = "Dit is geen valide type. Kijk na of u de juiste tekens heeft ingevoerd.";
                foutboodschap.Visible = true;
                gelukt = false;
            }

            if (gelukt)
            {
                c.AddApparaat(naam, type);
                grvLeveringen.DataSource = c.GetApparaatList();
                grvLeveringen.DataBind();
                iptNaam.Value = "";
                iptType.Value = "";
            }
        }
    }
}