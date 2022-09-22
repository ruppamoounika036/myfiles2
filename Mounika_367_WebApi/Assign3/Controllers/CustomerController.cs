namespace Assign3.Controllers;
using Assign_2;
using System;
using System.Collections.Generic;
using System.Linq;
using Assign_2.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Customer")]
public class CustomerController : ControllerBase
{
    private readonly AMAZONDBContext con = new AMAZONDBContext();

    [HttpGet("GetCustomer/{Name}")]
    public IList<CustomerDetails> GetCustomerName(string Name)
    {
        var c =  con.Customers.Where(c => c.Cname == Name).First();
        var ord = con.Orders.Where(o=>o.Cid==c.Cid).ToList();
        int olen = ord.Count();
        CustomerDetails[] cd = new CustomerDetails[olen];
        int j=0; 
        foreach(var orderr in ord){
            var coItems = con.Items.Where(i=> i.Oid == orderr.Oid).ToList();
            var payment = con.Pays.Where(p=>p.Oid==orderr.Oid).First();
            int l = coItems.Count();
            string[] items = new string[l];
            double[] items_qnt = new double[l];
            decimal[] items_price = new decimal[l];
            bool[] idisc = new bool[l];
            for(int i=0;i<l;i++){
                items[i] = coItems[i].Iname;
                items_qnt[i] = coItems[i].Iquant;
                items_price[i] = coItems[i].Iprice;
                idisc[i] = coItems[i].Idiscount;
            }
            cd[j] = new CustomerDetails(){
                name = c.Cname,
                items = items,
                items_qnt = items_qnt,
                items_price = items_price,
                payable = (double)payment.Payable,
                Otime = orderr.Otime,
                item_disc = idisc,
                startTime = c.StartDate,
                endTime = c.EndDate,
                packageName = orderr.PackageName,
                pincode = orderr.Pincode,
                pay = orderr.PayMode
            };
            j++; 
        }
        return cd;
    }
     [HttpPost("PostCustomerDetails")]
    public IActionResult PostCustomerDetails([FromBody] CustomerDetails cust){
        var c = new Customer(){
            Cname = cust.name,
            StartDate = cust.startTime,
            EndDate = cust.endTime
        };
        var o = new Order(){
            PackageName = cust.packageName,
            Pincode = (int)cust.pincode,
            Cid = c.Cid,
            PayMode = cust.pay,
            Otime = cust.Otime
        };
        c.Orders.Add(o);
        con.SaveChanges();
        int count = cust.items.Length;
        Item[] item = new Item[count];
        for(int i=0;i<count;i++){
            item[i] = new Item(){
                Iname = cust.items[i],
                Iprice = Convert.ToDecimal(cust.items_price[i]),
                Iquant = Convert.ToInt32(cust.items_qnt[i]),
                Idiscount = cust.item_disc[i],
                Oid = o.Oid
            };
            o.Items.Add(item[i]);
            con.SaveChanges();
        }
        var pay = new Pay(){
            Payable = Convert.ToInt32(cust.payable),
            Cid = c.Cid,
            Oid = o.Oid
        };
        o.Pays.Add(pay);
        c.Pays.Add(pay);
        con.Customers.Add(c);
        con.Orders.Add(o);
        con.Items.AddRange(item);
        con.Pays.Add(pay);
        con.SaveChanges();
        return Ok();
    }
   
}