namespace DesktopApplication.Model {
    public class BloodType {
        #region fields
        public BloodAntigen BloodAntigen { get; }
        
        public bool Rh { get; }
        
        public static BloodType Empty { get { return new BloodType(BloodAntigen.O, false); } }
        #endregion
        #region constructors
        public BloodType(BloodAntigen bloodAntigen, bool rh) {
            BloodAntigen = bloodAntigen;
            Rh = rh;
        }

        public BloodType(string bloodAntigen, bool rh) {
            Rh = rh;
            switch (bloodAntigen) {
                case "A":
                    BloodAntigen = BloodAntigen.A;
                    break;
                case "B":
                    BloodAntigen = BloodAntigen.B;
                    break;
                case "AB":
                    BloodAntigen = BloodAntigen.AB;
                    break;
                case "O":
                    BloodAntigen = BloodAntigen.O;
                    break;
            }
        }
        #endregion
    }
}
