/* 
* Minimalni primer UDP za slanje podataka
* Prenosi poruku paketa i prikazuje tekst u konzoli
* radi sa programom UDP_Minimum_listener
*/
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Boolean done = false;
        Boolean exception_thrown = false;
        #region comments
        // Kreiranje socketa. Fundamentalna stvar za mrezne komunikacije. Specificiraju se:
        // Internetwork: koji se koristi za internet komunikacije
        // Dgram - datagram za emitovanje svima radije nego specificnom odsluskivacu
        // UDP: poruke su formirane kao user datagram protocol.
        #endregion
        Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
        ProtocolType.Udp);
        #region comments
        // kreiranje adrese kojoj se zadaje adresa na koju se konektujemo pri slanju podataka
        #endregion
        IPAddress send_to_address = IPAddress.Parse("192.168.40.201");
        #region comments
        // IPEndPoint je klasa koja oznacava prvi i poslendji objekat u komunikaciji
        // U njoj su sadrzane IP adresa i port koji se koriste.
        #endregion
        IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);

        Console.WriteLine("Unos teksta za prenos preko UDP.");
        Console.WriteLine("Prazna linija za izlaz iz programa");
        while (!done)
        {
            Console.WriteLine("Tekst za slanje, prazna linija za izlaz");
            string text_to_send = Console.ReadLine();
            if (text_to_send.Length == 0)
            {
                done = true;
            }
            else
            {
                // socket mora imati tekst za slanje
                // ucitava se string koji se pretvara u niz bajtova.
                byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);

                // Gde se salje.
                Console.WriteLine("slanje na adresu: {0} port: {1}",
                sending_end_point.Address,
                sending_end_point.Port);
                try
                {
                    sending_socket.SendTo(send_buffer, sending_end_point);
                }
                catch (Exception send_exception)
                {
                    exception_thrown = true;
                    Console.WriteLine(" Greska {0}", send_exception.Message);
                }
                if (exception_thrown == false)
                {
                    Console.WriteLine("Poruka nije poslata na adresu");
                }
                else
                {
                    exception_thrown = false;
                    Console.WriteLine("Greska ukazuje na to da poruka nije poslata.");
                }
            }
        }
    }
}
