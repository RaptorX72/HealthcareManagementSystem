using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.Model {
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
