namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    using WarMachines.Common;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new Collection<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", ApplicationConstants.PropertyNullExseption);
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.CheckIfNull(machine, ApplicationConstants.PropertyNullExseption);

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.Append(string.Format("{0} - {1} {2}", this.Name,
                this.machines.Count > 0 ? this.machines.Count.ToString() : "no",
                this.machines.Count > 0 ? "machine" : "machines"));

            var orderedMachines =
                this.machines
                    .OrderBy(m => m.HealthPoints)
                    .ThenBy(m => m.Name)
                    .ToList();

            foreach (var machine in orderedMachines)
            {
                report.AppendLine();
                report.AppendLine(string.Format("- {0}", machine.Name));
                report.Append(machine.ToString());
            }

            return report.ToString();
        }
    }
}
