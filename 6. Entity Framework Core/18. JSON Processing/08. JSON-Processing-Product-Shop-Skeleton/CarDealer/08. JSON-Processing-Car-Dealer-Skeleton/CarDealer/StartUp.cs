using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            // Problem 1
            //var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, inputJson)); 

            // Problem 2
            var inputJson = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(context, inputJson));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert
                .DeserializeObject<Part[]>(inputJson);
            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }
    }
}