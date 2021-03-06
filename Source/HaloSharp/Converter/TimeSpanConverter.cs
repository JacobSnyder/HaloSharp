﻿using Newtonsoft.Json;
using System;
using System.Xml;

namespace HaloSharp.Converter
{
    internal class TimeSpanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (TimeSpan) || objectType == typeof (TimeSpan?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<string>(reader);

            try
            {
                return XmlConvert.ToTimeSpan(value);
            }
            catch
            {
                return default(TimeSpan);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}