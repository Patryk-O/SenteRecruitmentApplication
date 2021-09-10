using Newtonsoft.Json;
using RestSharp;
using SenteRecruitmentApplication.Data;
using System;

namespace SenteRecruitmentApplication
{
    class Program
    {
        public static string[] BankAccountInfo(string Nip)
        {
            string[] error = { "" };
            var date = DateTime.Now.ToString("yyyy-MM-dd");

            var client = new RestClient("https://wl-api.mf.gov.pl/api/search/nip");
            var request = new RestRequest($"{Nip}?date={date}");

            var response = client.Execute(request);

            Company company = JsonConvert.DeserializeObject<Company>(response.Content);

            if(company.Result is null)
            {   
                Console.WriteLine("Podales zly nip");
                return error;
            }
            if(company.Result.Subject is null)
            {
                Console.WriteLine("Firma nie posiada wpisanego konta bankowego");
                return error;
            }
            return company.Result.Subject.AccountNumbers; 
        }
        static void Main(string[] args)
        {
            string Nip;
            bool run = true;

            while (run)
            {
                
                Console.WriteLine("Program wyswietla numery bankowe firm po wprowadzeniu nr NIP\n");
                Console.WriteLine("Podaj nr NIP: ");

                Nip = Console.ReadLine();
                Console.WriteLine();

                var banknr = BankAccountInfo(Nip);

                foreach (var i in banknr)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
                Console.WriteLine("Chcesz wyjsc? y/n");

                string exit = Console.ReadLine();
                if (exit == "y")
                    run = false;
            }
        }
    }
}
