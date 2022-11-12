using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WanCeDesktopApp.Common
{
    public static class XmlProvider
    {
        /// <summary>
        /// 将一个实体类生成xml文件到指定路径
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="sourceObj"></param>
        public static void Save<T>(string filePath, T sourceObj)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return;

            string folder = Tools.ToString(Path.GetDirectoryName(filePath));

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }

        /// <summary>
        /// xml文件解析，得到实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T? Load<T>(string filePath)
        {
            object? result = null;
            try
            {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    result = xmlSerializer.Deserialize(reader);
                }
            }
            return (T)result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default(T);
            }
        }
    }
}
