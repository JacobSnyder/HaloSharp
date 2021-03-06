﻿using HaloSharp.Converter;
using HaloSharp.Model.Stats.CarnageReport.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class CampaignMatch : BaseMatch, IEquatable<CampaignMatch>
    {
        public Enumeration.Difficulty Difficulty { get; set; }
        public bool MissionCompleted { get; set; }
        public List<CampaignMatchPlayerStat> PlayerStats { get; set; }
        public List<int> Skulls { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalMissionPlaythroughTime { get; set; }

        public bool Equals(CampaignMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && Difficulty == other.Difficulty
                && MissionCompleted == other.MissionCompleted
                && PlayerStats.OrderBy(ps => ps.Player.Gamertag).SequenceEqual(other.PlayerStats.OrderBy(ps => ps.Player.Gamertag))
                && Skulls.OrderBy(s => s).SequenceEqual(other.Skulls.OrderBy(s => s))
                && TotalMissionPlaythroughTime.Equals(other.TotalMissionPlaythroughTime);
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

            if (obj.GetType() != typeof (CampaignMatch))
            {
                return false;
            }

            return Equals((CampaignMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (int) Difficulty;
                hashCode = (hashCode*397) ^ MissionCompleted.GetHashCode();
                hashCode = (hashCode*397) ^ (PlayerStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Skulls?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ TotalMissionPlaythroughTime.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CampaignMatch left, CampaignMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignMatch left, CampaignMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignMatchPlayerStat : BasePlayerStat, IEquatable<CampaignMatchPlayerStat>
    {
        public int BiggestKillScore { get; set; }
        public int Score { get; set; }

        public bool Equals(CampaignMatchPlayerStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return base.Equals(other)
                && BiggestKillScore == other.BiggestKillScore
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

            if (obj.GetType() != typeof (CampaignMatchPlayerStat))
            {
                return false;
            }

            return Equals((CampaignMatchPlayerStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ BiggestKillScore;
                hashCode = (hashCode*397) ^ Score;
                return hashCode;
            }
        }

        public static bool operator ==(CampaignMatchPlayerStat left, CampaignMatchPlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignMatchPlayerStat left, CampaignMatchPlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}