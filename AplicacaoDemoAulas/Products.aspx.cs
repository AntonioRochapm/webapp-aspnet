using AplicacaoDemoAulas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacaoDemoAulas
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            Category c = BL.GetCategoryById(dd_category.SelectedValue);
            Supplier s = BL.GetSupplierById(dd_supplier.SelectedValue);

            p.Designacao = txt_nome.Text;
            p.Preco = decimal.Parse(txt_preco.Text);
            p.QtByUnidade = TextBox2.Text;
            p.QtdStock = short.Parse(txt_unidade_stock.Text);
            p.QtdOnOrder = short.Parse(txt_u_encomendadas.Text);
            p.ReorderLevel = short.Parse(txt_r_level.Text);
            p.Descontinuado = cb_descontinuado.Checked;
            p.Supplier = s;
            p.Category = c;
            

            BL.InsertProduct(p);
        }
    }
}