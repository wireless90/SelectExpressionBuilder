# SelectExpressionBuilder

Dynamically craft yout viewmodels by passing in a list of properties you need. The include and select expression will automatically be built.

```csharp
string[] propertyIds = new string[] 
{
    "Id", "PNames[Name]", "PName.Name",
    "PNames[Id]", "Gender", "PName.Id"
};

var people = Person.GetPeople().AsQueryable();
var result = people.ProjectToDynamic(propertyIds).ToDynamicList();
var json = JsonConvert.SerializeObject(result, Formatting.Indented);

System.Console.WriteLine(json);
```

Results:
```json
[
  {
    "Id": 1000,
    "PNames": [
      {
        "Name": "Razali2",
        "Id": 2
      },
      {
        "Name": "Razali3",
        "Id": 3
      }
    ],
    "PName": {
      "Name": "Razali",
      "Id": 1
    },
    "Gender": "Male"
  },
  {
    "Id": 2000,
    "PNames": [
      {
        "Name": "Zana2",
        "Id": 2
      },
      {
        "Name": "Zana3",
        "Id": 3
      }
    ],
    "PName": {
      "Name": "Zana",
      "Id": 1
    },
    "Gender": "Female"
  }
]
```
