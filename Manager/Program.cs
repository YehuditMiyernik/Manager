// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        string connectionString = "Data Source=srv2\\pupils;Initial Catalog=Products_DB;Integrated Security=True";
        DataAccess da = new DataAccess();

        //int rowsProd = da.insertProduct(connectionString);
        //Console.WriteLine(rowsProd + " Added to DB");

        //da.DisplayProd(connectionString);

        int rowsCategory = da.insertCategory(connectionString);
        Console.WriteLine(rowsCategory + " Added to DB");

        //da.DisplayCategory(connectionString);
    }
}


