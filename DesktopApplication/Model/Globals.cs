namespace DesktopApplication {
    public class Globals {
        public static readonly string DateFormat = "yyyy-MM-dd HH:mm:ss";
        public static readonly int MinimumPasswordLength = 8;
    }

    public static class Preferences {
        private static Theme theme = new Theme(Theme.ColorTheme.Dark);

        public static Theme Theme { get { return theme; } }

        public static void SetTheme(Theme.ColorTheme colorTheme) {
            theme = new Theme(colorTheme);
        }
    }

    public class Theme {
        public enum ColorTheme {
            Dark,
            Blue,
            Light
        }
        private Color errorColor;
        private Color successColor;
        private Color[] backgroundColors;
        private Color[] foregroundColors;

        public Color ErrorColor { get { return errorColor; } }
        public Color SuccessColor { get { return successColor; } }

        public Color BackgroundLevelOne { get { return backgroundColors[0]; } }
        public Color BackgroundLevelTwo { get { return backgroundColors[1]; } }
        public Color BackgroundLevelThree { get { return backgroundColors[2]; } }

        public Color ForegroundLevelOne { get { return foregroundColors[0]; } }
        public Color ForegroundLevelTwo { get { return foregroundColors[1]; } }
        public Color ForegroundLevelThree { get { return foregroundColors[2]; } }

        //TODO: Come up with good looking colors
        public Theme(ColorTheme theme) {
            errorColor = Color.Red;
            successColor = Color.Green;
            backgroundColors = new Color[] {
                Color.Black,
                Color.DarkGray,
                Color.Gray
            };
            foregroundColors = new Color[] {
                Color.White,
                Color.GhostWhite,
                Color.WhiteSmoke
            };
            /*switch (theme) {
                case ColorTheme.Dark:
                    errorColor = Color.Red;
                    successColor = Color.Green;
                    backgroundColors = new Color[] {
                        Color.Black,
                        Color.DarkGray,
                        Color.Gray
                    };
                    foregroundColors = new Color[] {
                        Color.White,
                        Color.GhostWhite,
                        Color.WhiteSmoke
                    };
                    break;
                case ColorTheme.Blue:
                    break;
                case ColorTheme.Light:
                    break;
            }*/
        }
    }
}
