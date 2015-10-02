using FileHelpers;
using Newtonsoft.Json;
using System;

namespace KMeans_Test {
    [DelimitedRecord(";")]
    class City : ICloneable {
        public String kabupatenKota { get; set; }
        public String ibuKota { get; set; }

        public Int32 derajatLintang { get; set; }
        public Int32 menitLintang { get; set; }
        public String lintangUtaraSelatan { get; set; }

        public Int32 derajatBujur { get; set; }
        public Int32 menitBujur { get; set; }
        public String bujurBaratTimur { get; set; }

        public object Clone() {
            String serializedData = JsonConvert.SerializeObject(this);
            City c = JsonConvert.DeserializeObject<City>(serializedData);
            return c;
        }
    }
}
