using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class TeamStat : IEquatable<TeamStat>
    {
        public int Rank { get; set; }
        public List<RoundStat> RoundStats { get; set; }
        public uint Score { get; set; }
        public int TeamId { get; set; }

        public bool Equals(TeamStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Rank == other.Rank
                && RoundStats.OrderBy(rs => rs.RoundNumber).SequenceEqual(other.RoundStats.OrderBy(rs => rs.RoundNumber))
                && Score == other.Score
                && TeamId == other.TeamId;
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

            if (obj.GetType() != typeof (TeamStat))
            {
                return false;
            }

            return Equals((TeamStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Rank;
                hashCode = (hashCode*397) ^ (RoundStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) Score;
                hashCode = (hashCode*397) ^ TeamId;
                return hashCode;
            }
        }

        public static bool operator ==(TeamStat left, TeamStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamStat left, TeamStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class RoundStat : IEquatable<RoundStat>
    {
        public int Rank { get; set; }
        public int RoundNumber { get; set; }
        public uint Score { get; set; }

        public bool Equals(RoundStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Rank == other.Rank
                && RoundNumber == other.RoundNumber
                && Score == other.Score;
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

            if (obj.GetType() != typeof (RoundStat))
            {
                return false;
            }

            return Equals((RoundStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Rank;
                hashCode = (hashCode*397) ^ RoundNumber;
                hashCode = (hashCode*397) ^ (int) Score;
                return hashCode;
            }
        }

        public static bool operator ==(RoundStat left, RoundStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoundStat left, RoundStat right)
        {
            return !Equals(left, right);
        }
    }
}