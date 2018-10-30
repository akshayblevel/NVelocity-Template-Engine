using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVelocity;
using NVelocity.App;
using System.IO;

namespace NVelocityTemplateEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VelocityEngine fileEngine = new VelocityEngine();
                fileEngine.Init();

                VelocityContext context = new VelocityContext();
                context.Put("UserFirstName", "Akshay");
                context.Put("UserLastName", "Patel");
                context.Put("Company", "Dotnetbees");

                var writer = new StringWriter();
                string path = @""+ Environment.CurrentDirectory + "\\Template\\Demo.vm";
                StreamReader sr = new StreamReader(path);
                string templateString = sr.ReadToEnd();
                sr.Close();

                fileEngine.Evaluate(context, writer, null, templateString);

                Console.WriteLine(writer.GetStringBuilder().ToString());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
