namespace DummyDB
{
    public class CSVReader
    {
        public string[] ReadFromCSV(string dataFilePath, string jsonSchemaFilePath)
        {
            string[] csv = File.ReadAllLines(dataFilePath);
            JSONValidator validator = new(csv);
            JSONSchema schema = JSONSchema.FromJsonFile(jsonSchemaFilePath);


            try
            {
                if (validator.CheckBySchema(schema))
                    return csv[1..];
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    Console.WriteLine("Данные были введены некорректно. Проверьте их в исходных файлах и повторите попытку позже.");
            }
            return null;
        }

    }

}