using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

// Classe statique Program pour encapsuler le point d'entrée de l'application
class Program
{
  public static void Main()
  {
    // Chemin du fichier JSON et lecture du contenu
    string jsonFilePath = "employees.json";
    string jsonString = File.ReadAllText(jsonFilePath);

    // Vérifier si le fichier JSON est vide
    if (string.IsNullOrEmpty(jsonString))
    {
      Console.WriteLine("Le fichier JSON est introuvable ou vide.");
      return;
    }

    // Désérialiser les employés à partir du JSON
    List<Employee> employees = DeserializeEmployees(jsonString);

    // Requêtes LINQ
    var fullTimeEmployees = employees.OfType<FullTimeEmployee>().ToList();
    var totalCost = employees.Sum(e => e.GetAnnualCost());

    // Afficher les résultats
    Console.WriteLine("Employés à temps plein:");
    foreach (var emp in fullTimeEmployees)
    {
      Console.WriteLine($"ID: {emp.Id}, Nom: {emp.Name}, Salaire annuel: {emp.AnnualSalary}");
    }

    Console.WriteLine($"Coût total de tous les employés: {totalCost}");
  }

  // Méthode pour désérialiser les employés à partir du JSON
  private static List<Employee> DeserializeEmployees(string jsonString)
  {
    var options = new JsonSerializerOptions
    {
      Converters = { new EmployeeConverter() },
      PropertyNameCaseInsensitive = true
    };
    return JsonSerializer.Deserialize<List<Employee>>(jsonString, options) ?? new List<Employee>();
  }
}

// Classe de base Employee
abstract class Employee
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public abstract decimal GetAnnualCost();
}

// Classe dérivée pour les employés à temps plein
class FullTimeEmployee : Employee
{
  public decimal AnnualSalary { get; set; }
  public override decimal GetAnnualCost() => AnnualSalary;
}

// Classe dérivée pour les employés à temps partiel
class PartTimeEmployee : Employee
{
  public decimal HourlyRate { get; set; }
  public int HoursWorked { get; set; }
  public override decimal GetAnnualCost() => HourlyRate * HoursWorked;
}

// Classe dérivée pour les contractuels
class Contractor : Employee
{
  public decimal ContractAmount { get; set; }
  public override decimal GetAnnualCost() => ContractAmount;
}

// Convertisseur JSON pour désérialiser les objets Employee
class EmployeeConverter : JsonConverter<Employee>
{
  public override Employee Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using (var jsonDoc = JsonDocument.ParseValue(ref reader))
    {
      var jsonObject = jsonDoc.RootElement;
      var type = jsonObject.GetProperty("Type").GetString();
      return type switch
      {
        "FullTimeEmployee" => JsonSerializer.Deserialize<FullTimeEmployee>(jsonObject.GetRawText(), options)!,
        "PartTimeEmployee" => JsonSerializer.Deserialize<PartTimeEmployee>(jsonObject.GetRawText(), options)!,
        "Contractor" => JsonSerializer.Deserialize<Contractor>(jsonObject.GetRawText(), options)!,
        _ => throw new NotSupportedException($"Le type d'employé '{type}' n'est pas pris en charge")
      };
    }
  }

  public override void Write(Utf8JsonWriter writer, Employee value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }
}