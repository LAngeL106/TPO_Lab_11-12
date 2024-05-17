using OpenQA.Selenium;
using System.Xml;


namespace Lab11_12
{
    public class Utils
    {
        
        public static User? GetInfoFromFile()
        {
            User user = new User();
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("C:\\Users\\Алина\\Desktop\\БГТУ\\ЛР\\Lab_11-12\\Lab_11-12\\Framework\\Input.xml");

                user.username = xmlDoc?.SelectSingleNode("/credentials/login")?.InnerText;
                user.password = xmlDoc?.SelectSingleNode("/credentials/password")?.InnerText;

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
                return null;
            }
        }
        public static string GetQuantitySymbols(string str)
        {
            return str.Length.ToString();
        }
        public static string RemoveQuotes(string input)
        {
            string resultStr = input.Replace("«", "");
            resultStr = resultStr.Replace("»", "");
            return resultStr;
        }
        
        public static bool CheckRegionProductName(IList<IWebElement> divElements)
        {
            foreach (var element in divElements)
            {
                string text = element.Text.ToLower();
                if (!text.Contains("минск"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
