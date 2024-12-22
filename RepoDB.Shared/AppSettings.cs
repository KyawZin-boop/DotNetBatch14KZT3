using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace RepoDB.Shared;

public class AppSettings
{
    public static SqlConnectionStringBuilder _connBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "test_db",
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true
    };
}
