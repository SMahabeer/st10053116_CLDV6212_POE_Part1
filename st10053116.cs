using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using System.Collections.Generic;
using System.Linq;

namespace st10053116_CLDV6212_POE_Part1
{
    public static class st10053116
    {
        public static List<Person> lstPeople = new List<Person>()
        {
            new Person("0201016622189", "Henry", "Avery", true, "Pfizer", Convert.ToDateTime("2023/08/31"), "Dis-Chem Pavillion"),
            new Person("8607137562082", "Nathan", "Drake", true, "Pfizer", Convert.ToDateTime("2023/03/27"), "Dis-Chem La-Lucia"),
            new Person("7705200647086", "Victor", "Sullivan", true, "J&J", Convert.ToDateTime("2022/11/18"), "Dis-Chem Pavillion"),
            new Person("9810313498084", "Samuel", "Drake", true, "J&J", Convert.ToDateTime("2023/08/08"), "Africa Medical Clinic"),
            new Person("9210107281186", "Claire", "Dunphy", false, "Pending", Convert.ToDateTime("2023/01/25"), "Dundee Clinic")
        };

        [FunctionName("st10053116")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string id = req.Query["id"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            id = id ?? data?.id;

            if (id.Length == 13 && id.All(Char.IsDigit)) {
                string responseMessage = GetVaxxInfo(id);
                return new OkObjectResult(responseMessage);
            }
            else
            {
                return new BadRequestObjectResult("Please enter a valid ID number");
            }
        }

        public static string GetVaxxInfo(string id)
        {
            string result = "";
                foreach (var item in lstPeople)
                {
                    if (item.Id.Equals(id))
                    {
                        if (item.Vaxxed == true)
                        {
                            result = "Welcome " + item.Name + " " + item.Surname + "\n\nID number: " + id + "\nVaccination status: " + "Vaxxed" + "\nVaccination type: " + item.VaxxType + "\nVaxx date: " + Convert.ToString(item.Vaxx_Date) + "\nClinic location: " + item.Clinic;
                        }
                        else
                        {
                            result = "Welcome " + item.Name + " " + item.Surname + "\n\nID number: " + id + "\nVaccination status: " + "Not vaxxed" + "\nVaccination type: " + "Pending";
                        }
                        break;
                    }
                }
                if (result.Equals(""))
                {
                    result = "ID number not found";
                }
            return result;
        }
    }
}
