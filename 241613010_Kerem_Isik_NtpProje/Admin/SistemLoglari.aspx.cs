using NtpProje_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _241613010_Kerem_Isik_NtpProje.Admin
{
    public partial class SistemLoglari : System.Web.UI.Page
    {
        LogManager logManager = new LogManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLogs();
            }
        }

        private void BindLogs()
        {
            gvLogs.DataSource = logManager.GetAllLogs();
            gvLogs.DataBind();
        }

        protected void btnClearLogs_Click(object sender, EventArgs e)
        {
            logManager.ClearAllLogs();
            BindLogs(); // Tabloyu yenile (boşalmış haliyle)
        }
    }
}