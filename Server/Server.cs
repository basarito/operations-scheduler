using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket serverSoket;
        List<ObradaKlijenta> klijenti;
        bool isKraj = false;

        public void PokreniServer()
        {
            try
            {
                isKraj = false;
                klijenti = new List<ObradaKlijenta>();

                Console.WriteLine("Starting server...");
                serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSoket.Bind(new IPEndPoint(IPAddress.Any, 9000));
                serverSoket.Listen(5);

                while (!isKraj)
                {
                    Console.WriteLine("Listening for clients....");
                    Socket klijentSoket = serverSoket.Accept();
                    Console.WriteLine("Client connected!");
                    klijenti.Add(new ObradaKlijenta(klijentSoket, klijenti));
                }
            }
            catch (Exception)
            {
                
            }
        }

        public void ZaustaviServer()
        {
            isKraj = true;
            try
            {
                klijenti.ForEach(k => k.PosaljiKraj());
                serverSoket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception: " + ex.Message);
            } finally
            {
                Console.WriteLine(klijenti?.Count);
            }
        }


    }
}
