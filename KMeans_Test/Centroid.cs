using Newtonsoft.Json;
using System;
using System.Collections;
using System.Drawing;

namespace KMeans_Test {
    class Centroid : IComparable, ICloneable {
        public Centroid() {
            this.location = new PointF(0.0f, 0.0f);
            this.color = Color.Black;
            this.closestCities = new ArrayList();
        }

        public PointF location { get; set; }
        public Color color { get; set; }
        public ArrayList closestCities { get; set; }

        public object Clone() {
            String serializedData = JsonConvert.SerializeObject(this);
            Centroid c = JsonConvert.DeserializeObject<Centroid>(serializedData);
            return c;
        }

        public Int32 CompareTo(object obj) {
            return (this.location.X.CompareTo(((Centroid)obj).location.Y));
        }
    }
}
