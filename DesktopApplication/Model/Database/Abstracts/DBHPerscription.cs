﻿using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHPerscription : IDBHandlerPerscription {
        public abstract Perscription AddPerscription(Perscription perscription);
        public abstract void DeleteAllPerscriptionsByDoctor(Doctor doctor);
        public abstract void DeleteAllPerscriptionsByDoctorId(Guid doctorId);
        public abstract void DeleteAllPerscriptionsByPatient(Patient patient);
        public abstract void DeleteAllPerscriptionsByPatientId(Guid patientId);
        public abstract void DeletePerscription(Perscription perscription);
        public abstract void DeletePerscriptionById(Guid perscriptionId);
        public abstract List<Perscription> GetAllPerscriptions();
        public abstract List<Perscription> GetAllPerscriptionsByDoctor(Doctor doctor);
        public abstract List<Perscription> GetAllPerscriptionsByDoctorId(Guid doctorId);
        public abstract List<Perscription> GetAllPerscriptionsByPatient(Patient patient);
        public abstract List<Perscription> GetAllPerscriptionsByPatientId(Guid patientId);
        public abstract Perscription GetPerscriptionById(Guid perscriptionId);
        public abstract void UpdatePerscriptions(List<Perscription> perscriptions);
        public abstract void UpdatePerscription(Perscription perscription);
        public abstract void UpdatePerscriptionById(Guid perscriptionId, Perscription perscription);
    }
}
