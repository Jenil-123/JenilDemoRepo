using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssGCollection
{
    public class Patient
    {
        private int pid;
        private string name;    
        private Gen gender;
        private string mobileno;
        private uint weight;
        private string height;
        private string deases;

        public int PID { get { return pid; } set { pid = value; } }
        public string PNAME { get { return name; } set { name = value; } }
        public Gen PGENDER { get { return gender; } set { gender = value; } }
        public string PMOBILENO { get { return mobileno; } set { mobileno = value; } }
        public uint PWEIGHT { get { return weight; } set { weight = value; } }
        public string PHEIGHT { get { return height; } set { height = value; } }
        public string PDEASES { get { return deases; } set { deases = value; } }


        public Patient() { }
        public Patient(int pid, string name, Gen gender, string mobileno, uint weight, string height, string deases)
        {
            this.pid = pid;
            this.name = name;
            this.gender = gender;
            this.mobileno = mobileno;
            this.weight = weight;
            this.height = height;
            this.deases = deases;
        }

        public override string ToString() {
            return "---Patint Details---\n" +
                "Id: " + pid +
                "\nName: " + name +
                "\nGender: " + gender +
                "\nMobileNo: " + mobileno +
                "\nWeight: " + weight +
                "\nHeight: " + height +
                "\nDeases: " + deases;
        }
    }
}
