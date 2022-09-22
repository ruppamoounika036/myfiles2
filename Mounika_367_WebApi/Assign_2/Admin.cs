namespace Assign_2;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json; 
using Assign_2.Models;
    static class Admin{
        public static async void GetOrdersByName(string Name){
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("https://localhost:7055/Customer/GetCustomer/"+Name);
            response.EnsureSuccessStatusCode();
            
            var resp =await response.Content.ReadAsStringAsync();
            // Console.WriteLine(resp);
            IList<Customer> cust = JsonConvert.DeserializeObject<IList<Customer>>(resp);
            // cust.ForEach(Console.WriteLine)
            foreach(var c in cust){
                Console.WriteLine("Customer Name : {0}",c.Name);
                Console.WriteLine("Customer Ordered Time : {0}",c.OrderedTime);
                Console.WriteLine("Package Name : {0}",c.PackageName);
                Console.WriteLine("The Items you ordered are:");
                foreach(var it in c.items){
                    Console.WriteLine(it);
                }
            }
        }
        public static async void GetOrdersByTime(){
            //
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("https://localhost:7055/Customer/GetCustomerByTime");
            response.EnsureSuccessStatusCode();
            
            var resp =await response.Content.ReadAsStringAsync();
            // Console.WriteLine(resp);
            IList<Item> items = JsonConvert.DeserializeObject<IList<Item>>(resp);
            // cust.ForEach(Console.WriteLine)
            foreach(var c in items){
                Console.WriteLine("OrderId : {0}  ,  Item.Name : {1}",c.Oid,c.Iname);
            }
        }
        public static void ChooseOption(){
            int opt;
            Console.WriteLine("Enter Your choice:");
            Console.WriteLine("1.All Orders in last one hour \n2.Orders placed by a customer ");
            opt = Input.GetInputInt();
            switch(opt){
                case 1:
                GetOrdersByTime();
                break;
                case 2:
                Console.WriteLine("Enter the customer name");
                string Name = Input.GetInputString();
                GetOrdersByName(Name);
                break;
                default:
                Console.WriteLine("Enter a valid input");
                break;
            }
        }
    }