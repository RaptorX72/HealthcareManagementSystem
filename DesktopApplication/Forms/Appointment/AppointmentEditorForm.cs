using DesktopApplication.Model.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication.Forms {
    public partial class AppointmentEditorForm : Form {
        private Appointment appointment = Appointment.Empty;

        public Appointment Appointment { get => appointment; }

        public AppointmentEditorForm() {
            InitializeComponent();
            Setup();
        }

        public AppointmentEditorForm(Appointment appointment) {
            this.appointment = appointment;
            InitializeComponent();
            Setup();
        }

        private void Setup() {
            if (appointment.Id != Guid.Empty) {

            } else {

            }
        }

        private void buttonAddEdit_Click(object sender, EventArgs e) {

        }

        private void buttonCancel_Click(object sender, EventArgs e) {

        }
    }
}
