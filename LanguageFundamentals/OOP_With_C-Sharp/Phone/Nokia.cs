using System;

namespace Phone
{
    public class Nokia : Phone, IRingable
    {
        public Nokia (string version, int batt, string carrier, string ringTone)
            : base(version, batt, carrier, ringTone){}
        public string Ring()
        {
            return RingTone;
        }
        public string Unlock()
        {
            return $"Nokia {VersionNumber} unlocked with pascode";
        }
        public override void DisplayInfo()
        {
            System.Console.WriteLine($@"
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
Version: {VersionNumber}
Battery Percentage: {BatteryPercentage}
Carrier: {Carrier}
Ring Tone: {RingTone}
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        }
    }
}