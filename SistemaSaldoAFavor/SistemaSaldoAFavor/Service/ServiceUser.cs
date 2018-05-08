using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaSaldoAFavor.Service
{
    public class ServiceUser
    {

        public static String GetAutenctication(String UserName, String Pwd)
        {
            String usName = "";
            try
            {


                using (SqlConnection connetion = new SqlConnection(ConnectionStrings.ConnectionString))
                {

                    if (connetion.State == ConnectionState.Closed)
                    {
                        connetion.Open();
                    }

                    using (SqlCommand _DbCommand = new SqlCommand())
                    {
                        _DbCommand.Connection = connetion;

                        _DbCommand.CommandType = CommandType.StoredProcedure;

                        _DbCommand.CommandText = "[dbo].[splogin]";

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@cuenta", SqlDbType = SqlDbType.VarChar, Value = UserName });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@pass", SqlDbType = SqlDbType.VarChar, Value = Pwd });

                        using (SqlDataReader dr = _DbCommand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (dr[0] != DBNull.Value)
                                    {
                                        usName = dr[0].ToString();
                                    }

                                }

                            }
                        }

                    }

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return usName;
        }

    }
}