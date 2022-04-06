using System;

namespace Phone
{
    public class Galaxy : Phone, IRingable
    {
        public Galaxy (string version, int batt, string carrier, string ringTone)
            : base(version, batt, carrier, ringTone){}
        public string Ring()
        {
            return RingTone;
        }

        public string Unlock()
        {
            return $"Galaxy {VersionNumber} unlocked with fingerprint scanner";
        }

        public override void DisplayInfo()
        {
            System.Console.WriteLine($@"
##############################
Version: {VersionNumber}
Battery Percentage: {BatteryPercentage}
Carrier: {Carrier}
Ring Tone: {RingTone}
##############################");
        }
    }
}