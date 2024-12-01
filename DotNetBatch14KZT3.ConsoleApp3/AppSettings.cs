using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KZT3.ConsoleApp3;

public static class AppSettings
{
    public static SqlConnectionStringBuilder connBuilder { get; } = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "test_db",
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true,
    };
}
