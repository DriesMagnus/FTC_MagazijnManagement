using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTC_MagazijnManagement.Business;

namespace FTC_MagazijnManagementWeb.Users
{
    public partial class Leveringen : Page
    {
        private Controller c;

        protected void Page_Load(object sender, EventArgs e)
        {
            c = (Controller) Session["controller"];
            var apparaten = c.GetApparaatList();

            if (!IsPostBack)
            {
                ddlApparaten.DataSource = apparaten;
                ddlApparaten.DataTextField = "Naam";
                ddlApparaten.DataValueField = "Id";
                ddlApparaten.DataBind();

                ddlSelectApparaat.DataSource = apparaten;
                ddlSelectApparaat.DataTextField = "Naam";
                ddlSelectApparaat.DataValueField = "Id";
                ddlSelectApparaat.DataBind();
                ddlSelectApparaat.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlSelectApparaat.SelectedIndex = 0;

                if (apparaten.Count != 0)
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
                grvLeveringen.DataSource = c.GetApparaat(Convert.ToInt32(ddlApparaten.SelectedValue))._leveringen;
                grvLeveringen.DataBind();
            }

            if (Session["apparaatnr"] != null)
            {
                var apparaatNr = (int) Session["apparaatnr"];
                Session["apparaatnr"] = null;
                var item = ddlApparaten.Items.FindByValue(apparaatNr.ToString());
                ddlApparaten.SelectedIndex = ddlApparaten.Items.IndexOf(item);
                ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
            }
        }

        private void ToonInfo(int id = 0)
        {
            c = (Controller) Session["controller"];
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
            grvLeveringen.EditIndex = -1;
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

            c.UpdateLevering(apparaatid, aantal, locatie);
            grvLeveringen.EditIndex = -1;
            grvLeveringen.DataSource = c.GetAllLeveringen(c.GetApparaat(apparaatid));
            grvLeveringen.DataBind();
            ToonInfo(Convert.ToInt32(ddlApparaten.SelectedValue));
        }

        protected void grvLeveringen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var rowindex = e.RowIndex;
            var row = grvLeveringen.Rows[rowindex];
            var dataitemindex = grvLeveringen.Rows[rowindex].DataItemIndex;
            var apparaatid = Convert.ToInt32(ddlApparaten.SelectedValue);
            c.RemoveLevering(apparaatid, grvLeveringen.Rows[rowindex].Cells[1].Text);
            ToonInfo(apparaatid);
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }

        protected void btnAddLevering_OnClick(object sender, EventArgs e)
        {
            var gelukt = true;
            if (ddlSelectApparaat.SelectedIndex > 0)
            {
                var apparaat = c.GetApparaat(Convert.ToInt32(ddlSelectApparaat.SelectedValue));
                var aantal = 0;
                var rij = 0;
                var vak = 0;

                try
                {
                    aantal = Convert.ToInt32(iptAantal.Value);
                    if (!(aantal > 0))
                    {
                        foutboodschap.Text = "Ongeldig aantal. Het aantal moet groter zijn dan 0.";
                        foutboodschap.Visible = true;
                        gelukt = false;
                        goto Finish;
                    }
                }
                catch
                {
                    foutboodschap.Text = "Ongeldig aantal.";
                    foutboodschap.Visible = true;
                    gelukt = false;
                    goto Finish;
                }

                try
                {
                    rij = Convert.ToInt32(iptRij.Value);
                    if (!(rij > 0))
                    {
                        foutboodschap.Text = "Ongeldige rij. Het rijnummer moet groter zijn dan 0.";
                        foutboodschap.Visible = true;
                        gelukt = false;
                        goto Finish;
                    }
                }
                catch
                {
                    foutboodschap.Text = "Ongeldige rij.";
                    foutboodschap.Visible = true;
                    gelukt = false;
                    goto Finish;
                }

                try
                {
                    vak = Convert.ToInt32(iptVak.Value);
                    if (!(vak > 0))
                    {
                        foutboodschap.Text = "Ongeldig vak. Het vaknummer moet groter zijn dan 0.";
                        foutboodschap.Visible = true;
                        gelukt = false;
                        goto Finish;
                    }
                }
                catch
                {
                    foutboodschap.Text = "Ongeldig vak.";
                    foutboodschap.Visible = true;
                    gelukt = false;
                    goto Finish;
                }
                
                if (gelukt)
                {
                    var locatie = $"({rij},{vak})";
                    var leveringen = c.GetLeveringList();
                    var isUniek = true;

                    foreach (var levering in leveringen)
                    {
                        if (c.GetLevering(levering.ApparaatId, locatie) == levering)
                        {
                            isUniek = false;
                        }
                    }

                    if (isUniek)
                    {
                        c.AddLevering(apparaat.Id, locatie, aantal);
                        ToonInfo(apparaat.Id);
                    }
                    else
                    {
                        foutboodschap.Text = "Deze locatie is al bezet. Neem een andere waarde voor rij en/of vak.";
                        foutboodschap.Visible = true;
                    }
                }
            }
            else
            {
                foutboodschap.Text = "Geen apparaat geselecteerd.";
                foutboodschap.Visible = true;
            }

            ddlSelectApparaat.SelectedIndex = 0;
            Finish:
            if (gelukt)
            {
                iptAantal.Value = "";
                iptRij.Value = "";
                iptVak.Value = "";
            }
        }
    }
}