using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Clinica___
{
    class Views
    {
        public static CollectionViewSource JournalView { get; set; }
        public static CollectionViewSource PatientView { get; set; }
        public static CollectionViewSource DiagnosisView { get; set; }
        public static CollectionViewSource DoctorView { get; set; }
        public static CollectionViewSource AdressView { get; set; }
    }
}
