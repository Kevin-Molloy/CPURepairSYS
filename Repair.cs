using Oracle.ManagedDataAccess.Client;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using System.Diagnostics;
using System;

namespace CPURepairSYS
{
    class Repair
    {
        private int repairId;
        private string description;
        private string status;
        private decimal price;
        private string startDate;
        private string completeDate;
        private string repairTypeCode;
        private int custId;

        public Repair()
        {
            repairId = 0;
            description = "";
            status = "";
            price = 0;
            startDate = "";
            completeDate = "";
            repairTypeCode = "";
            custId = 0;
        }

        public Repair(int repairId, string description, string status, decimal price, String startDate, String completeDate, string repairTypeCode, int custId)
        {
            this.repairId = repairId;
            this.description = description;
            this.status = status;
            this.price = price;
            this.startDate = startDate;
            this.completeDate = completeDate;
            this.repairTypeCode = repairTypeCode;
            this.custId = custId;
        }

        public int getRepairId() { return repairId; }
        public string getDescription() { return description; }
        public string getStatus() { return status; }
        public decimal getPrice() { return price; }
        public String getStartDate() { return startDate; }
        public String getCompleteDate() { return completeDate; }
        public string getRepairTypeCode() { return repairTypeCode; }
        public int getCustId() { return custId; }

        public void setRepairId(int repairId) { this.repairId = repairId; }
        public void setDescription(string description) { this.description = description; }
        public void setStatus(string status) { this.status = status; }
        public void setPrice(decimal price) { this.price = price; }
        public void setStartDate(String startDate) { this.startDate = startDate; }
        public void setCompleteDate(String completeDate) { this.completeDate = completeDate; }
        public void setRepairTypeCode(String repairTypeCode) { this.repairTypeCode = repairTypeCode; }
        public void setCustId(int custId) { this.custId = custId; }

        public static int getNextRepairId()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT MAX(RepairId) FROM Repairs";

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
                //increments the id
                nextId = dr.GetInt32(0) + 1;
            }

            //Close db connection
            conn.Close();

