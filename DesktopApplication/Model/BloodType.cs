namespace DesktopApplication.Model {
    public class BloodType {
        #region fields
        public BloodAntigen BloodAntigen { get; }
        public bool Rh { get; }
        #endregion
        #region constructors
        public BloodType(BloodAntigen bloodAntigen, bool rh) {
            BloodAntigen = bloodAntigen;
            Rh = rh;
        }
        #endregion
    }
}
