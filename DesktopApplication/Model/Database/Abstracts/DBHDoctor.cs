using DesktopApplication.Model.Healthcare;

namespace DesktopApplication.Model.Database {
    public abstract class DBHDoctor : IDBHandlerDoctor {
        public abstract void DeleteDoctor(Doctor doctor);
        public abstract void DeleteDoctorById(Guid doctorId);
        public abstract List<Doctor> GetAllDoctors();
        public abstract Doctor GetDoctorById(Guid doctorId);
        public abstract List<Doctor> GetDoctorsBySpecialityId(int specialityId);
        public abstract List<Doctor> GetDoctorsOfPatient(Patient patient);
        public abstract List<Doctor> GetDoctorsOfPatientById(Guid patientId);
        public abstract void UpdateDoctor(Doctor doctor);
        public abstract void UpdateDoctorById(Guid doctorId, Doctor doctor);
        public abstract void UpdateDoctorsOfPatient(Patient patient, List<Doctor> doctor);
        public abstract void UpdateDoctorsOfPatientById(Guid patientId, List<Doctor> doctor);
    }
}
