using NUnit.Framework;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;
using System.IO;
using System;

namespace Lv1Ls1
{

    [TestFixture]
    public class UnitTest1
    {
        JArray arrJsonAdmin = new JArray();
        JArray arrJsonReg = new JArray();
        JArray arrYamlAdmin = new JArray();
        JArray arrYamlReg = new JArray();

        [SetUp]
        public void getdata()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory; //Ссылка на корневую папку проекта
            
            arrJsonAdmin = getArrFromJSON(Path.Combine(exePath, "DataSet\\admin_users.json"));
            arrJsonReg = getArrFromJSON(Path.Combine(exePath, "DataSet\\regular_users.json"));
            arrYamlAdmin = getArrFromYAML(Path.Combine(exePath, "DataSet\\admin_users.yaml"));
            arrYamlReg = getArrFromYAML(Path.Combine(exePath, "DataSet\\regular_users.yaml"));
        }


        [Test]
        public void IsUsersInJSON()
        {
            bool isUsersInJSON = true;
            foreach (JObject jObject in arrJsonAdmin)
            {
                if (jObject.ContainsKey("id") && jObject.ContainsKey("name")) continue;
                else isUsersInJSON = false;
            }

            foreach (JObject jObject in arrJsonReg)
            {
                if (jObject.ContainsKey("id") && jObject.ContainsKey("name")) continue;
                else isUsersInJSON = false;
            }

            Assert.IsTrue(isUsersInJSON);
        }

        [Test]
        public void IsUsersInYAML()
        {
            bool isUsersInJSON = true;
            foreach (JObject jObject in arrYamlAdmin)
            {
                if (jObject.ContainsKey("id") && jObject.ContainsKey("name")) continue;
                else isUsersInJSON = false;
            }

            foreach (JObject jObject in arrYamlReg)
            {
                if (jObject.ContainsKey("id") && jObject.ContainsKey("name")) continue;
                else isUsersInJSON = false;
            }

            Assert.IsTrue(isUsersInJSON);
        }

        [Test]
        public void IsJSONUsersIncludInYAML()
        {
            int countOfSameUsersAdmin = 0;
            int countOfSameUsersReg = 0;
            bool isUserAreSame = false;

            foreach (JObject JASONjObject in arrJsonAdmin)
            {
                foreach(JObject YAMLjObject in arrYamlAdmin)
                {
                    if ((int)JASONjObject["id"] == (int)YAMLjObject["id"])
                    {
                        countOfSameUsersAdmin++;
                        break;
                    }
                }
            }

            foreach (JObject JASONjObject in arrJsonReg)
            {
                foreach (JObject YAMLjObject in arrYamlReg)
                {
                    if ((int)JASONjObject["id"] == (int)YAMLjObject["id"])
                    {
                        countOfSameUsersReg++;
                        break;
                    }
                }
            }

            if (arrJsonAdmin.Count == countOfSameUsersAdmin && arrJsonReg.Count == countOfSameUsersReg) 
                isUserAreSame = true;

            Assert.IsTrue(isUserAreSame);
        }

        [TearDown]
        public void teardoun()
        {
            arrJsonAdmin.Clear();
            arrJsonReg.Clear();
            arrYamlAdmin.Clear();
            arrYamlReg.Clear();
        }




        //Метод преобразования файла JSON в массив JArray
        public JArray getArrFromJSON(string path)
        {
            string strJsonFromFile;
            JArray jArray = new JArray();

            using (StreamReader reader = new StreamReader(path))
            {
                strJsonFromFile = reader.ReadToEnd();
            }

            jArray = JArray.Parse(strJsonFromFile);


            return jArray;
        }

        //Метод преобразования файла YAML в массив JArray
        public JArray getArrFromYAML(string path)
        {
            string strYamlFromFile;
            string finStrYaml;
            JArray jArray = new JArray();

            using (StreamReader reader = new StreamReader(path))
            {
                strYamlFromFile = reader.ReadToEnd();
            }

            var _reader = new StringReader(strYamlFromFile);
            var _writer = new StringWriter();

            var deserializer = new Deserializer();
            var yamlObject = deserializer.Deserialize(_reader);

            var serializer = new Serializer(SerializationOptions.JsonCompatible);
            serializer.Serialize(_writer, yamlObject);
            finStrYaml = _writer.ToString();

            jArray = JArray.Parse(finStrYaml);

            return jArray;
        }
    }

}
