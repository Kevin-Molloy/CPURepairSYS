using CPURepairSYS;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPURepairSYS
{
    class Customer
    {
        private int custId;
        private String fName;
        private String sName;
        private String phone;
        private String email;

        public Customer() { 
        
            custId = 0;
            fName = "";
            sName = "";
            phone = "";
            email = "";
        
        }

        public Customer(int custId, string fName, string sName, String phone, string email)
        {
            this.custId = custId;
            this.fName = fName;
            this.sName = sName;
            this.phone = phone;
            this.email = email;
        }

        public int getCustId()
        {
            return custId;
        }
        public String getFName()
        {
            return fName;
        }
        public String getSName()
        {
            return sName;
        }
        public String getPhone()
        {
            return phone;
        }

        public String getEmail()
        {
            return email;
        }

        public void setCustId(int CustId)
        {
            custId = CustId;
        }

        public void setFName(String FName)
        {
            fName = FName;
        }

        public void setSName(String SName)
        {
           sName = SName;
        }

        public void setPhone(String Phone)
        {
            phone = Phone;
        }

        public void setEmail (String Email)
        {
            email = Email;
        }



        public int findCustomer(String phone, String name)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT CustId, FName, SName, Phone, Email FROM Customers " +
                "WHERE Phone = " + phone + " AND FName = '" + name +"'";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            conn.Open();

            OracleDataReader dr =  cmd.ExecuteReader();


            if (dr.Read()) {
            this.custId= dr.GetInt32(0);
            this.fName = dr.GetString(1);
            this.sName = dr.GetString(2);
            this.phone = dr.GetString(3);
            this.email = dr.GetString(4);
                conn.Close();
                return 0;
            }

            //Close db connection
            conn.Close();

            return 1;
        }
        

        public void getCustomer(int Id)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT CustId FROM Customers WHERE CustId = " + Id;

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();

            //set the instance variables with values from data reader
            setCustId(dr.GetInt32(0));
         


            //close DB
            conn.Close();
        }

        public void AddCustomer()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "INSERT INTO Customers Values (" +
             this.custId + ",'" +
             this.fName + "','" +
             this.sName + "','" +
             this.phone + "','" +
             this.email +  "')";

            //MessageBox.Show(sqlQuery, "TEST", MessageBoxButtons.OK, MessageBoxIcon.Error);


            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            cmd.ExecuteNonQuery();

            //Close db connection
            conn.Close();
        }

        public static int getNextCustId()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT MAX(CustId) FROM Customers";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();

            //Does dr contain a value or NULL?
            int nextId;
            dr.Read();

            if (dr.IsDBNull(0))
                nextId = 1;
            else
            {
                nextId = dr.GetInt32(0) + 1;
            }

            //Close db connection
            conn.Close();

            return nextId;
        }

        public void getCustomerName(int custId)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT FName, SName FROM Customers " +
                "WHERE CustId = " + custId;

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                this.fName = dr.GetString(0);
                this.sName = dr.GetString(1);
            }


            //Close db connection
            conn.Close();

        }


    }
}
