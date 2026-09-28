using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPURepairSYS
{
    class RepairTypeCode
    {
        String repairTypeCode;
        String description;

        public RepairTypeCode(String repairTypeCode, String description)
        {
            this.repairTypeCode = repairTypeCode;
            this.description = description;
        }


        public static DataSet getRepairTypeCodes()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT * FROM RepairTypeCodes ORDER BY RepairTypeCode";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "RT");

            //Close db connection
            conn.Close();

            return ds;
        }
    }
}
