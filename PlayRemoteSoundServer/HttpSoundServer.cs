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
        public static void HandleSongRequest(string request, string SoundsPath)
        {
            //parse request string
            string songName = SongFromReuestString(request);
            //Concat sound to the path
            string songPath = FileActions.ConcatFilenameToPath(songName, SoundsPath);
            //play the sound
            PlayLocalSound.PlayAll(songPath);
        }
        public static string SongFromReuestString(string request)
        {
            //strip any whitespace
            request = FileActions.ReplaceWhitespace(request, "");
            //split the request on the :
            string[] temp = request.Split(":");
            //return the second in the array
            return temp[1];

        }
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
            //If we arent supported Give info on why not
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
        }
        public static void VerifyPrefixes(string[] prefixes)
        {
            // for example "http://contoso.com:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");
        }
        
        public static HttpListener AddPrefixes(HttpListener listener, string[] prefixes)
        {
            foreach(string prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }
            return listener;
        }
        public static void SimpleListenerExample(string[] prefixes, string SoundsPath)
        {
            //Check for support
            CheckSupport();
            // Verify URI prefixes
            VerifyPrefixes(prefixes);

            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            listener = AddPrefixes(listener, prefixes);
            //start the listener
            listener.Start();
            Console.WriteLine("Listening...");
            //main loop
            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = AwaitRequest(listener);
                HandleRequest(context);
            }
            listener.Stop();
        }

    }
}
