using Newtonsoft.Json;
using System;
using System.Net.Sockets;

public class Movie
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
}

public class Client
{
    public static void Main()
    {
        try
        {
            Int32 port = 13000;
            TcpClient client = new TcpClient("127.0.0.1", port);

            Movie movie = new Movie
            {
                Title = "The Godfather",
                Year = 1972,
                Director = "Francis Ford Coppola"
            };

            string movieJson = JsonConvert.SerializeObject(movie);

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(movieJson);

            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", movieJson);

            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.Read();
    }
}
