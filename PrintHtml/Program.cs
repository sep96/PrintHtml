using Microsoft.Win32;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace PrintHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your Url");
            string url = Console.ReadLine();
            PdfSharpConvert(url);
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
            //Console.ReadKey();
        }
        public static  bool PdfSharpConvert(String html)
        {
            string timeStampForPdfName = DateTime.Now.ToString("yyMMddHHmmssff");
            var url = html ;
            var chromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            var output = Path.Combine(Environment.CurrentDirectory, "printout" + timeStampForPdfName + ".pdf");
            Console.WriteLine("downloding...");
            try
            {
                using (var p = new Process())
                {
                    p.StartInfo.FileName = chromePath;
                    p.StartInfo.Arguments = $"--headless --disable-gpu --print-to-pdf={output} {url}";
                    p.Start();
                    p.WaitForExit();
                }
            }
            catch (Exception sd)
            {

                Console.WriteLine("An err occured");
                return false;
            }
            try
            {
                Console.WriteLine("now Print pdf");
                PdfDocument doc = new PdfDocument();
                doc.LoadFromFile(output);
                doc.Print();
                Console.WriteLine("done.");
                return true;
            }
            catch (Exception sd)
                {

                Console.WriteLine("An err occured");
                return false;
            }
        }
      
    }
}