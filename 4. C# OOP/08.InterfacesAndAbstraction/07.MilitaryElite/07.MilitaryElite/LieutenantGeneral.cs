using System.Collections.Generic;

namespace MilitaryElite
{
    public class LieutenantGeneral : Soldier
    {
        public LieutenantGeneral(string id, string firstName, string lastName)
            : base(id, firstName, lastName)
        {
            this.Privates = new List<Private>();
        }

        public List<Private> Privates { get; private set; }
    }
}
