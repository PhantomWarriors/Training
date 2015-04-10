using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    /// <summary>
    /// This TCP server which is connected to the database. 
    /// This server handles all requests from client and is a link between the database and client.
    /// </summary>
    class Program
    {
        static TcpListener tcpListener; 
        static Thread listenThread;
        static List<TcpClient> clients = new List<TcpClient>(); 
        static List<NetworkStream> netStreams = new List<NetworkStream>();
        static List<Person.Person> people;
        static string result;
        static Person.CRUD crud;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Server Started...");
                tcpListener = new TcpListener(IPAddress.Any, 1000);
                listenThread = new Thread(new ThreadStart(ListenThread));
                listenThread.Start();
                crud = new Person.CRUD();
                people = new List<Person.Person>();
                people = crud.ReadAll();
                //people.Add(new Person.Man(1, "Igor", "Weak", 25, 20));
                //people.Add(new Person.Woman(2, "Margo", 10, "Gree", "Sha"));
                //people.Add(new Person.Man(3, "Seva", "Weak", 5, 2));
                //people.Add(new Person.Woman(4, "Rita", 10, "Grey", "Fa"));
                //crud.Create(people);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                Disconnect();
            }
        }
        /// <summary>
        /// Close the server
        /// </summary>
        static void Disconnect()
        {
            tcpListener.Stop(); 
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); 
                netStreams[i].Close();
            }
            Environment.Exit(0); 
        }
        /// <summary>
        /// Send data to a client
        /// </summary>
        /// <param name="id"></param>
        static void SendDataToClient(int id)
        {
            for (int i = 0; i < netStreams.Count; i++)
            {
                if (id == i)
                {
                    byte[] toSend = Encoding.ASCII.GetBytes(result);
                    netStreams[i].Write(toSend, 0, toSend.Length); 
                    netStreams[i].Flush();
                }
            }

        }
        /// <summary>
        /// Prepare the data for a client
        /// </summary>
        /// <returns></returns>
        static string DataPreparation()
        {
            string str=null;

            for (int i = 0; i < people.Count; i++)
                {
                    str=str+people[i].WriteCSV(people[i])+",";
                }

                return str;
        }
        /// <summary>
        /// Method for obtaining and processing the client's request
        /// </summary>
        /// <param name="ID"></param>
        static void ClientRequest(object ID)
        {
            int thisID = (int)ID;
            byte[] requestB = new byte[64];
            string request = null;       
            while (true)
            {
                try
                {
                    netStreams[thisID].Read(requestB, 0, 64);
                }
                catch
                {
                    Console.WriteLine("Client with ID: " + thisID + " has Disconnected!");
                    break;
                }
                request = Encoding.ASCII.GetString(requestB);
                request=request.Replace("\0", string.Empty);
                var strArr = request.Split(',');
                switch (strArr[0])
                {
                    case"<All data> ":
                        result = DataPreparation();
                        SendDataToClient(thisID);
                        break;
                    case"<Delete>":
                        string str = strArr[1];
                        str = str.Replace(" ", string.Empty);
                        crud.Delete(Convert.ToInt32(str));
                        break;
                    case"<Update> ":

                        if (strArr[9]=="True")
                        {
                            var per = new Person.Man(Convert.ToInt32(strArr[1]), strArr[2], strArr[3], Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5]));
                            crud.Update(Convert.ToInt32(strArr[1]), per);
                        }
                        else if (strArr[9] == "False")
                        {
                            var per = new Person.Woman(Convert.ToInt32(strArr[1]), strArr[2], Convert.ToInt32(strArr[6]), strArr[7], strArr[8]);
                            crud.Update(Convert.ToInt32(strArr[1]), per);
                        }                      
                        break;
                    case"<Add> ":
                        if (strArr[9] == "True")
                        {
                           var p = new List<Person.Person>();
                           p.Add(new Person.Man(Convert.ToInt32(strArr[1]), strArr[2], strArr[3], Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5])));
                           crud.Create(p);
                        }
                        else if (strArr[9] == "False" || strArr[9] == "")
                        {
                            var p = new List<Person.Person>();
                            p.Add(new Person.Woman(Convert.ToInt32(strArr[1]), strArr[2], Convert.ToInt32(strArr[6]), strArr[7], strArr[8]));
                            crud.Create(p);
                        }       
                        break;
                }
                for (int i = 0; i < 64; i++)
                {
                    requestB[i] = 0;
                }
            }
        }

        /// <summary>
        /// Method which is listening port 1000
        /// </summary>
        static void ListenThread()
        {
            tcpListener.Start(); 
            while (true)
            {
                clients.Add(tcpListener.AcceptTcpClient());
                netStreams.Add(clients[clients.Count - 1].GetStream());

                Thread clientThread = new Thread(new ParameterizedThreadStart(ClientRequest));
                clientThread.Start(clients.Count - 1);
            }
        }
    }
}
