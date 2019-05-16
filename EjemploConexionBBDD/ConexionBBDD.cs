﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace EjemploConexionBBDD
{

    class ConexionBBDD
    {
        MySqlConnection conexion = new MySqlConnection(
                "Server = 127.0.0.1;" +
                "Database= videoclub;" +
                "Uid=root1234;" +
                "Pwd=;" +
                "Port=3306");
        public MySqlConnection conecta()
        {
            /*Se necesitan 5 parametros para iniciar la conexion
             * 1º Server: IP o nombre del servidor
             * 2º Database: Nombre de la BBDD
             * 3º UID: User ID (not null)
             * 4º Password: contraseña
             * 5º Port: puerto, por defecto es el 3306*/
            
            conexion.Open();
            return conexion;

        }
        public static void probarConexion()
        {
            MySqlConnection conexion = new MySqlConnection(
                "Server = 127.0.0.1;" +
                "Database= videoclub;" +
                "Uid=root;" +
                "Pwd=;" +
                "Port=3306");
            try
            {
                conexion.Open();
                MessageBox.Show("conectado");
                conexion.Close();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
            finally { conexion.Close();}
        }

        public static DataTable consulta()
        {
            MySqlConnection conexion = new MySqlConnection(
                   "Server = 127.0.0.1;" +
                   "Database= videoclub;" +
                   "Uid=root;" +
                   "Pwd=;" +
                   "Port=3306");
            DataTable tmp = new DataTable();

            MySqlDataAdapter msj = new MySqlDataAdapter("select name,year from movies", conexion);

            try
            {
                conexion.Open();
                msj.Fill(tmp);
                conexion.Close();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
            finally { conexion.Close(); }

            return tmp;

        }


    }

}