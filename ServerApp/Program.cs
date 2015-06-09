/* 
* Svrha ovog programa je primer koriscenja UDP za primanje podataka.
* Prima poruke sa klijenta i prikazuje ih u prozoru.
* Radi sa programom UDP_minimum_talker
* Pokrenu se oba programa i salju se poruke sa klijenta
* Moguce je vise klijenta
*/
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
public class UDPListener
{
    private const int listenPort = 11000;
    public static int Main()
    {
        bool done = false;
        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
        string received_data;
        byte[] receive_byte_array;
        try
        {
            while (!done)
            {
                Console.WriteLine("Cekanje poruke");
                // Prijem poruke
                // Poziva funkciju recieve od listenera iz klase UDPListener
                // Prosledjuje odsluskivacu groupEP - endpoint
                // It puts the data from the broadcast message into the byte array
                // Pretvara podatke poruke u niz bajtova recieved_byte_array
                receive_byte_array = listener.Receive(ref groupEP);
                Console.WriteLine("Primljena poruka od {0}", groupEP.ToString());
                received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                Console.WriteLine("data follows \n{0}\n\n", received_data);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        listener.Close();
        return 0;
    }
}
