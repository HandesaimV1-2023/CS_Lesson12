using System.Configuration;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using Lesson12Group1;
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
string x = ConfigurationManager.AppSettings["xmlpath"] ?? throw new Exception("הנתיב לא נמצא"); ;
//XElement root = XDocument.Load(x)?.Root ?? throw new Exception("אין תוכן בקובץ");

string colorname = ConfigurationManager.AppSettings["color"] ?? throw new Exception("הנתיב לא נמצא"); ;
Console.BackgroundColor = Enum.Parse<ConsoleColor>(colorname);
Console.WriteLine("sdfasdfasdfa");

List<Person> lst = new()
{
    new Person() { Name = "sara", NumOfChildren = 10 },
    new Person() { Name = "lea", NumOfChildren = 5 }

};
StreamWriter w = new StreamWriter("file.xml");
XmlSerializer ser = new( typeof(List<Person>));
ser.Serialize(w, lst);
w.Close();
StreamReader r = new StreamReader("file.xml");
List<Person> per = (List<Person>)ser.Deserialize(r);
 string s= JsonSerializer.Serialize<List<Person>>(lst);
StreamWriter wjson = new StreamWriter("file.json");
wjson.Write(s);
wjson.Close();
Console.Read();