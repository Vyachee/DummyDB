namespace DummyDB
{
    public class CSVReader
    {
        public string[] ReadFromCSV(string dataFilePath, string jsonSchemaFilePath)
        {
            string[] csv = File.ReadAllLines(dataFilePath);
            JSONValidator validator = new(csv);
            JSONSchema schema = validator.GetSchema(jsonSchemaFilePath);

            if (validator.CheckBySchema(schema))
                return csv.Skip(1).ToArray();

            //try
            //{
            //    if (validator.CheckBySchema(schema))
            //        return csv.Skip(1).ToArray();
            //}
            //catch (Exception ex)
            //{
            //    if (ex.GetType() == typeof(FormatException))
            //        Console.WriteLine("Данные были введены некорректно. Проверьте их в исходных файлах и повторите попытку позже.");
            //}
            return null;
        }

    }

}