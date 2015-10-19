namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Common;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        protected Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;            
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, ApplicationConstants.PropertyNullExseption);
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                Validator.CheckIfNull(value, ApplicationConstants.PropertyNullExseption);
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                // return new List<string>(this.targets);
                return this.targets;
            }

            protected set
            {
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            Validator.CheckIfStringIsNullOrEmpty(target, ApplicationConstants.PropertyNullExseption);
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();

            print.AppendLine(string.Format(" *Health: : {0}", this.HealthPoints));
            print.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            print.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            print.AppendLine(string.Format(" *Targets: {0}",
                this.targets.Count > 0 ? string.Join(", ", this.targets) : "None"));

            return print.ToString();
        }
    }
}
