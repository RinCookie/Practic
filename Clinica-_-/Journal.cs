//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinica___
{
    using System;
    using System.Collections.Generic;
    
    public partial class Journal
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public int DiagnosisID { get; set; }
        public int PatientID { get; set; }
        public int AdressID { get; set; }
        public int DoctorID { get; set; }
    
        public virtual Adress Adress { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
