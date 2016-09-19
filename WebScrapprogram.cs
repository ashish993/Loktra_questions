using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


    class WebScrapProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Choice\n1.Enter Keyword\n2. Enter Page then Keyword\n");
            
            string keyword="", url="";
            int page=0;
            int choice = Convert.ToInt32(Console.ReadLine());
         switch (choice)
         {
            case 1:
                       Console.WriteLine("Enter Keyword");
               keyword=(Console.ReadLine());
                 url="http://www.shopping.com/products?KW="+keyword;
                 webscrap(url);
                 
               break;
            case 2:
                 Console.WriteLine("Enter Page No");
               page=Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter Keyword");
               keyword=(Console.ReadLine());
               url = "http://www.shopping.com/products~PG-" + page + "?KW=" + keyword;
               webscrap(url);
                 break;
               default:
            Console.WriteLine("Incorrect choice");
               break;
        }
         Console.ReadKey();
        }
        public static void webscrap(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string htmlText = reader.ReadToEnd();
            reader.Close();
            MatchCollection m1 = Regex.Matches(htmlText, @"(?<=<a rel=""nofollow"" class=""productName""[^>]*>).*?(?=</span>)", RegexOptions.Singleline);
            if (m1.Count > 0)
            {
                for (int j = 0; j < m1.Count; j++)
                {
                    Console.WriteLine("Total " + m1.Count + " Products found in this page");
                    Console.WriteLine(m1[j].ToString());
                }
            }
        }     
    }