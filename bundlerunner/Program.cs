using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace bundlerunner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Program.RunningInstance() != null)
            {
                System.Environment.Exit(0);
            }
            string line;
            Process secondProc;
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(@"path.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("!"))
                    {
                        continue;
                    }
                    System.Console.WriteLine(line);
                    secondProc = new Process();
                    secondProc.StartInfo.FileName = line;
                    try
                    {
                        secondProc.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Oops: " + ex.Message);
                    }

                }
                file.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("Please create file path.txt in the same folder where is  PoE and this program \n and save there paths to the exe, ahk, jar etc files you want to start\nline\nby\nline\nIf the line start with !-Character, it will be ignored.");
            }


            Console.WriteLine("\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2584\u2584\u2584\u2580\u2580\u2580\u2584\u2584\u2588\u2588\u2588\u2584\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\r\n\u2591\u2591\u2591\u2591\u2591\u2584\u2580\u2580\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2590\u2591\u2580\u2588\u2588\u258C\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\r\n\u2591\u2591\u2591\u2584\u2580\u2591\u2591\u2591\u2591\u2584\u2584\u2588\u2588\u2588\u2591\u258C\u2580\u2580\u2591\u2580\u2588\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\r\n\u2591\u2591\u2584\u2588\u2591\u2591\u2584\u2580\u2580\u2592\u2592\u2592\u2592\u2592\u2584\u2590\u2591\u2591\u2591\u2591\u2588\u258C\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\r\n\u2591\u2590\u2588\u2580\u2584\u2580\u2584\u2584\u2584\u2584\u2580\u2580\u2580\u2580\u258C\u2591\u2591\u2591\u2591\u2591\u2590\u2588\u2584\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\r\n\u2591\u258C\u2584\u2584\u2580\u2580\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u258C\u2591\u2591\u2591\u2591\u2584\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2584\u2591\u2591\u2591\u2591\u2591\u2591\r\n\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2590\u2591\u2591\u2591\u2591\u2590\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2584\u2591\u2591\u2591\r\n\u2591\u2591\u2591\u2591\u2591le\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2590\u2591\u2591\u2591\u2591\u2590\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2584\r\n\u2591\u2591\u2591\u2591toucan\u2591\u2591\u2591\u2591\u2591\u2591\u2580\u2584\u2591\u2591\u2591\u2590\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2584 \r\n\u2591\u2591\u2591\u2591\u2591\u2591has\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2580\u2584\u2584\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588 \r\n\u2591\u2591\u2591\u2591\u2591arrived\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2588\u2580\u2588\u2588\u2588\u2588\u2588\u2588\u2591\u2591");
            
            System.Console.ReadLine();
        }

        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //Loop through the running processes in with the same name 
            foreach (Process process in processes)
            {
                //Ignore the current process 
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file. 
                    if (Assembly.GetExecutingAssembly().Location.
                         Replace("/", "\\") == current.MainModule.FileName)

                    {
                        //Return the other process instance.  
                        return process;

                    }
                }
            }
            //No other instance was found, return null.  
            return null;
        }
    }
}
