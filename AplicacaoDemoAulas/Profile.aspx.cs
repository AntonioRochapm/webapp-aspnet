using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacaoDemoAulas
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preencher as caixas de texto com o user da Session
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar as caixas de texto (deste lado, ou seja, do lado do SERVIDOR)



            //Obter o user da Session
            Classes.Utilizador user_lido_da_Session = (Classes.Utilizador)Session["login"];

            //Atualizar esse user com o que foi escrito na página
            user_lido_da_Session.PALAVRAPASSE = txt_ppass.Text;

            //Atualizar na base de dados
            if (Classes.BL.UpdateUtilizador(user_lido_da_Session) == true)
            {
                txt_nppass.Text = txt_ppass.Text = "";

                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(),
                    "Swal.fire('Sucesso!')", true);
            }
            else
            {
                //Deu erro, avisar
            }


        }
    }
}