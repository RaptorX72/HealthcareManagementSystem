using DesktopApplication.Model.Healthcare;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerDoctor {
        public Doctor AddDoctor(Doctor doctor);

        public List<Doctor> GetAllDoctors();

        public Doctor GetDoctorById(Guid doctorId);

        public void UpdateDoctorById(Guid doctorId, Doctor doctor);

        public void UpdateDoctor(Doctor doctor);

        public void DeleteDoctorById(Guid doctorId);

        public void DeleteDoctor(Doctor doctor);

        public List<Doctor> GetDoctorsBySpecialityId(int specialityId);

        public List<Doctor> GetDoctorsOfPatientById(Guid patientId);

        public List<Doctor> GetDoctorsOfPatient(Patient patient);

        public void UpdateDoctors(List<Doctor> doctors);
    }
}
