using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoDemoAulas.Classes
{
    public class BL
    {
        public static void GetCategory(Category c) {
            DAL.GetCategories();
        }
        public static bool InsertUtilizador(Utilizador user)
        {
            List<Utilizador> lista = DAL.GetUtilizadores();
            if (lista != null)
            {
                foreach (Utilizador u in lista)
                {
                    if (u.UTILIZADOR == user.UTILIZADOR)
                    {
                        return false;
                    }
                }
            }
            user.PALAVRAPASSE = Factory.Security.EncodePassword(user.PALAVRAPASSE);
            return DAL.InsertUtilizador(user);
        }
        

        internal static Category GetCategoryById(string selectedValue)
        {
            return DAL.GetCategoryById(selectedValue);
        }

        internal static Supplier GetSupplierById(string selectedValue)
        {
            return DAL.GetSupplierById(selectedValue);
        }

        internal static void InsertProduct(Product p)
        {
            DAL.InsertProduct(p);
        }

        public static bool VerificarUtilizador(ref Utilizador user_recebido)
        {
            if(user_recebido != null)
            {
                List<Utilizador> lista = DAL.GetUtilizadores();

                foreach(Utilizador u_da_lista in lista)
                {
                    if(u_da_lista.UTILIZADOR == user_recebido.UTILIZADOR
                        && u_da_lista.PALAVRAPASSE == Factory.Security.EncodePassword(user_recebido.PALAVRAPASSE))
                    {
                        user_recebido = new Utilizador(u_da_lista.ID);
                        user_recebido.UTILIZADOR = u_da_lista.UTILIZADOR;
                        user_recebido.PALAVRAPASSE = u_da_lista.PALAVRAPASSE;
                        user_recebido.NOME = u_da_lista.NOME;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool UpdateUtilizador(Utilizador user_recebido)
        {
            //Fazer aqui uma segunda validação? 
            //Server side validation?
            //Double validation? 
            //Dupla validação?

            user_recebido.PALAVRAPASSE = Factory.Security.EncodePassword(user_recebido.PALAVRAPASSE);
            return DAL.UpdateUtilizador(user_recebido);
        }

        #region employee
        public static bool InsertEmployee(Employee e_recebido)
        {
            List<Employee> lista = DAL.GetEmployees();
            if (lista != null)
            {
                foreach (Employee e_lista in lista)
                {
                    if (e_recebido.LastName == e_lista.LastName && e_recebido.FirstName == e_lista.FirstName)
                    {
                        return false;
                    }
                }
            }
            
            return DAL.InsertEmployee(e_recebido);
        }
        public static List<Employee> listEmployees()
        {
            
            return DAL.GetEmployees();
        }
        #endregion
    }
}