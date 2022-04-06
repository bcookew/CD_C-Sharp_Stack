using System;

namespace Phone
{
    public abstract class Phone
    {
        private string _versionNumber;
        private int _batteryPercentage;
        private string _carrier;
        private string _ringTone;
        public Phone (string v, int batt, string provider, string ringer)
        {
            _versionNumber = v;
            _batteryPercentage = batt;
            _carrier = provider;
            _ringTone = ringer;
        }

        public abstract void DisplayInfo();
        public string VersionNumber
        {
            get{return _versionNumber;}
            set{_versionNumber = value;}
        }
        public int BatteryPercentage
        {
            get{return _batteryPercentage;}
            set{_batteryPercentage = value;}
        }
        public string Carrier
        {
            get{return _carrier;}
            set{_carrier = value;}
        }
        public string RingTone
        {
            get{return _ringTone;}
            set{_ringTone = value;}
        }
    }
}