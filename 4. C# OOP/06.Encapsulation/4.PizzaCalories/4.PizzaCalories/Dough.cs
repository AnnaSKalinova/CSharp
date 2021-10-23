using System;

namespace PizzaCalories
{
    public class Dough
    {
        private double modifier = 1;
        private string EXC_MSG_DOUGH = "Invalid type of dough.";
        private string EXC_MSG_WEIGHT = "Dough weight should be in the range [1..200].";

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set 
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(EXC_MSG_DOUGH);
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(EXC_MSG_DOUGH);
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(EXC_MSG_WEIGHT);
                }
                this.weight = value;
            }
        }

        public double CalculateModifier()
        {
            switch (this.FlourType.ToLower())
            {
                case "white":
                    modifier *= 1.5;
                    break;
                case "wholegrain":
                    modifier *= 1;
                    break;
            }
            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    modifier *= 0.9;
                    break;
                case "chewy":
                    modifier *= 1.1;
                    break;
                case "homemade":
                    modifier *= 1;
                    break;
            }

            return modifier;
        }
        public double CalculateDoughCalories()
        {
            var doughCalories = 2 * this.Weight * CalculateModifier();

            return doughCalories;
        }
    }
}
