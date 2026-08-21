using ATM.Domain.Interfaces.Repostories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATM.Infrastructure.Persistence

{
    public class FileRepository<T> : IFileRepository<T>
    {
        private readonly string _filePath;
        public FileRepository(string filePath)
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files"); 
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            _filePath = Path.Combine(directory, filePath);
        }
        public async  Task<List<T>> ReadAllLinesAsync()
        {
            if(!File.Exists(_filePath))
            {
                return new List<T>(); // ვამოწმებთ არსებობს თუ არა ამ მისამრთზე ფაილი , თუ არა ვაბრუნებთ ცარიელ სიას
            }
            try
            {
                var lines = await File.ReadAllTextAsync(_filePath);  // ვკითხულობთ ფაილს ასინქრონულად
                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }// ესაა სერაილიზაცია ანი json ფორმატიდან გადმოიტანოს T ტიპის ობიექტად.
                    // Converters = { new JsonStringEnumConverter() } ნიშნავს რომ თუ T ტიპი არის enum ტიპი, ის უნდა გადაიყვანოს string ფორმატში და პირიქით.
                    // Converters არის json ის property რომელიც გვაძლევს საშუალებას დავამატოთ ჩვენი კონვერტერები, რომლებიც განსაზღვრავენ როგორ უნდა მოხდეს სერაილიზაცია ან დესერაილიზაცია.
                };
                return JsonSerializer.Deserialize<List<T>>(lines, options) ?? new List<T>();
                // დააბრუნოს დესერალიზებული ტექსტი და თუ ცარიელია მაშინ ახალი T ტიპის ობიექტების სია.
                // ?? ნიშნავს რომ თუ პირველი ნაწილი არის null მაშინ დააბრუნოს მეორე ნაწილი.

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[warning] Could not read {Path.GetFileName(_filePath)}: {ex.Message}");
                return new List<T>();
                // თუ ფაილის წაკითხვისას და სიის დბრუნებისას მოხდა შეცდომა მაინც დააბრუნოს ახალი T ტიპის ობიექტების სია.
            }

        }

      

        public async Task SaveAllAsync(List<T> data)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() },
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(data, options);
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch(Exception ex)
            {
                 throw new IOException($"Failed to save {Path.GetFileName(_filePath)}: {ex.Message}", ex);

            }
        }

        // სისტემა არის ასეთი, მკითხულოპბ მთლიან ფაილს და ვაქცევ სიად, მერე სიას ვმატებ/ვცვლი, და saveallasync() გადავცემ ამ სიას რომ შეინახოს
        // ფაილშ, ეს  ეთოდი კი თავიდან გადაააწერს overwrite გააკეთებს და მთლიან სიას თავიდან ჩაწერს.
        

    }

}
