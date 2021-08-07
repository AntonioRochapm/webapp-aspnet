using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacaoDemoAulas
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null && Session["login"].GetType() == typeof(Classes.Utilizador))
            {
                logo_name.Text = ((Classes.Utilizador)Session["login"]).NOME;

                if (Session["Ja_Disse_Bem_vindo"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                       Guid.NewGuid().ToString(),
                       "Swal.fire({icon:'success',title:'Bem vindo',html:'" +
                       ((Classes.Utilizador)Session["login"]).NOME +
                       " entrou na aplicação com sucesso'});", true);

                    Session["Ja_Disse_Bem_vindo"] = true;
                }
            }
            else
            {
                Response.Redirect("logout.aspx");
            }
        }
    }
}