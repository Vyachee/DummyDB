using Newtonsoft.Json;

namespace DummyDB
{
    public class JSONValidator
    {
        private string[] data;

        public JSONValidator(string[] input)
        {
            data = input;
        }

        public bool CheckBySchema(JSONSchema schema)
        {
            bool checkedColumns = CheckColumns(schema);
            bool flag = true;
            for (int i = 1; i < data.Length; i++)
            {
                flag = CheckTypes(data[i], schema, i);
                if (!flag)
                    return false;
            }

            return flag && checkedColumns;
        }

        public JSONSchema GetSchema(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<JSONSchema>(fileText);
        }

        private bool CheckTypes(string input, JSONSchema schema, int raw)
        {
            string[] line = input.Split(';');
            for (int i = 0; i < line.Length; i++)
            {
                switch (schema.Elements[i].Type)
                {
                    case "int":
                        if (!int.TryParse(line[i], out int number))
                        {
                            ShowError(raw, i, line);
                            return false;
                        }
                        break;
                    case "bool":
                        if (!bool.TryParse(line[i], out bool statement))
                        {
                            ShowError(raw, i, line);
                            return false;
                        }
                        break;
                    case "dateTime":
                        if (!DateTime.TryParse(line[i], out DateTime  time))
                        {
                            ShowError(raw, i, line);
                            return false;
                        }
                        break;
                    default:
                        break;
                }

            }

            return true;
        }

        private bool CheckColumns(JSONSchema schema)
        {
            string[] programInput = data[0].Split(';');
            for (int i = 0; i < programInput.Length; i++)
            {
                if (programInput[i] != schema.Elements[i].Name)
                {
                    ShowError(0, 0, programInput);
                    return false;
                }

            }

            return true;
        }

        private void ShowError(int lineNumber, int columnNumber, string[] line)
        {
            throw new FormatException($"Ошибка!\nНеверный тип в {lineNumber} строке, элемент номер {columnNumber} ({line[columnNumber]})");
        }

    }

}