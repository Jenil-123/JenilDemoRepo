using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssGCollection
{
    public class PatientManager
    {

        private List<Patient> plist = null;

        public PatientManager()
        {
            plist = new List<Patient>();
        }

        public int GenerateID()
        {
            if (plist.Count() == 0)
            {
                return 1;
            }
            else
            {
                int max = 0;
                foreach (Patient p in plist)
                {
                    if (max < p.PID)
                    {
                        max = p.PID;
                    }
                }
                return max + 1;
            }
        }


        public void AddPatient(Patient p)
        {
            plist.Add(p);
        }

        public bool EditPatient(int pid, Patient p)
        {
            int position = GetIndex(pid);

            if (position == -1)
            {
                return false;
            }
            else
            {
                plist[position] = p;
                return true;
            }
        }

        public bool RemovePatient(int pid)
        {
            int position = GetIndex(pid);
            if (position == -1)
            {
                return false;
            }
            else
            {
                plist.RemoveAt(position);
                return true;
            }
        }

        public Patient FindPatient(int pid)
        {
            int position = GetIndex(pid);

            if (position == -1)
            {
                return null;
            }
            else
            {
                return plist[position];
            }
        }

        public int GetIndex(int pid)
        {
            int index = 0;
            foreach (Patient current in plist)
            {
                if (pid == current.PID)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }


        public List<Patient> GetAllPatient() {
            return plist;
        }

        public List<Patient> GetPatientByName(string name) 
        {
           List<Patient> namelist = new List<Patient>();
            foreach (Patient current in plist)
            {
                if (current.PNAME.Equals(name))
                {
                     namelist.Add(current);
                }
            }
            return namelist;
        }


        public List<Patient> GetPatientByGender(Gen gender)
        {
            List<Patient> genderlist = new List<Patient>();
            foreach (Patient current in plist)
            {
                if (current.PGENDER.Equals(gender))
                {
                    genderlist.Add(current);
                }
            }
            return genderlist;
        }

    }
}
