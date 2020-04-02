using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CRadius
{
    [ServiceContract]
    public interface IRadius
    {
        [OperationContract]
        Payload Handshake();
    }

    [DataContract]
    public class Payload
    {
        [DataMember]
        public List<Rule> Rules { get; set; }

        [DataMember]
        public bool Showstopper { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public bool Error { get; set; }
    }

    [DataContract]
    public class Rule
    {
        public Rule(
            int iD,
            decimal mapLatitude,
            decimal mapLongitude,
            decimal radiusK,
            decimal warnK,
            int direction,
            string message,
            string locationName)
        {
            ID = iD;
            MapLatitude = mapLatitude;
            MapLongitude = mapLongitude;
            RadiusK = radiusK;
            WarnK = warnK;
            Direction = direction;
            Message = message;
            LocationName = locationName;
            Distance = 0;
            LocationState = 0;
            Dismissed = false;
        }

        [DataMember]
        public bool Dismissed { get; set; }

        [DataMember]
        public int LocationState { get; set; }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public decimal MapLatitude { get; set; }

        [DataMember]
        public decimal MapLongitude { get; set; }

        [DataMember]
        public decimal RadiusK { get; set; }

        [DataMember]
        public decimal WarnK { get; set; }

        [DataMember]
        public decimal Distance { get; set; }

        [DataMember]
        public int Direction { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string LocationName { get; set; }
    }
}
