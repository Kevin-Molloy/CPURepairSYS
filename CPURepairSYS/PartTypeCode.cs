using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPURepairSYS
{
    class PartTypeCode
    {
        String partTypeCode;
        String description;

        public PartTypeCode(String partTypeCode, String description)
        {
        this.partTypeCode = partTypeCode;
        this.description = description;
        }


        public static DataSet getPartTypeCodes()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT * FROM PartTypeCodes ORDER BY PartTypeCode";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "PT");

            //Close db connection
            conn.Close();

            return ds;
        }
    }

}
