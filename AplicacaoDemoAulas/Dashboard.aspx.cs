using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacaoDemoAulas
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control c = Page.LoadControl($"{ConfigurationManager.AppSettings["UC_FOLDER"]}InserirProduto.ascx");
            ph_InserirProduto.Controls.Add(c);

            Control c1 = Page.LoadControl($"{ConfigurationManager.AppSettings["UC_FOLDER"]}InserirEmployee.ascx");
            ph_InserirEmpregado.Controls.Add(c1);
        }
    }
}