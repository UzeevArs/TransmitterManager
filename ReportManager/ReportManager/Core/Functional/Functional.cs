using System;
using System.Xml.Serialization;

namespace ReportManager.Core.Functional
{
    public abstract class Functional
    {
        public abstract event EventHandler<bool> StatusChanged;
        public string Name { get; set; }
        public abstract bool IsRunning { get; }
        public abstract void Start();
        public abstract void Stop();
        public override string ToString()
        {
            return Name;
        }
    }
}
