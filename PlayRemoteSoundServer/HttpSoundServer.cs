using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlayRemoteSoundServer
{
    class HttpSoundServer
    {
        public static void StartServer(int port, string address)
        {
            
        }
        public static void Test(int port, string address)
        {

        }
        public static HttpListenerContext AwaitRequest(HttpListener listener)
        {
            Console.WriteLine("Awaiting Request");
            HttpListenerContext context = listener.GetContext();
            Console.WriteLine("Got Request");
            return context;
        }
        public static void HandleRequest(HttpListenerContext context)
        {
            Console.WriteLine("Handling Request");
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            string text;
            using (var reader = new StreamReader(request.InputStream,
                                                 request.ContentEncoding))
            {
                text = reader.ReadToEnd();
            }
            Console.WriteLine(text);
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }
        public static void CheckSupport()
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
        }
        public static void SimpleListenerExample(string prefixes)
        {
            
            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            listener.Prefixes.Add(prefixes);
            listener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request.
            HttpListenerContext context = AwaitRequest(listener);
            HandleRequest(context);
            listener.Stop();
        }

    }
}
