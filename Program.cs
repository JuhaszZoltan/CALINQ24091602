using CALINQ24091602;

#region list of pets
List<Pet> pets = [
    new Pet() //01
    {
        Name = "Mr. Wick",
        Species = "hamster",
        BirthDate = new(2022, 05, 05),
        Sex = true,
    },
    new Pet() //02
    {
        Name = "Ferenc",
        Species = "cat",
        BirthDate = new(2018, 01, 02),
        Sex = false,
    },
    new Pet() //03
    {
        Name = "Maci",
        Species = "dog",
        BirthDate = new(2019, 11, 10),
        Sex = true,
    },
    new Pet() //04
    {
        Name = "Macska",
        Species = "cat",
        BirthDate = new(2024, 02, 10),
        Sex = false,
    },
    new Pet() //05
    {
        Name = "Hal",
        Species = "fish",
        BirthDate = new(2005, 04, 15),
        Sex = true,
    },
    new Pet() //06
    {
        Name = "Sziszi",
        Species = "dog",
        BirthDate = new(2022, 09, 20),
        Sex = false,
    },
    new Pet() //07
    {
        Name = "Csirke",
        Species = "chicken",
        BirthDate = new(2020, 08, 07),
        Sex = false,
    },
];
#endregion

/* "ismert" nevezetes algoritmusok:
 * (másolás)
 * sorozatszámítás -> összegzés ==> átlagszámítás
 * megszámlálás
 * szélsőérték meghatározás (min, max)
 * 'keresés'
 * eldöntés
 * kiválasztás
 * --------------------
 * 'rendezés'
 * kiválogatás
 * szétválogatás
 * halmaztételek (metszet, unió, különbség)
*/

Console.WriteLine($"állatkák száma: {pets.Count}");

var lnSum = pets.Sum(p => p.Age);
Console.WriteLine($"eddig boldogítottak minket kisállataink összesen: {lnSum} év");

var lnAvg = pets.Average(p => p.Age);
Console.WriteLine($"állatok átlagéletkora: {lnAvg:0.00} év");