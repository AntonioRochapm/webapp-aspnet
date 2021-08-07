using AplicacaoDemoAulas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacaoDemoAulas.Components
{
    public partial class InserirEmployee : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardarEmployee_Click(object sender, EventArgs e)
        {
            Employee e_recebido = new Employee();

            e_recebido.LastName = txt_lname.Text;
            e_recebido.FirstName = txt_fname.Text;
            e_recebido.Birthday = calendarEmployee.SelectedDate;
            e_recebido.Country = txt_country.Text;

            BL.InsertEmployee(e_recebido);
        }
    }
}