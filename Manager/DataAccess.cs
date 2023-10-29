// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Data.SqlClient;
class DataAccess
{
    public int insertProduct(string connectionString)
    {
        string X = "y";
        int rowAffected = 0;
        while (X == "y" ||  X == "Y")
        {
            string ProdName, Price, Image, CategoryId;
            Console.WriteLine("insert product name");
            ProdName = Console.ReadLine();
            Console.WriteLine("insert price");
            Price = Console.ReadLine();
            Console.WriteLine("insert image");
            Image = Console.ReadLine();
            Console.WriteLine("insert categoryId");
            CategoryId = Console.ReadLine();
            string query = "INSERT INTO Products(ProdName, Price, ProdImage, CategoryId) " +
                "VALUES(@ProdName, @Price, @prodImage, @CategoryId)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ProdName", SqlDbType.VarChar, 20).Value = ProdName;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
                cmd.Parameters.Add("@ProdImage", SqlDbType.VarChar, 20).Value = Image;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;

                con.Open();
                rowAffected += cmd.ExecuteNonQuery();
                con.Close();                
            }
            Console.WriteLine("Would you like to contiue? press y/n");
            X = Console.ReadLine();
        }
        return rowAffected;
    }
    public int insertCategory(string connectionString)
    {
        string X = "y";
        int rowAffected = 0;
        while (X == "y" || X == "Y")
        {
            string CategoryName;
            Console.WriteLine("insert Category name");
            CategoryName = Console.ReadLine();
            string query = "INSERT INTO Category(CategoryName) " +
                "VALUES(@CategoryName)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 20).Value = CategoryName;

                con.Open();
                rowAffected += cmd.ExecuteNonQuery();
                con.Close();
            }
            Console.WriteLine("Would you like to contiue? press y/n");
            X = Console.ReadLine();
        }
        return rowAffected;
    }
    public void DisplayProd(string connectionString)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        using (con)
        {
            SqlCommand cmd = new SqlCommand("select* from Products", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("prodId\tprodName\t\tprice\timage");
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                }
            }
            else
                Console.WriteLine("No rows found");
            reader.Close();
        }
    }

    public void DisplayCategory(string connectionString)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        using (con)
        {
            SqlCommand cmd = new SqlCommand("select* from Category", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("Id\tCategoryName");
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                }
            }
            else
                Console.WriteLine("No rows found");
            reader.Close();
        }
    }
}

