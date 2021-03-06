using HaloSharp.Model.Stats.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.Lifetime.Common
{
    [Serializable]
    public class BaseServiceRecord : IEquatable<BaseServiceRecord>
    {
        public Dictionary<string, Link> Links { get; set; } // Internal use only.

        public bool Equals(BaseServiceRecord other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof (BaseServiceRecord))
            {
                return false;
            }

            return Equals((BaseServiceRecord) obj);
        }

        public override int GetHashCode()
        {
            return Links?.GetHashCode() ?? 0;
        }

        public static bool operator ==(BaseServiceRecord left, BaseServiceRecord right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseServiceRecord left, BaseServiceRecord right)
        {
            return !Equals(left, right);
        }
    }
}