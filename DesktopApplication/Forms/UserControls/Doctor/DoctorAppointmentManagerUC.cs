using DesktopApplication.Model.Healthcare;

namespace DesktopApplication {
    public partial class DoctorAppointmentManagerUC : UserControl {
        private DoctorMainFormUC parentUC;
        private Doctor doctor;
        public DoctorAppointmentManagerUC(DoctorMainFormUC parent, Doctor doctor) {
            InitializeComponent();
            parentUC = parent;
            this.doctor = doctor;
        }
    }
}
