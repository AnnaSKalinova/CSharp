using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.Data = new List<Pet>();
        }
        public List<Pet> Data { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Data.Count;

        public void Add(Pet pet)
        {
            if (this.Data.Count < this.Capacity)
            {
                this.Data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            bool isRemoved = false;

            foreach (var pet in this.Data.Where(p => p.Name == name))
            {
                this.Data.Remove(pet);
                isRemoved = true;
                return isRemoved;
            }

            return isRemoved;
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.Data
                .Where(p => p.Name == name)
                .Where(p => p.Owner == owner)
                .FirstOrDefault();

            return pet;
        }
        public Pet GetOldestPet()
        {
            Pet oldestPet = this.Data
                   .OrderByDescending(p => p.Age)
                   .FirstOrDefault();
            return oldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.Data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
