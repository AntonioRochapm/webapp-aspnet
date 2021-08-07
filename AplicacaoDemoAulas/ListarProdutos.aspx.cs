using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacaoDemoAulas.Classes;

namespace AplicacaoDemoAulas
{
    public partial class ListarProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gv_produtos.DataSource = DAL.ListarProdutos2();
            gv_produtos.DataBind();
        }

        protected void btn_Apagar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as Button).CommandArgument))
            {
                DAL.DeleteProduto((sender as Button).CommandArgument);

                gv_produtos.DataSource = DAL.ListarProdutos2();
                gv_produtos.DataBind();
            }
        }          

        protected void btn_inserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}