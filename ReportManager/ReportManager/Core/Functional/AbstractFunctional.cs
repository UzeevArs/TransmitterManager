﻿using System.Xml.Serialization;

namespace ReportManager.Core.Functional
{
    [XmlInclude(typeof(CheckIsupDbConnectionFunctional))]
    [XmlInclude(typeof(CheckManifactureDbConnectionFunctional))]
    [XmlInclude(typeof(SynchronizeDbFunctional))]
    public abstract class AbstractFunctional
    {
        public string Name { get; set; }
        public abstract void Start();
        public abstract void Stop();
    }
}
