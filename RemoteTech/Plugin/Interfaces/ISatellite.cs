using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RemoteTech
{
    public interface ISatellite {

        String Name { get; set; }
        Guid Guid { get; }
        Vector3 Position { get; }
        ISignalProcessor SignalProcessor { get; set; }
        bool Powered { get; }

        float OmniRange { get; }
        IEnumerable<Pair<Guid, float>> DishRange { get; }
    }

    public static class ISatelliteExtensions {
        public static float IsPointingAt(this ISatellite a, ISatellite b) {
            return a.DishRange.Max(x => (x.First == b.Guid) ? x.Second : 0.0f);
        }
    }
}
