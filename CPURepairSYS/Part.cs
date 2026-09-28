using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CPURepairSYS
{
    class Part
    {
        private int partId;
        private String description;
        private decimal price;
        private int quantity;
        private String status;
        private String partTypeCode;

     

        public Part() 
        { 
        this.partId = 0;
        this.description = "";
        this.price = 0;
        this.quantity = 0;
        this.status = "";
        this.partTypeCode = "";
        }

        public Part(int partId, string description, decimal price, int quantity,string status, string partTypeCode)
        {
            this.partId = partId;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
            this.status = status;
            this.partTypeCode = partTypeCode;
        }

   

        public int getPartId() {return this.partId;}
        public String getDescription() {return this.description;}

        public decimal getPrice() {return this.price;}

        public int getQuantity() {return this.quantity;}

        public String getStatus() { return this.status; }

        public String getPartTypeCode() {return this.partTypeCode;}


        public void setPartId(int PartId) {this.partId = PartId;}
        public void setDescription(String Description) { this.description = Description;}

        public void setPrice(Decimal Price) {this.price = Price;}

        public void setQuantity(int Quantity) {this.quantity = Quantity;}

        public void setStatus(String Status) { this.status = Status; }

        public void setPartTypeCode(String PartTypeCode) {this.partTypeCode = PartTypeCode;}

        public static int getNextPartId()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT MAX(PartId) FROM Parts";

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
                //Increments id
                nextId = dr.GetInt32(0) + 1;
            }

            //Close db connection
            conn.Close();

            return nextId;
        }
        public void AddPart()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "INSERT INTO Parts Values (" +
             this.partId + ",'" +
             this.description + "','" +
             this.price + "','" +
             this.quantity + "','" +
             this.status + "','" +
             this.partTypeCode + "')";



            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            cmd.ExecuteNonQuery();

            //Close db connection
            conn.Close();
        }

        public static DataSet findPart(String desc)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT PartId, Description, Price FROM Parts " +
                "WHERE UPPER(Description) LIKE UPPER('%" + desc + "%') ORDER BY Description";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "part");

            //Close db connection
            conn.Close();

            return ds;
        }

        //A find part method specifically for the estimatePrice form
        public static DataSet estFindPart(String desc)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT PartId, Description, Price, Quantity FROM Parts " +
                "WHERE UPPER(Description) LIKE UPPER('%" + desc + "%') AND Status = 'A' ORDER BY Description";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "part");

            //Close db connection
            conn.Close();

            return ds;
        }

        //a find part method specifically for the discontinuePart form
        public static DataSet disFindPart(String desc)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT PartId, Description, Price FROM Parts " +
                "WHERE UPPER(Description) LIKE UPPER('%" + desc + "%') AND Status != 'D' ORDER BY Description";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "part");

            //Close db connection
            conn.Close();

            return ds;
        }

        //retrieves a part and its properties based on the passed-in id
        public void getPart(int Id)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT * FROM Parts WHERE PartId = " + Id;

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();

            //set the instance variables with values from data reader
            setPartId(dr.GetInt32(0));
            setDescription(dr.GetString(1));
            setPrice(dr.GetDecimal(2));
            setQuantity(dr.GetInt32(3));
            setStatus(dr.GetString(4));
            setPartTypeCode(dr.GetString(5));

            //close DB
            conn.Close();
        }

        public void updatePart()
        {
           //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "UPDATE Parts SET " +
                "PartId = " + this.partId + "," +
                "Description = '" + this.description + "'," +
                "Price = " + this.price + "," +
                "Quantity = " + this.quantity + "," +
                "Status = '" + this.status + "'," +
                "PartTypeCode = '" + this.partTypeCode + "' " +
                "WHERE PartId = " + this.partId;

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);



            conn.Open();
            cmd.ExecuteNonQuery();

            //Close db connection
            conn.Close();

         
        }

        public void discontinuePart()
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            this.status = "D";
            String sqlQuery = "UPDATE Parts SET " +
                "Status = '" + this.status + "'" +
                " WHERE PartId = " + this.partId;

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);



            conn.Open();
            cmd.ExecuteNonQuery();

            //Close db connection
            conn.Close();
        }

        public static DataSet analyseParts(String year, String orderBy, int discontinued, int oos)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();

            OracleDataAdapter da;

            /*OOS == OUTOFSTOCK*/
            /*Show both oos and discontinued parts*/
            if (discontinued == 1 && oos == 1)
            {
                String sqlQuery = "SELECT Parts.Description AS PartDesc, Parts.Quantity QtyInStock, RepairItems.QuantityUsed AS QtyUsed ,Repairs.Description AS RepairDesc " +
                                   "FROM RepairItems " +
                                   "INNER JOIN Repairs ON RepairItems.RepairId = Repairs.RepairId " +
                                   "INNER JOIN Parts ON RepairItems.PartId = Parts.PartId " +
                                   " WHERE Repairs.StartDate LIKE '%" + year + "' ORDER BY Parts." + orderBy; 
                
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }

            /*Show disconitnued but oos parts*/
            else if (discontinued == 1 && oos == 0)
            {
                String sqlQuery = "SELECT Parts.Description AS PartDesc, Parts.Quantity QtyInStock, RepairItems.QuantityUsed AS QtyUsed ,Repairs.Description AS RepairDesc " +
                                   "FROM RepairItems " +
                                   "INNER JOIN Repairs ON RepairItems.RepairId = Repairs.RepairId " +
                                   "INNER JOIN Parts ON RepairItems.PartId = Parts.PartId " +
                                   " WHERE Repairs.StartDate LIKE '%" + year + "' AND Parts.Status = 'A' OR Parts.Status = 'D' ORDER BY Parts." + orderBy; 
                
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            /*Show oos but not disconitnued parts*/
            else if (discontinued == 0 && oos == 1)
            {
                String sqlQuery = "SELECT Parts.Description AS PartDesc, Parts.Quantity QtyInStock, RepairItems.QuantityUsed AS QtyUsed ,Repairs.Description AS RepairDesc " +
                   "FROM RepairItems " +
                   "INNER JOIN Repairs ON RepairItems.RepairId = Repairs.RepairId " +
                   "INNER JOIN Parts ON RepairItems.PartId = Parts.PartId " +
                   " WHERE Repairs.StartDate LIKE '%" + year + "' AND Parts.Status = 'A' OR Parts.Status = 'O' ORDER BY Parts." + orderBy;
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }

            /*Show neither oos or disconitnued parts*/
            else
            {
                String sqlQuery = "SELECT Parts.Description AS PartDesc, Parts.Quantity QtyInStock, RepairItems.QuantityUsed AS QtyUsed ,Repairs.Description AS RepairDesc " +
                    "FROM RepairItems " +
                    "INNER JOIN Repairs ON RepairItems.RepairId = Repairs.RepairId " +
                    "INNER JOIN Parts ON RepairItems.PartId = Parts.PartId " +
                    " WHERE Repairs.StartDate LIKE '%" + year + "' AND Parts.Status = 'A' ORDER BY Parts." + orderBy;
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }



            DataSet ds = new DataSet();
            da.Fill(ds, "part");

            //Close db connection
            conn.Close();

            return ds;
        }


    }
}
