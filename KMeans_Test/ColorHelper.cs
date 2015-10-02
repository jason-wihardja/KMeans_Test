using System;
using System.Drawing;

namespace KMeans_Test {
    static class ColorHelper {
        public static String[] knownColorsName = {
                                                     "blue",
                                                     "blueviolet",
                                                     "brown",
                                                     "cadetblue",
                                                     "chocolate",
                                                     "crimson",
                                                     "darkblue",
                                                     "darkgoldenrod",
                                                     "darkgreen",
                                                     "darkmagenta",
                                                     "darkolivegreen",
                                                     "darkorange",
                                                     "darkorchid",
                                                     "darkred",
                                                     "darkslateblue",
                                                     "darkviolet",
                                                     "deeppink",
                                                     "dodgerblue",
                                                     "forestgreen",
                                                     "hotpink",
                                                     "indigo",
                                                     "limegreen",
                                                     "magenta",
                                                     "maroon",
                                                     "mediumblue",
                                                     "mediumvioletred",
                                                     "midnightblue",
                                                     "navy",
                                                     "orange",
                                                     "orangered",
                                                     "purple",
                                                     "red",
                                                     "royalblue",
                                                     "seagreen",
                                                     "teal",
                                                     "yellowgreen"
                                                 };

        private static Random random = new Random();

        public static Color getNextKnownColor() {
            Int32 index = random.Next(0, knownColorsName.Length);
            // Console.WriteLine(knownColorsName[index]);
            return Color.FromName( knownColorsName[index] );
        }
    }
}
