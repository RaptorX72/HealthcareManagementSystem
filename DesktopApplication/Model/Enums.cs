namespace DesktopApplication.Model {
    public enum DataBaseType {
        MySQL,
        SQLServer,
        SQLite
    }

    public enum BloodAntigen {
        A,
        B,
        AB,
        O
    }

    public enum MedicalTestType {
        Bloodtest,
        Pathology
    }

    public enum SurgeryOutcome {
        NotPerformed,
        Success,
        PartialSuccess,
        Failed
    }

    public enum UnitOfMeasurement {
        kg,
        g,
        mg
    }
}
