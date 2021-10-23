using CarDealer.Data;
using CarDealer.DTO.Input;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using CarDealer.Models;
using System.Collections.Generic;
using CarDealer.DTO.Output;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            // Query 9
            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //var result = ImportSuppliers(context, supplierXml);

            // Query 10
            //var partXml = File.ReadAllText("./Datasets/parts.xml");
            //var result = ImportParts(context, partXml);

            // Query 11
            //var carXml = File.ReadAllText("./Datasets/cars.xml");
            //var result = ImportCars(context, carXml);

            // Query 12
            //var customerXml = File.ReadAllText("./Datasets/customers.xml");
            //var result = ImportCustomers(context, customerXml);

            // Query 13
            //var saleXml = File.ReadAllText("./Datasets/sales.xml");
            //var result = ImportSales(context, saleXml);

            // Query 14
            //var result = GetCarsWithDistance(context);

            // Query 15
            //var result = GetCarsFromMakeBmw(context);

            // Query 16
            //var result = GetLocalSuppliers(context);

            //Query 17
            var result = GetCarsWithTheirListOfParts(context);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var textRead = new StringReader(inputXml);

            var suppliersDto = (SupplierInputModel[])xmlSerializer.Deserialize(textRead);

            var suppliers = suppliersDto
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            var textRead = new StringReader(inputXml);

            var partDto = xmlSerializer.Deserialize(textRead) as PartInputModel[];

            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var parts = partDto
                .Where(s => supplierIds.Contains(s.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();
            context.Parts.AddRange(parts);
            context.SaveChanges();
            
            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var textRead = new StringReader(inputXml);

            var carDtos = xmlSerializer.Deserialize(textRead) as CarInputModel[];

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                var parts = carDto
                    .Parts
                    .Where(pdto => context.Parts.Any(p => p.Id == pdto.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var partId in parts)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId,
                        Car = car
                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();
            
            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CustomersInputModel[]), new XmlRootAttribute("Customers"));
            var textRead = new StringReader(inputXml);

            var customersDto = (CustomersInputModel[])xmlSerializer.Deserialize(textRead);

            var customers = customersDto
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SalesInputModel[]), new XmlRootAttribute("Sales"));
            var textRead = new StringReader(inputXml);

            var salesDto = (SalesInputModel[])xmlSerializer.Deserialize(textRead);

            var carIds = context
                .Cars
                .Select(c => c.Id)
                .ToArray();

            var sales = salesDto
                .Where(s => carIds.Contains(s.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();
            ;
            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, ns);

            return textWriter.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BmwOutputModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(BmwOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, ns);

            return textWriter.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new SupplierOutputModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(SupplierOutputModel[]), new XmlRootAttribute("suppliers"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, suppliers, ns);

            return textWriter.ToString();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarPartOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => new CarPartInfoOutputModel
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(pc => pc.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarPartOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, ns);

            return textWriter.ToString();
        }
    }
}