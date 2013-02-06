using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Cramit.Data
{
    /// <summary>
    /// Contains extension methods for serializing and deserializing between
    /// CLR objects and JSON.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Deserializes the specified JSON string.
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserialize<T>(this string json)
        {
            var bytes = Encoding.Unicode.GetBytes(json);
            using (var stream = new MemoryStream(bytes))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

        /// <summary>
        /// Serializes the specified object to JSON.
        /// </summary>
        /// <param name="instance">The object to serialize.</param>
        /// <returns>JSON representation of the specified object.</returns>
        public static string Serialize(this object instance)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(instance.GetType());
                serializer.WriteObject(stream, instance);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                { 
                    return reader.ReadToEnd(); 
                }
            }
        }
    }
}
