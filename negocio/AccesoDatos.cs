using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string Consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = Consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
            conexion.Open();
            lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarAccion() //Hay que crear este metodo porque no es lectura, sino insert
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); //A diferencia de la de lectura, esta no tiene lector

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
