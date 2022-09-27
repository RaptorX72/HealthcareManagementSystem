CREATE TABLE IF NOT EXISTS User(
	id CHAR(36) PRIMARY KEY,
	userName VARCHAR(64),
	email VARCHAR(256),
	salt VARCHAR(128),
	password VARCHAR(512)
);

CREATE TABLE IF NOT EXISTS Doctor(
	id CHAR(36) PRIMARY KEY,
	firstName VARCHAR(128),
	lastName VARCHAR(128),
	middleName VARCHAR(128)
);

CREATE TABLE IF NOT EXISTS Patient(
	id CHAR(36) PRIMARY KEY,
	firstName VARCHAR(128),
	lastName VARCHAR(128),
	middleName VARCHAR(128)
);

CREATE TABLE IF NOT EXISTS DoctorPatientTreatment(
	id INTEGER AUTO_INCREMENT PRIMARY KEY,
	doctorId CHAR(36),
	patientId CHAR(36),
	FOREIGN KEY (patientId) REFERENCES Patient(id),
	FOREIGN KEY (doctorId) REFERENCES Doctor(id)
);

CREATE TABLE IF NOT EXISTS UnitOfMeasurement(
	id INTEGER AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(64)
);

CREATE TABLE IF NOT EXISTS Medication(
	id CHAR(36) PRIMARY KEY,
	name VARCHAR(256),
	mainIngredient VARCHAR(256),
	dosage FLOAT,
	size FLOAT,
	unitOfMeasurementId INTEGER,
	FOREIGN KEY (unitOfMeasurementId) REFERENCES UnitOfMeasurement(id)
);

CREATE TABLE IF NOT EXISTS Perscription(
	id CHAR(36) PRIMARY KEY,
	patientId CHAR(36),
	doctorId CHAR(36),
	medicationId CHAR(36),
	note TEXT,
	FOREIGN KEY (patientId) REFERENCES Patient(id),
	FOREIGN KEY (doctorId) REFERENCES Doctor(id),
	FOREIGN KEY (medicationId) REFERENCES Medication(id)
);

CREATE TABLE IF NOT EXISTS Appointment(
	id CHAR(36) PRIMARY KEY,
	appointmentDate DATETIME,
	doctorId CHAR(36),
	patientId CHAR(36),
	note TEXT,
	FOREIGN KEY (doctorId) REFERENCES Doctor(id),
	FOREIGN KEY (patientId) REFERENCES Patient(id)
);

CREATE TABLE IF NOT EXISTS MedicalNote(
	id CHAR(36) PRIMARY KEY,
	appointmentId CHAR(36),
	note TEXT,
	FOREIGN KEY (appointmentId) REFERENCES Appointment(id)
);

CREATE TABLE IF NOT EXISTS BloodType(
	id INTEGER AUTO_INCREMENT PRIMARY KEY,
	protein CHAR(2),
	rh BOOLEAN
);

CREATE TABLE IF NOT EXISTS MedicalRecord(
	id CHAR(36) PRIMARY KEY,
	patientId CHAR(36),
	birthDate DATETIME,
	gender VARCHAR(16),
	bloodTypeId INTEGER,
	height FLOAT,
	weight FLOAT,
	FOREIGN KEY (patientId) REFERENCES Patient(id),
	FOREIGN KEY (bloodTypeId) REFERENCES BloodType(id)
);

CREATE TABLE IF NOT EXISTS PatientPerscription(
	id INTEGER AUTO_INCREMENT PRIMARY KEY,
	patientId CHAR(36),
	perscriptionId CHAR(36),
	FOREIGN KEY (patientId) REFERENCES Patient(id),
	FOREIGN KEY (perscriptionId) REFERENCES Perscription(id)
);

CREATE TABLE IF NOT EXISTS MedicalTestType(
	id INTEGER AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(128)
);

CREATE TABLE IF NOT EXISTS MedicalTest(
	id CHAR(36) PRIMARY KEY,
	doctorId CHAR(36),
	patientId CHAR(36),
	testTypeId INTEGER,
	FOREIGN KEY (doctorId) REFERENCES Doctor(id),
	FOREIGN KEY (patientId) REFERENCES Patient(id),
	FOREIGN KEY (testTypeId) REFERENCES MedicalTestType(id)
);

CREATE TABLE IF NOT EXISTS SurgeryOutcome(
	id INTEGER AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(128)
);

CREATE TABLE IF NOT EXISTS Surgery(
	id CHAR(36) PRIMARY KEY,
	appointerId CHAR(36),
	surgeonId CHAR(36),
	patientId CHAR(36),
	surgeryDate DATETIME,
	note TEXT,
	outcomeId INTEGER,
	FOREIGN KEY (appointerId) REFERENCES Doctor(id),
	FOREIGN KEY (surgeonId) REFERENCES Doctor(id),
	FOREIGN KEY (patientId) REFERENCES Patient(id),
	FOREIGN KEY (outcomeId) REFERENCES SurgeryOutcome(id)
);
/*TODO: Create medical test result table and connect*/

INSERT INTO BloodType (protein, rh) VALUES
("A", true),
("A", false),
("B", true),
("B", false),
("AB", true),
("AB", false),
("O", true),
("O", false);

INSERT INTO MedicalTestType (name) VALUES
("Bloodtest"), ("Pathology");