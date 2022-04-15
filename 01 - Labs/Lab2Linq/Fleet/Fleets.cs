using System;
using System.Collections.Generic;

namespace Fleet
{
    public class Fleets
    {
        public string Make {get; set;}

        public string Model {get; set;}

        public string Registration {get; set;}

        public double EngizeSeize {get; set;}

        

        public Fleets (string _make, string _model, string _registration, double _engineseize)
        {
            this.Make = _make;
            this.Model = _model;
            this.Registration = _registration;
            this.EngizeSeize = _engineseize;

        }

        public override string ToString()
        {
            return string.Format("Make: {0} | Model: {1} | Registration: {2} | Engine Seize: {3}",this.Make,this.Model,this.Registration,this.EngizeSeize);
        }
    }
}