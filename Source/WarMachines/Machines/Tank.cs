namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank, IMachine
    {
        private const double InitialHealthPoints = 100;
        public const int AddDefensePoints = 30;
        public const int RemoveAttackPoints = 40;

        private bool defenseMode = false;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }

            private set
            {
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (this.defenseMode)
            {
                this.DefensePoints += AddDefensePoints;
                this.AttackPoints -= RemoveAttackPoints;
            }
            else
            {
                this.DefensePoints -= AddDefensePoints;
                this.AttackPoints += RemoveAttackPoints;
            }
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            print.Append(base.ToString());
            print.Append(string.Format(" *Defense: {0}",
                this.DefenseMode ? "ON" : "OFF"));

            return print.ToString();
        }
    }
}
