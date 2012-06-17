namespace Kodefu
{
    using System;

    /// <summary>
    /// ISO 6709
    /// </summary>
    public partial struct GeographicPoint
    {
        private readonly float latitude;
        private readonly float longitude;
        private readonly int altitude;

        public float Latitude
        {
            get { return latitude; }
        }

        public float Longitude
        {
            get { return longitude; }
        }

        public int Altitude
        {
            get { return altitude; }
        }

        public GeographicPoint(float latitude, float longitude)
            : this(latitude, longitude, 0)
        {
        }

        public GeographicPoint(double latitude, double longitude)
            : this((float)latitude, (float)longitude, 0)
        {
        }

        public GeographicPoint(double latitude, double longitude, int altitude)
            : this((float)latitude, (float)longitude, altitude)
        {
        }

        public GeographicPoint(float latitude, float longitude, int altitude)
        {
            if (altitude > 9999 || altitude < -9999)
            {
                throw new ArgumentOutOfRangeException("Altitude is limited to ±9999.");
            }

            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
        }

        public override string ToString()
        {
            string lat = this.latitude.ToString("+00.####;-00.####");
            string lon = FormatLongitude(this.longitude, GetPrecision(lat));
            return lat + lon + FormatAltitude(altitude) + "/";
        }

        private static string FormatLongitude(float degree, int precision)
        {
            string format = "000." + String.Empty.PadRight(precision, '0');
            return degree.ToString(String.Format("+{0};-{0}", format));
        }

        private static int GetPrecision(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }

            var arr = value.Split('.');
            return arr.Length > 1 ? arr[1].Length : 0;
        }

        private static string FormatAltitude(int altitude)
        {
            return altitude == 0 ? String.Empty : altitude.ToString("+####;-####");
        }

        public static bool operator ==(GeographicPoint first, GeographicPoint second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(GeographicPoint first, GeographicPoint second)
        {
            return !first.Equals(second);
        }

        public override int GetHashCode()
        {
            return (int)this.latitude ^ (int)this.longitude ^ this.altitude;
        }

        public override bool Equals(object obj)
        {
            if (obj is GeographicPoint)
            {
                return Equals((GeographicPoint)obj);
            }

            return false;
        }

        public bool Equals(GeographicPoint other)
        {
            return this.latitude == other.latitude
                && this.longitude == other.longitude
                && this.altitude == other.altitude;
        }
    }
}
