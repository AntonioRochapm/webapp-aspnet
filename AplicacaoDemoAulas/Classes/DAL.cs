using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacaoDemoAulas.Classes
{    
    public class DAL
    {
        //***********************************************
        //***********************************************
        //EXEMPLO DE GENERALIZAÇÃO - 3 MÉTODOS PASSAM A 1
        public static void InsertTestes(int id, string descricao)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            comando.CommandText = "INSERT INTO TESTES (ID,DESCRICAO) VALUES (@ID,@DESCRICAO)";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@DESCRICAO", descricao);
            comando.Connection = conn;

            comando.ExecuteNonQuery();
        }

        

        public static void UpdateTestes(int id, string descricao)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            comando.CommandText = "UPDATE TESTES SET DESCRICAO=@DESCRICAO WHERE ID=@ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@DESCRICAO", descricao);
            comando.Connection = conn;

            comando.ExecuteNonQuery();
        }
        public static void DeleteTestes(int id, string descricao = null)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            comando.CommandText = "DELETE FROM TESTES WHERE ID=@ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Connection = conn;

            comando.ExecuteNonQuery();
        }

        public static void IUD_Testes(string tipo_operacao, string nome_tabela, Dictionary<string, string> valores)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            comando.CommandText = tipo_operacao;
            comando.CommandText += tipo_operacao == "INSERT" ? $" INTO {nome_tabela} "
                                                             : tipo_operacao == "UPDATE" ? $" {nome_tabela} SET "
                                                             : tipo_operacao == "DELETE" ? $" FROM {nome_tabela} WHERE ID=@ID"
                                                             : "";

            string inserts_campos = " (", inserts_valores = " (", updates = "", deletes = "";
            foreach (KeyValuePair<string, string> item_dicionario in valores)
            {
                //INSERT INTO {NOME_TABELA} (CAMPO1,CAMPO2,CAMPO3) VALUES (@CAMPO1,@CAMPO2,@CAMPO3)
                if (tipo_operacao == "INSERT")
                {
                    inserts_campos += item_dicionario.Key + ",";
                    inserts_valores += "@" + item_dicionario.Key + ",";

                    comando.Parameters.AddWithValue("@" + item_dicionario.Key, item_dicionario.Value);
                }
                else if(tipo_operacao == "UPDATE")//UPDATE {NOME_TABELA} SET 
                {
                    //NOME_CAMPO=@NOME_CAMPO
                    //Parameters(@NOME_CAMPO,valor)
                    updates += $"{item_dicionario.Key}=@{item_dicionario.Key}";
                    comando.Parameters.AddWithValue("@" + item_dicionario.Key, item_dicionario.Value);
                }
                else
                {

                }
            }

            if (tipo_operacao == "INSERT")
            {
                inserts_campos = inserts_campos.Remove(inserts_campos.Length - 1, 1);
                inserts_valores = inserts_valores.Remove(inserts_valores.Length - 1, 1);

                inserts_campos += ")";
                inserts_valores += ")";

                comando.CommandText += $" {inserts_campos} VALUES {inserts_valores}";
            }
            else if(tipo_operacao == "UPDATE")
            {
                //WHERE
            }

            comando.Connection = conn;

            comando.ExecuteNonQuery();
        }
        //***********************************************
        //***********************************************
        //***********************************************

        public static DataSet ListarProdutos()
        {
            SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);           
            string strSql = @"SELECT [ProductID] as [ID]
                                  ,[ProductName] as [Designação]
                                  ,[UnitPrice] as [Preço]
                                  ,[UnitsInStock] [Em Stock]
                              FROM [Products]";

            if (connStr.State != ConnectionState.Open)
                connStr.Open();

            SqlDataAdapter da = new SqlDataAdapter(strSql, connStr);

            DataSet retorno = new DataSet();

            da.Fill(retorno);

            return retorno;
        }

        public static List<Product> ListarProdutos2()
        {
            SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);
            string strSql = @"SELECT [ProductID] as [ID]
                                  ,[ProductName] as [Designação]
                                  ,[UnitPrice] as [Preço]
                                  ,[UnitsInStock] [Em Stock]
                              FROM [Products]";

            if (connStr.State != ConnectionState.Open)
                connStr.Open();

            SqlCommand cmd = new SqlCommand(strSql, connStr);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                List<Product> lista = new List<Product>();
                while (dr.Read())
                {
                    lista.Add(new Product
                    {
                        ID = dr.GetInt32(0),
                        Designacao = dr.GetString(1),
                        Preco = dr.GetDecimal(2),
                        QtdStock = dr.GetInt16(3)
                    });
                }
                return lista;
            }

            return null;
        }

        public static void DeleteProduto(string ID)
        {
            SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);
            string strSql = @"DELETE
                              FROM [Products] WHERE [ProductID]=@id";

            if (connStr.State != ConnectionState.Open)
                connStr.Open();

            SqlCommand cmd = new SqlCommand(strSql, connStr);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.ExecuteNonQuery();
        }


        #region SELECT
        public static Utilizador GetUtilizador(string id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizadores WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    //LEITURA DE DADOS ATRAVÉS DE NOME DE COLUNA
                    dr.Read();
                    Utilizador u = new Utilizador(dr["ID"].ToString());
                    u.UTILIZADOR = dr["Utilizador"].ToString();
                    u.PALAVRAPASSE = dr["PalavraPasse"].ToString();
                    u.PALAVRAPASSE = dr["Nome"].ToString();

                    //LEITURA DE DADOS ATRAVÉS DE ÍNDICE DE COLUNA
                    //dr.Read();
                    //Utilizador u = new Utilizador(dr.GetString(0));
                    //u.UTILIZADOR = dr.GetString(1);
                    //u.PALAVRAPASSE = dr.GetString(2);

                    return u;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<Utilizador> GetUtilizadores()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizadores", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    List<Utilizador> lista = new List<Utilizador>();
                    while (dr.Read())
                    {
                        Utilizador u = new Utilizador(dr["ID"].ToString());
                        u.UTILIZADOR = dr["Utilizador"].ToString();
                        u.PALAVRAPASSE = dr["PalavraPasse"].ToString();
                        u.NOME = dr["Nome"].ToString();
                        lista.Add(u);
                    }
                    return lista;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<Employee> GetEmployee()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    List<Employee> lista = new List<Employee>();
                    while (dr.Read())
                    {
                        Employee u = new Employee(dr["ID"].ToString());
                        u.FirstName = dr["FirstName"].ToString();
                        u.LastName = dr["LastName"].ToString();
                        u.Birthday = DateTime.Parse(dr["Birthday"].ToString());
                        u.Country = dr["Country"].ToString();
                        u.reportsTo = dr.IsDBNull(dr.GetOrdinal("ReportsTo")) ? -1 : int.Parse(dr["ReportsTo"].ToString());

                        lista.Add(u);
                    }
                    return lista;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        internal static Supplier GetSupplierById(string selectedValue)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers WHERE SupplierID=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedValue);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return new Supplier
                    {
                        ID = int.Parse(dr["SupplierID"].ToString()),
                        Nome = dr["CompanyName"].ToString()
                    };                        
                                    
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static Category GetCategoryById(string selectedValue)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE CategoryID=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedValue);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return new Category
                        {
                            ID = int.Parse(dr["CategoryID"].ToString()),
                            Designacao = dr["CategoryName"].ToString()
                        };                    
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<Category> GetCategories()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    List<Category> lista = new List<Category>();
                    while (dr.Read())
                    {
                        Category u = new Category
                        {
                            ID = int.Parse(dr["CategoryID"].ToString()),
                            Designacao = dr["CategoryName"].ToString()
                        };                                               
                        
                        lista.Add(u);
                    }
                    return lista;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<Employee> GetEmployees()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    List<Employee> lista = new List<Employee>();
                    while (dr.Read())
                    {
                        Employee u = new Employee(dr["EmployeeID"].ToString());
                        u.FirstName = dr["FirstName"].ToString();
                        u.LastName = dr["LastName"].ToString();
                        u.Birthday = DateTime.Parse(dr["BirthDate"].ToString());
                        u.Country = dr["Country"].ToString();
                        u.reportsTo = dr.IsDBNull(dr.GetOrdinal("ReportsTo")) ? -1 : int.Parse(dr["ReportsTo"].ToString());
                        

                        lista.Add(u);
                    }
                    return lista;
                }
                else                    
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Product GetProduct(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaconnectionstring"].ConnectionString);
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("select * from products where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    //leitura de dados através de nome de coluna
                    dr.Read();
                    Product p = new Product();
                    p.Designacao = dr["ProductName"].ToString();
                    p.Category.ID = int.Parse(dr["CategoryID"].ToString());
                    p.Descontinuado = bool.Parse(dr["Discontinued"].ToString());
                    p.Preco = decimal.Parse(dr["UnitPrice"].ToString());
                    p.Supplier.ID = int.Parse(dr["SupplierID"].ToString());
                    p.QtByUnidade = dr["QuantityPerUnit"].ToString();
                    p.QtdStock = Int16.Parse(dr["UnitsInStock"].ToString());
                    p.QtdOnOrder = Int16.Parse(dr["UnitsOnOrder"].ToString());
                    p.ReorderLevel = Int16.Parse(dr["ReorderLevel"].ToString());                    

                    return p;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }          
        #endregion

        #region INSERT
        public static bool InsertUtilizador(Utilizador u)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand($"INSERT INTO Utilizadores (ID,Utilizador,PalavraPasse,Nome) VALUES (@i,@u,@p,@n)", conn);
                cmd.Parameters.AddWithValue("@i", u.ID);
                cmd.Parameters.AddWithValue("@u", u.UTILIZADOR);
                cmd.Parameters.AddWithValue("@p", u.PALAVRAPASSE);
                cmd.Parameters.AddWithValue("@n", u.NOME);
                return cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool InsertEmployee(Employee e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);
                string strSql = @"INSERT INTO Employees (LastName,FirstName,BirthDate,Country) values (@l,@f,@b,@c)";
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand(strSql, conn);                
                cmd.Parameters.AddWithValue("@l", e.LastName);
                cmd.Parameters.AddWithValue("@f", e.FirstName);
                cmd.Parameters.AddWithValue("@b", e.Birthday);
                cmd.Parameters.AddWithValue("@c", e.Country);
                
                return cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool InsertProduct(Product p)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);
                string strSql = @"INSERT INTO Products values (@p,@s,@c,@qu,@up,@us,@uo,@rl,@d)";
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand(strSql, conn);                
                cmd.Parameters.AddWithValue("@p", p.Designacao);
                cmd.Parameters.AddWithValue("@s", p.Supplier.ID);
                cmd.Parameters.AddWithValue("@c", p.Category.ID);
                cmd.Parameters.AddWithValue("@qu", p.QtByUnidade);
                cmd.Parameters.AddWithValue("@up", p.Preco);
                cmd.Parameters.AddWithValue("@us", p.QtdStock);
                cmd.Parameters.AddWithValue("@uo", p.QtdOnOrder);
                cmd.Parameters.AddWithValue("@rl", p.ReorderLevel);
                cmd.Parameters.AddWithValue("@d", p.Descontinuado);

                return cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region UPDATE
        public static bool UpdateUtilizador(Utilizador u)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Utilizadores SET Utilizador=@u,PalavraPasse=@p,Nome=@n WHERE ID=@i", conn);
                cmd.Parameters.AddWithValue("@u", u.UTILIZADOR);
                cmd.Parameters.AddWithValue("@p", u.PALAVRAPASSE);
                cmd.Parameters.AddWithValue("@n", u.NOME);
                cmd.Parameters.AddWithValue("@i", u.ID);
                return cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        #endregion

        #region DELETE
        public static bool DeleteUtilizador(string id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaConnectionString"].ConnectionString);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Utilizadores WHERE ID=@i)", conn);
                cmd.Parameters.AddWithValue("@i", id);
                return cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}