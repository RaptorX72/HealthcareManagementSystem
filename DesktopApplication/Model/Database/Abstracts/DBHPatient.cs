using DesktopApplication.Model.Healthcare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.Model.Database {
    public abstract class DBHPatient : IDBHandlerPatient {
        public abstract void DeletePatient(Patient patient);
        public abstract void DeletePatientById(Guid patientId);
        public abstract List<Patient> GetAllPatients();
        public abstract Patient GetPatientById(Guid patientId);
        public abstract List<Patient> GetPatientsOfDoctor(Doctor doctor);
        public abstract List<Patient> GetPatientsOfDoctorById(Guid doctorId);
        public abstract void UpdatePatient(Patient patient);
        public abstract void UpdatePatientById(Guid patientId, Patient patient);
        public abstract void UpdatePatientsOfDoctor(Doctor doctor, List<Patient> patients);
        public abstract void UpdatePatientsOfDoctorById(Guid doctorId, List<Patient> patients);
    }
}
