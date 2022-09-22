using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssGCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientCLIView pcl = new PatientCLIView();
            bool flag = true;
            while (flag)
            {
                int n = pcl.Menu();
                switch (n)
                {
                    case 1:
                        pcl.AddPatientView();
                        break;

                    case 2:
                        pcl.EditPatientView();
                        break;

                    case 3:
                        pcl.RemovePatientView();
                        break;

                    case 4:
                        pcl.FindPatientView();
                        break;

                    case 5:
                        pcl.GetAllPatientView();
                        break;

                    case 6:
                        pcl.GetPatientByNameView();
                        break;

                    case 7:
                        pcl.GetPatientByGenderView();
                        break;

                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
