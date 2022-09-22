using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssGCollection
{
    internal class PatientCLIView
    {
        Patient p;
        PatientManager pm;
        public PatientCLIView() { 
            pm=new PatientManager();
        }
        public int Menu()
        {
            Console.WriteLine("1. New Patient");
            Console.WriteLine("2. Modify Patient");
            Console.WriteLine("3. Remove Patient");
            Console.WriteLine("4. Find Patient");
            Console.WriteLine("5. Patient Summary");
            Console.WriteLine("6. Patient Summary By Name");
            Console.WriteLine("7. Patient Summary By Gender");
            Console.WriteLine("8. Exit");
            Console.Write("Please Enter Your Choice\t:\t");
            int ch = int.Parse(Console.ReadLine());
            return ch;
        }

        public void AddPatientView()
        {
            int pid;
            string name;
            Gen gender;
            string mobileno;
            uint weight;
            string height;
            string deases;
            pid = pm.GenerateID();
            Console.WriteLine("New Patient ID\t\t:\t{0}", pid);
            Console.Write("Please Enter Patient Name\t:\t");
            name = Console.ReadLine();
            Console.Write("Please Enter Patient Gender\t:\t");
            gender = (Gen)int.Parse(Console.ReadLine());
            Console.Write("Please Enter Patient MobileNo\t:\t");
            mobileno = Console.ReadLine();
            Console.Write("Please Enter Patient Weight\t:\t");
            weight = uint.Parse(Console.ReadLine());
            Console.Write("Please Enter Patient Height\t:\t");
            height = Console.ReadLine();
            Console.Write("Please Enter Patient Deases\t:\t");
            deases = Console.ReadLine();

            p = new Patient
            {
                PID = pid,
                PNAME = name,
                PGENDER = gender,
                PMOBILENO = mobileno,
                PWEIGHT = weight,
                PHEIGHT = height,
                PDEASES = deases
            };
            pm.AddPatient(p);
        }
        public void EditPatientView()
        {
            int pid;
            string name;
            Gen gender;
            string mobileno;
            uint weight;
            string height;
            string deases;
            Console.WriteLine("Enter Patient ID\t\t:\t");
            pid=int.Parse(Console.ReadLine());
            Console.Write("Please Enter Patient Name\t:\t");
            name = Console.ReadLine();
            Console.Write("Please Enter Patient Gender\t:\t");
            gender = (Gen)int.Parse(Console.ReadLine());
            Console.Write("Please Enter Patient MobileNo\t:\t");
            mobileno = Console.ReadLine();
            Console.Write("Please Enter Patient Weight\t:\t");
            weight = uint.Parse(Console.ReadLine());
            Console.Write("Please Enter Patient Height\t:\t");
            height = Console.ReadLine();
            Console.Write("Please Enter Patient Deases\t:\t");
            deases = Console.ReadLine();

            p = new Patient
            {
                PID = pid,
                PNAME = name,
                PGENDER = gender,
                PMOBILENO = mobileno,
                PWEIGHT = weight,
                PHEIGHT = height,
                PDEASES = deases
            };
            if (pm.EditPatient(pid, p))
            {
                Console.WriteLine("Patient Updated Sucessfully.....");
            }
            else
            {
                Console.WriteLine("Patient not found to Update.......");
            }
        }

        public void RemovePatientView()
        {
            int pid;
            Console.Write("Please Enter Patient ID\t:\t");
            pid = int.Parse(Console.ReadLine());
            if (pm.RemovePatient(pid))
            {
                Console.WriteLine("Patient Deleted Successfully...........");
            }
            else
            {
                Console.WriteLine("Patient not found to delete.......");
            }
        }


        public void FindPatientView()
        {
            int pid;

            Console.Write("Please Enter Patient ID\t:\t");
            pid = int.Parse(Console.ReadLine());

            p = pm.FindPatient(pid);

            if (p != null)
            {
                Console.WriteLine("Patient Record Found.............");
                Console.WriteLine(p);
            }
            else
            {
                Console.WriteLine("Patient not found.......");
            }
        }

        public void GetAllPatientView()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("ID\tName\tGender\tMobileNo\tWeight\tHeight\tDeases");
            Console.WriteLine("-------------------------------------------------------");
            foreach (Patient p in pm.GetAllPatient())
            {
                Console.WriteLine(p.PID + "\t" + p.PNAME + "\t" + p.PGENDER + "\t" + p.PMOBILENO + "\t" + p.PWEIGHT + "\t" + p.PHEIGHT + "\t" + p.PDEASES);
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public void GetPatientByNameView()
        {
            Console.WriteLine("Enter Patient Name: "); 
            string name = Console.ReadLine(); 
            List<Patient> pl = pm.GetPatientByName(name);

            if (pl == null) 
            { Console.WriteLine("NO RECORD FOUND"); } 
            else 
            { 
                foreach (Patient p in pl) 
                {
                    Console.WriteLine(p); 
                } 
            }
        }

        public void GetPatientByGenderView()
        {
            Console.WriteLine("Enter Patient Gender: (0 for FEMALE or 1 for MALE)"); 
            Gen gender = (Gen)int.Parse(Console.ReadLine()); 
            List<Patient> pl = pm.GetPatientByGender(gender);

            if (pl == null) 
            { 
                Console.WriteLine("NO RECORD FOUND"); 
            } else { 
                foreach (Patient p in pl) 
                { 
                    Console.WriteLine(p); 
                } 
            }
        }

        ~PatientCLIView()
        {
            pm = null;
            p = null;
        }
    }
}
