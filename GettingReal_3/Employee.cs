﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class Employee
    {
        DateTime vagtDato;
        public Employee(string name)
        {
            Name = name;
        }
        public Employee() { }
        public string Name
        {
            get;
            set;
        }
        public DateTime VagtDato { get; set; }

        private TimeSpan timespan = new TimeSpan(00, 00, 00);


        private double tal = 0;
        public TimeSpan TotalHoursWorked
        {
            get { return timespan; }
            set { this.timespan = value; }
            

        }
        public double TotalHoursSomTal()
        {
            double min = timespan.TotalMinutes;
            double hours = min / 60;
            return hours;


        }
        

    }
}
