﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; 
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace PagoElectronico.Model
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }

        private void Database_Load(object sender, EventArgs e)
        {

        }
            
       private SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD1C2015;Persist Security Info=True;User ID=gd;Password=gd2015");
        //private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionHotel"].ConnectionString);
        
       

        public void openConnection() {
            conexion.Open();
        }

        public void closeConnection() { conexion.Close(); }
        
        public DataTable select_query(String query) {

            try
            {
                conexion.Open();
                SqlCommand queryCommand = new SqlCommand(query, conexion);
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(queryCommandReader);
                conexion.Close();
                return dataTable;
            }
            catch (Exception ex) {

                MessageBox.Show( ex.Message + " Query: " + query );
                
            }

            return new DataTable();  
        }

        

        public void insert_query(String query) {
            try
            {
                conexion.Open();
                SqlCommand queryCommand = new SqlCommand(query, conexion);
                queryCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("Fallo al ejectuar la query : " + query);
            }
        }

        public void update_query(String query) { this.insert_query(query); }
        public void delete_query(String query) { this.insert_query(query); }



    }
}
