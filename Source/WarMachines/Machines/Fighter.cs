namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter, IMachine
    {
        public const double InitialHealthPoints = 200;

        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode// { get; private set; }
        {
            get
            {
                return this.stealthMode;
            }

            private set
            {
                this.stealthMode = value;
            }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = !this.stealthMode;
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            print.Append(base.ToString());
            print.Append(string.Format(" *Stealth: {0}",
                this.StealthMode ? "ON" : "OFF"));

            return print.ToString();
        }
    }
}
