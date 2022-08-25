using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrelStateUniversity.API.Models;

namespace OrelStateUniversity.API.Converters;

internal class ScheduleJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Schedule);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var schedule = new Schedule();

        // Return an empty schedule when an array is received.
        if (reader.TokenType == JsonToken.StartArray)
        {
            reader.Skip();
            return schedule;
        }
        
        JToken root = JToken.Load(reader);
        foreach (JToken token in root.Values())
        {
            if (token == null)
            {
                continue;
            }

            Lesson? lesson = JsonConvert.DeserializeObject<Lesson>(token.ToString());
            if (lesson == null)
            {
                continue;
            }

            schedule.Lessons.Add(lesson);
        }    

        return schedule;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