            return nextId;
        }

        public void LogRepair()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "INSERT INTO Repairs Values (" +
                 this.repairId + ",'" +
                 this.description + "','" +
                 this.status + "'," +
                 this.price + ",'" +
                 this.startDate + "','" +
                 this.completeDate + "','" +
                 this.repairTypeCode + "'," +
                 this.custId + ")";



            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            cmd.ExecuteNonQuery();

            //Close db connection
            conn.Close();


        }

        public static DataSet findRepair(String type, char status)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT RepairId, Description FROM Repairs " +
                "WHERE UPPER(RepairTypeCode) LIKE UPPER ('%" + type + "%') AND Status = '" + status + "' ORDER BY Description";


            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "repair");

            //Close db connection
            conn.Close();

            return ds;
        }

        //retireves repair properties based on the passed-in id
        public void getRepair(int Id)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT * FROM Repairs WHERE RepairId = " + Id;

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();

            //set the instance variables with values from data reader
            setRepairId(dr.GetInt32(0));
            setDescription(dr.GetString(1));
            setStatus(dr.GetString(2));
            if (dr.IsDBNull(3)) { setPrice(0); }
            else
            {
                setPrice(dr.GetDecimal(3));
            }
            setStartDate(dr.GetValue(4).ToString());
            if (dr.GetValue(5) == null)
            {
                setCompleteDate("");
            }
            setCompleteDate(dr.GetValue(5).ToString());
            setRepairTypeCode(dr.GetString(6));
            setCustId(dr.GetInt32(7));

            //close DB
            conn.Close();
        }



        public static decimal findPrice(int id)
        {

            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT Price FROM Parts " +
                "WHERE PartId = " + id + "AND Status != 'O'";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();


            decimal a = (dr.GetDecimal(0));


            //close DB
            conn.Close();

            return a;
        }

        public void estimateRepairPrice(int custId, int repId, decimal price, Array id, Array qty, Array flag, Array partPrice)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();
            for (int i = 0; i < id.Length; i++)
            {
                int partId = (int)id.GetValue(i);
                int currentQuantity = (int)qty.GetValue(i);
                decimal currentPrice = (decimal)partPrice.GetValue(i);

               

                //This checks if after the iteration of the loop if the qty will be at 0, so it can mark the part as out of stock. This cannot be put in the same if statement
                //as the one above because the one above needs to break before the sql statements further in the method are executed
                if ((int)flag.GetValue(i) == 1)
                {
                    String sqlQueryAlt = "UPDATE Parts SET Status = 'O' WHERE PartId = " + partId;
                    OracleCommand cmdAlt = new OracleCommand(sqlQueryAlt, conn);
                    cmdAlt.ExecuteNonQuery();
                }
                //Inserts data to RepairItems
                String sqlQuery1 = "INSERT INTO RepairItems VALUES (" + repId + "," + partId + "," + currentPrice + "," + currentQuantity + ",'U')";
                OracleCommand cmd = new OracleCommand(sqlQuery1, conn);
                cmd.ExecuteNonQuery();

                //Decrements part quantity
                String sqlQuery2 = "UPDATE Parts SET Quantity = Quantity - " + currentQuantity + " WHERE PartId = " + partId;
                OracleCommand cmd2 = new OracleCommand(sqlQuery2, conn);
                cmd2.ExecuteNonQuery(); 

            }//END OF LOOP

            //Updates price
            String sqlQuery3 = "UPDATE Repairs SET " +
             "Status = 'E', Price = " + price + "WHERE RepairId = " + repId;
            OracleCommand cmd3 = new OracleCommand(sqlQuery3, conn);
            cmd3.ExecuteNonQuery();
            conn.Close();
        }

        public void confirmRepair(int repairId, String date)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();
            String sqlQuery = "UPDATE Repairs SET Status = 'A', StartDate = '" + date + "' WHERE RepairId = " + repairId;
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();


            conn.Close();
        }

        public void denyRepair(int repairId  ,String date)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();

            String sqlQuery = "UPDATE Repairs SET Status = 'X',StartDate = '" + date + "' WHERE RepairId = " + repairId;
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();

            String sqlQuery2 = "UPDATE RepairItems SET Status = 'X', WHERE RepairId = " + repairId;
            OracleCommand cmd2 = new OracleCommand(sqlQuery, conn);
            cmd2.ExecuteNonQuery();

            conn.Close();
        }

        public void completeRepair(int repairId, String date)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();
            String sqlQuery = "UPDATE Repairs SET Status = 'C', CompleteDate = '" + date + "' WHERE RepairId = " + repairId;
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();


            conn.Close();
        }

        public static DataSet listRepairs(String year , String orderBy, int cancelled, int progress)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();

            OracleDataAdapter da;

            /*Show both in progress and cancelled repairs*/
            if (cancelled == 1 && progress == 1)
            {
                String sqlQuery = "SELECT Customers.FName, Customers.SName ,Repairs.Description,Repairs.Status,Repairs.Price,Repairs.StartDate,Repairs.CompleteDate " +
                    "FROM Repairs " +
                    "INNER JOIN Customers ON Repairs.CustId = Customers.CustId WHERE StartDate LIKE '%" + year + "' ORDER BY " + orderBy;
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
          
            /*Show cancelled but not in progress repairs*/
            else if (cancelled == 1 && progress == 0)
            {
                String sqlQuery = "SELECT Customers.FName, Customers.SName ,Repairs.Description,Repairs.Status,Repairs.Price,Repairs.StartDate,Repairs.CompleteDate " +
                    "FROM Repairs " +
                    "INNER JOIN Customers ON Repairs.CustId = Customers.CustId WHERE StartDate LIKE '%" + year + "' AND STATUS = 'C' OR Status = 'X' ORDER BY " + orderBy;
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            /*Show in progress but not cancelled repairs*/
            else if (cancelled == 0 && progress == 1)
            {
                String sqlQuery = "SELECT Customers.FName, Customers.SName ,Repairs.Description,Repairs.Status,Repairs.Price,Repairs.StartDate,Repairs.CompleteDate " +
                    "FROM Repairs " +
                    "INNER JOIN Customers ON Repairs.CustId = Customers.CustId WHERE StartDate LIKE '%" + year + "' AND STATUS NOT LIKE'X' ORDER BY " + orderBy;
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }

            /*Show neither in progress and cancelled repairs*/
            else
            {
                String sqlQuery = "SELECT Customers.FName, Customers.SName ,Repairs.Description,Repairs.Status,Repairs.Price,Repairs.StartDate,Repairs.CompleteDate " +
                    "FROM Repairs " +
                    "INNER JOIN Customers ON Repairs.CustId = Customers.CustId WHERE StartDate LIKE '%" + year + "' AND STATUS = 'C' ORDER BY " + orderBy;
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }

            DataSet ds = new DataSet();
            da.Fill(ds, "repair");

            //Close db connection
            conn.Close();

            return ds;

        }

        public static DataSet getRev(String year, int cancelled)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();

            OracleDataAdapter da;

            /*Include cancelled repairs*/
            if (cancelled ==  1)
            {
                String sqlQuery = "SELECT Description, Price FROM Repairs WHERE Status = 'C' Or Status = 'X' AND CompleteDate LIKE '%" + year + "'";
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }

            /*Doesnt include cancelled repairs*/
            else
            {
                String sqlQuery = "SELECT Description, Price FROM Repairs WHERE Status = 'C'AND CompleteDate LIKE '%" + year + "'";
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }


            DataSet ds = new DataSet();
            da.Fill(ds, "rev");

            //Close db connection
            conn.Close();

            return ds;
        }

        public static Decimal calcRev(String year, int cancelled)
        {
            decimal total = 0;
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();

            OracleDataAdapter da;


            /*Include cancelled repairs*/
            if (cancelled == 1)
            {
                String sqlQuery = "SELECT SUM(Price) FROM Repairs WHERE Status = 'C' OR Status = 'X' AND CompleteDate LIKE '%" + year + "'";
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();

                total = dr.GetDecimal(0);
            }

            /*Doesnt include cancelled repairs*/
            else
            {
                String sqlQuery = "SELECT SUM(Price) FROM Repairs WHERE Status = 'C' AND CompleteDate LIKE '%" + year + "'";
                OracleCommand cmd = new OracleCommand(sqlQuery, conn);

                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();

                total = dr.GetDecimal(0);
            }


            //Close db connection
            conn.Close();

            return total;
        }


    }
}
