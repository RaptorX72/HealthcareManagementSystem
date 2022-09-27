﻿using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerPerscription {
        public Perscription AddPerscription(Perscription perscription);

        public List<Perscription> GetAllPerscriptions();

        public Perscription GetPerscriptionById(Guid perscriptionId);

        public void UpdatePerscriptionById(Guid perscriptionId, Perscription perscription);

        public void UpdatePerscription(Perscription perscription);

        public void DeletePerscriptionById(Guid perscriptionId);

        public void DeletePerscription(Perscription perscription);

        #region GetAll
        public List<Perscription> GetAllPerscriptionsByDoctorId(Guid doctorId);

        public List<Perscription> GetAllPerscriptionsByDoctor(Doctor doctor);

        public List<Perscription> GetAllPerscriptionsOfPatientId(Guid patientId);

        public List<Perscription> GetAllPerscriptionsOfPatient(Patient patient);
        #endregion

        #region UpdateAll
        public void UpdatePerscriptions(List<Perscription> perscriptions);
        #endregion

        #region DeleteAll
        public void DeleteAllPerscriptionsByDoctorId(Guid doctorId);

        public void DeleteAllPerscriptionsByDoctor(Doctor doctor);

        public void DeleteAllPerscriptionsOfPatientId(Guid patientId);

        public void DeleteAllPerscriptionsOfPatient(Patient patient);
        #endregion
    }
}
