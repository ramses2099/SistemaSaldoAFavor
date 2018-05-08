using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SistemaSaldoAFavor.Models;

namespace SistemaSaldoAFavor.Service
{
    public class ServiceSaldoAFavor
    {

        public static List<SaldosAFavor> GetAll()

        {
            String sql = "SELECT * FROM dbo.TSaldosAFavor order by fecha desc";

            List<SaldosAFavor> lstResult = new List<SaldosAFavor>();

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

                        _DbCommand.CommandType = CommandType.Text;

                        _DbCommand.CommandText = sql;

                        using (SqlDataReader dr = _DbCommand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {

                                    SaldosAFavor row = new SaldosAFavor();

                                    if (dr[0] != DBNull.Value)
                                    {
                                        row.IdSaldosAFavor = Convert.ToInt32(dr[0].ToString());
                                    }
                                    //
                                    if (dr[1] != DBNull.Value)
                                    {
                                        row.Servicio = dr[1].ToString();
                                    }
                                    //
                                    if (dr[2] != DBNull.Value)
                                    {
                                        row.Recibo = String.Format("<a href='http://hit-app02:8905/AplicacionSaldos.aspx?autenticado=1&recibo={0}'>{0}</a>", dr[2].ToString());

                                        row.Anular = String.Format("<a href='http://hit-app02:8905/AplicacionSaldos.aspx?autenticado=1&recibo={0}'>Anular</a>", dr[2].ToString());
                                    }
                                    //
                                    if (dr[3] != DBNull.Value)
                                    {
                                        row.Fecha = Convert.ToDateTime(dr[3]).ToString("MM/dd/yyyy");
                                    }
                                    //
                                    if (dr[4] != DBNull.Value)
                                    {
                                        row.RNC = dr[4].ToString();
                                    }
                                    //
                                    if (dr[5] != DBNull.Value)
                                    {
                                        row.Cliente = dr[5].ToString();
                                    }
                                    else
                                    {
                                        row.Cliente = "";
                                    }
                                    //
                                    if (dr[6] != DBNull.Value)
                                    {
                                        row.Usuario = dr[6].ToString();
                                    }
                                    //
                                    if (dr[7] != DBNull.Value)
                                    {
                                        row.TipoPago = dr[7].ToString();
                                    }
                                    else
                                    {
                                        row.TipoPago = "";
                                    }
                                    //
                                    if (dr[8] != DBNull.Value)
                                    {
                                        row.MontoRecibo = Convert.ToDecimal(dr[8]).ToString("c");
                                    }
                                    //
                                    if (dr[9] != DBNull.Value)
                                    {
                                        row.MontoAFavor = Convert.ToDecimal(dr[9]).ToString("c");
                                    }
                                    //
                                    if (dr[10] != DBNull.Value)
                                    {
                                        row.SaldoDisponible = Convert.ToDecimal(dr[10]).ToString("c");
                                    }
                                    //
                                    if (dr[11] != DBNull.Value)
                                    {
                                        row.Estatus = dr[11].ToString();
                                    }
                                    //
                                    if (dr[12] != DBNull.Value)
                                    {
                                        row.Comentario = dr[12].ToString();
                                    }

                                    lstResult.Add(row);

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

            return lstResult;
        }


    }
}