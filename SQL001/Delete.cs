using Microsoft.Data.SqlClient;
class Delete
{

    static void Main()
    {

        string cs = "Data Source=GOPALAKRISHNA\\SQLEXPRESS;Initial Catalog = TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        string sql = @"DELETE FROM dbo.Employees WHERE EmployeeId=@id";

        Console.Write("EmployeeId to delete: "); int id = int.Parse(Console.ReadLine() ?? "0");

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows == 1 ? "🗑️ Deleted" : "⚠️ Not found");
    }
}