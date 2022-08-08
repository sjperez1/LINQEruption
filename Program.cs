List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
// Query #1 - First eruption in Chile
IEnumerable<Eruption> eruptionsInChile = eruptions.Where(eruption => eruption.Location == "Chile");
object firstInChile = eruptionsInChile.First();
Console.WriteLine("First in Chile" + firstInChile);

// Query #2 - First eruption from this location if it is found
IEnumerable<Eruption> eruptionsInHawaii = eruptions.Where(eruption => eruption.Location == "Hawaiian Is");
object firstInHawaii = eruptionsInHawaii.First();
if(eruptionsInHawaii == null){
    Console.WriteLine("No Hawaiian Eruption found");
} else {
    Console.WriteLine("First in Hawaii" + firstInHawaii);
}

// Query #3 - First eruption with two conditions
IEnumerable<Eruption> NZAfter1900 = eruptions.Where(eruption => eruption.Location == "New Zealand" && eruption.Year > 1900);
object firstInNZAfter1900 = NZAfter1900.First();
Console.WriteLine("First in NZ after 1900 " + firstInNZAfter1900);

// Query #4 - All eruptions with an elevation greater than 200 meters
IEnumerable<Eruption> elevationGreaterThan2000 = eruptions.Where(eruption => eruption.ElevationInMeters > 2000);
PrintEach(elevationGreaterThan2000, "Eruptions with elevations greater 2000m");

// Query #5 - Find al volcanoes that start with "Z" and then print how many there are in that list
IEnumerable<Eruption> volcanoesStartWithZ = eruptions.Where(eruption => eruption.Volcano.StartsWith("Z"));
PrintEach(volcanoesStartWithZ, "Volcanoes with names that start with 'Z'");
Console.WriteLine("Number of Volcanoes that start with 'Z': " + volcanoesStartWithZ.Count());

// Query #6 - Find the number of the max elevation in the list of volcanoes
int maxElevation = eruptions.Max(eruption => eruption.ElevationInMeters);
Console.WriteLine("Max elevation: " + maxElevation);

// Query #7 - Print the name of the volcano with the max elevation
IEnumerable<String> maxElevationVolcanoName = eruptions.Where(eruption => eruption.ElevationInMeters == maxElevation).Select(eruption => eruption.Volcano);
PrintEach(maxElevationVolcanoName, "Volcano with max elevation: ");

// Query #8 - Print all of the volcanoes in alphabetical order
// IEnumerable<string> alphabetizedVolcanoNames = eruptions.Select(eruption => eruption.Volcano);
IEnumerable<Eruption> alphabetizedVolcanoNames = eruptions.OrderBy(eruption => eruption.Volcano);
PrintEach(alphabetizedVolcanoNames, "All alphabetized:");

// Query #9 - Print all of the volcanoes before 1000 CE in alphabetical order
IEnumerable<Eruption> alphabetizedBefore1000 = eruptions.Where(eruption => eruption.Year < 1000).OrderBy(eruption => eruption.Volcano);
PrintEach(alphabetizedBefore1000, "Before 1000 CE alphabetized:");

// Query Bonus - For query number 9, print only the names of those volcanoes
IEnumerable<String> alphabetizedBefore1000NamesOnly = eruptions.Where(eruption => eruption.Year < 1000).OrderBy(eruption => eruption.Volcano).Select(eruption => eruption.Volcano);
PrintEach(alphabetizedBefore1000NamesOnly, "Before 1000 CE alphabetized (names only):");

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}