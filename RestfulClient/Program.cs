using System;
using Newtonsoft.Json;
using RestfulClient.Entities;
using RestSharp;

namespace RestfulClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var request = new RestRequest("api/values", Method.POST, DataFormat.Json);
                var client = new RestClient(@"http://localhost:8080");
                var user = new RestfulUser { AppName = "yaojie", AppPwd = "dddddd" };

                request.AddJsonBody(user);
                var remsg = client.Execute(request);
                var response = client.Post<RestfulResult>(request);

                Console.WriteLine(remsg.Content);
                Console.WriteLine();
                Console.WriteLine(JsonConvert.SerializeObject(response.Data));

                request = new RestRequest("api/Home", Method.POST);
                request.AddQueryParameter("name", "神奇女侠");
                request.AddQueryParameter("pwd", "yingmie"); 
                var resp = client.Execute(request);
                Console.WriteLine(resp.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
