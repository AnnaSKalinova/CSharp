using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<BakedFood> bakedFoods;
        private readonly ICollection<Drink> drinks;
        private readonly ICollection<Table> tables;
        private decimal income = 0;

        public Controller()
        {
            this.bakedFoods = new List<BakedFood>();
            this.drinks = new List<Drink>();
            this.tables = new List<Table>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood bakedFood = null;
            switch (type)
            {
                case "Bread":
                    bakedFood = new Bread(name, price);
                    break;
                case "Cake":
                    bakedFood = new Cake(name, price);
                    break;
            }

            bakedFoods.Add(bakedFood);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink = null;
            switch (type)
            {
                case "Tea":
                    drink = new Tea(name, portion, brand);
                    break;
                case "Water":
                    drink = new Water(name, portion, brand);
                    break;
            }

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table = null;
            switch (type)
            {
                case "OutsideTable":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                case "InsideTable":
                    table = new InsideTable(tableNumber, capacity);
                    break;
            }

            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            StringBuilder sb = new StringBuilder();

            if (!this.tables.Any(t => !t.IsReserved && t.Capacity >= numberOfPeople))
            {
                sb.AppendLine($"No available table for {numberOfPeople} people");
            }
            else
            {
                Table table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

                table.IsReserved = true;
                table.NumberOfPeople = numberOfPeople;

                sb.AppendLine($"Table {table.TableNumber} has been reserved for {numberOfPeople} people");
            }

            return sb.ToString().TrimEnd();
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            StringBuilder sb = new StringBuilder();

            if (!this.tables.Any(t => t.TableNumber == tableNumber))
            {
                sb.AppendLine($"Could not find table {tableNumber}");
            }
            else if (!this.bakedFoods.Any(f => f.Name == foodName))
            {
                sb.AppendLine($"No {foodName} in the menu");
            }
            else
            {
                BakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);
                Table table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

                table.OrderFood(food);
                sb.AppendLine($"Table {tableNumber} ordered {foodName}");
            }

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            StringBuilder sb = new StringBuilder();

            if (!this.tables.Any(t => t.TableNumber == tableNumber))
            {
                sb.AppendLine($"Could not find table {tableNumber}");
            }
            else if (!this.drinks.Any(dr => dr.Name == drinkName && dr.Brand == drinkBrand))
            {
                sb.AppendLine($"There is no {drinkName} {drinkBrand} available");
            }
            else
            {
                Drink drink = this.drinks.FirstOrDefault(dr => dr.Name == drinkName && dr.Brand == drinkBrand);
                Table table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

                table.OrderDrink(drink);
                sb.AppendLine($"Table {tableNumber} ordered {drinkName} {drinkBrand}");
            }

            return sb.ToString().TrimEnd();
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            income += table.Price;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.Price:F2}");
            table.Clear();

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(t => !t.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            StringBuilder sb = new StringBuilder();

            var totalIncome = income;

            sb.AppendLine($"Total income: {totalIncome:f2}lv");

            return sb.ToString().TrimEnd(); ;
        }
    }
}
