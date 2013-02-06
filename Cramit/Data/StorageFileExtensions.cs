using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Cramit.Data
{
    /// <summary>
    /// Contains extension methods for reading and writing text from <see cref="StorageFile"/>s.
    /// </summary>
    public static class StorageFileExtensions
    {
        /// <summary> 
        /// Asynchronously write a string to a file 
        /// </summary> 
        /// <param name="storageFile">StorageFile to write text to</param> 
        /// <param name="content">Text to write</param> 
        /// <returns>Task/ void if used with await</returns> 
        async public static Task WriteAllTextAsync(this StorageFile storageFile, string content)
        {
            using (var inputStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            using (var writeStream = inputStream.GetOutputStreamAt(0))
            using (var writer = new DataWriter(writeStream))
            {
                writer.WriteString(content);
                await writer.StoreAsync();
                await writeStream.FlushAsync();
            }
        }

        /// <summary> 
        /// Asynchronously read a string from a file 
        /// </summary> 
        /// <param name="storageFile">StorageFile to read text from</param> 
        /// <returns>Task/ void if used with await</returns> 
        async public static Task<string> ReadAllTextAsync(this StorageFile storageFile)
        {
            string content;
            using (var inputStream = await storageFile.OpenAsync(FileAccessMode.Read))
            using (var readStream = inputStream.GetInputStreamAt(0))
            using (var reader = new DataReader(readStream))
            {
                uint fileLength = await reader.LoadAsync((uint)inputStream.Size);
                content = reader.ReadString(fileLength);
            }
            return content;
        }
    }
}
