using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace SelectExpressionBuilder.Core.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] propertyIds = new string[] 
            {
                "Id", "PNames[Name]", "PName.Name",
                "PNames[Id]", "Gender", "PName.Id"
            };

            var people = Person.GetPeople().AsQueryable();
            var result = people.ProjectToDynamic(propertyIds).ToDynamicList();
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            System.Console.WriteLine(json);
        }
    }
}
