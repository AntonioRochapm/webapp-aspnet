using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacaoDemoAulas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null && Session["login"].GetType() == typeof(Classes.Utilizador))
            {
                Response.Redirect("dashboard.aspx");
            }
        }

        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            Classes.Utilizador user = new Classes.Utilizador("");
            user.UTILIZADOR = login_u.Text;
            user.PALAVRAPASSE = login_p.Text;

            if (Classes.BL.VerificarUtilizador(ref user) == true)
            {
                Session["login"] = user;
                Response.Redirect("dashboard.aspx");
            }
            else
            {
                //Falta dar aviso de insucesso
            }
        }

        protected void btn_registar_Click(object sender, EventArgs e)
        {
            Classes.Utilizador user = new Classes.Utilizador();

            user.UTILIZADOR = registar_u.Text;
            user.PALAVRAPASSE = registar_p.Text;
            user.NOME = registar_n.Text;

            if (Classes.BL.InsertUtilizador(user) == true)
            {
                registar_u.Text = registar_p.Text = registar_n.Text = "";
                //Falta dar aviso de sucesso
            }
            else
            {
                //Falta dar aviso de insucesso
            }


        }
    }
}