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
 * kiválasztás
 * eldöntés
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

var lnCnt = pets.Count(p => p.Species == "cat" && p.Sex);
Console.WriteLine($"kandúr cicák száma: {lnCnt} db");

var lnMax = pets.Max(p => p.BirthDate);
Console.WriteLine($"legfiatalabb kiskedvenc szülinapja: {lnMax:MMMM dd.}");

var lnMinBy = pets.MinBy(p => p.Name);
Console.WriteLine($"névsorban az első kisállat: {lnMinBy}");

//a copyto nem linq
//de van rá fg. a collections.generic-ben
//var petarray = new Pet[pets.Count];
//pets.CopyTo(petarray);
//foreach (var item in petarray) Console.WriteLine($"\t - {item.Name}");

//first
var lnFirst = pets.First(p => p.Species == "dog");
Console.WriteLine($"első kutyus a listában: {lnFirst}");
//ha VAN egyezés (bármennyi), akkor rendre az ELSŐ példánnyal tér vissza
//ha NINCS egyezés 'Sequence contains no matching element' exceptiont dob

//last
var lnLast = pets.Last(p => p.Species == "dog");
Console.WriteLine($"utcsó kutyus a listában: {lnLast}");
//ha VAN egyezés (bármennyi), akkor rendre az UTOLSÓ példánnyal tér vissza
//ha NINCS egyezés 'Sequence contains no matching element' exceptiont dob

//single
var lnSingle = pets.Single(p => p.Species == "hamster");
Console.WriteLine($"az egyetlen pucpuc a listában: {lnSingle}");
//ha EGYETLEN egyezés van, akkor visszatér az egyező példánnyal
//ha TÖBB egyezés lenne, akkor 'Sequence contains more than one matching element' exceptiont dob
//ha NINCS egyezés 'Sequence contains no matching element' exceptiont dob

//firstordefault
var lnFirstOD = pets.FirstOrDefault(p => p.Species == "dog");
Console.WriteLine($"első kutyus a listában: {lnFirstOD}");
//ha VAN egyezés (bármennyi), akkor rendre az ELSŐ példánnyal tér vissza
//ha NINCS egyezés akkor típustól függően 'default' értéket ad vissza, ami:
//  érték típus esetén "általában" zéró (struct)
//  referecia típus esetén null (class)

var lnFodUnicorn = pets.FirstOrDefault(p => p.Species == "unicorn");
Console.WriteLine($"unikornisos FOD lekérdezés visszaadott értéke null-e: {lnFodUnicorn is null}");

//lastordefault
var lnLastOD = pets.LastOrDefault(p => p.Species == "dog");
Console.WriteLine($"utcsó kutyus a listában: {lnLastOD}");
//ha VAN egyezés (bármennyi), akkor rendre az UTOLSÓ példánnyal tér vissza
//ha NINCS egyezés akkor típustól függően 'default' értéket ad vissza, ami:
//  érték típus esetén "általában" zéró (struct)
//  referecia típus esetén null (class)

int[] numbers = [11, 2, 26, 33, 2, 40, 17, 1231];
var lnLodNumRef01 = numbers.LastOrDefault(n => n % 2 == 0);
Console.WriteLine($"rendre utolsó páros szám a vektorban: {lnLodNumRef01}");

int? lnLodNumRef02 = numbers.LastOrDefault(n => n % 123 == 0);
Console.WriteLine($"rendre utolsó 123al osztható szám null-e: {lnLodNumRef02 is null}");

//singleordefault
var lnSingleOD = pets.SingleOrDefault(p => p.Species == "dog" && !p.Sex);
Console.WriteLine($"az egyetlen lány kutyus a listában: {lnSingleOD}");
//ha EGYETLEN egyezés van, akkor visszatér az egyező példánnyal
//ha TÖBB egyezés lenne, akkor 'Sequence contains more than one matching element' exceptiont dob
//ha NINCS egyezés akkor típustól függően 'default' értéket ad vissza, ami:
//  érték típus esetén "általában" zéró (struct)
//  referecia típus esetén null (class)

//collections.generic
//find == [first or default],
//findall == [where]

//indexof <- linker
//(ha nem találja a megadott objectumot a kollekcióban, akkor -1el tér vissza)

int indexOfFirstUnicorn = pets.IndexOf(lnFodUnicorn);
Console.WriteLine($"első unikornis indexe: {indexOfFirstUnicorn}");

int indexOfSingleHamster = pets.IndexOf(lnSingle);
Console.WriteLine($"az egyetlen hörcsög indexe: {indexOfSingleHamster}");

var lnIsThereAnyKitten = pets.Any(p => p.Species == "cat");
Console.WriteLine($"{(lnIsThereAnyKitten ? "van" : "nincs")} cica az állatkák közt");

//.Exist() <- ue.
//.Contains() <- ennek nem prediction kell, hanem konkrét referencia

//.Sort() <- ez HELYBEN rendez(ne), az eredeti kollekció elemeinek sorrendjét változtatja meg
// viszont ami LINQ (orderby, orderbydescending, ..thenby) azok LÉTREHOZNAK egy IOrderedEnumerable kollekciót (tehát az eredeti kollekció nem változik, hanem egy rendezett projekciót készít belőle)

//olyan property alapján rendezhető egy kollekció,
//amin értelmezett [<, >, <=, >=, ==]

var lnOBNames = pets.OrderBy(p => p.Name);
Console.WriteLine("állatkák névsorrendben:");
foreach (var pet in lnOBNames)
{
    Console.WriteLine($"\t[{pets.IndexOf(pet)}.] {pet}");
}

var lnOBDAges = pets
    .OrderByDescending(p => p.Age)
    .ThenBy(p => p.Name);
Console.WriteLine("állatkák életkor szerint csökkenőben " +
    "(azn belül pedig abc rendben):");
foreach (var pet in lnOBDAges)
{
    Console.WriteLine($"\t[{pets.IndexOf(pet)}.] {pet}");
}

var lnDogs = pets.Where(p => p.Species == "dog");
Console.WriteLine("kutyák");
foreach (var pet in lnDogs)
{
    Console.WriteLine($"\t{pet}");
}

var lnGBySpecies = pets.GroupBy(p => p.Species);

Console.WriteLine("fajok szerint csopizva");
foreach (var group in lnGBySpecies.OrderBy(g => g.Key))
{
    Console.WriteLine($"\t{group.Key} ({group.Count()} db)");
    foreach (var pet in group.OrderBy(p => p.Age))
    {
        Console.WriteLine($"\t\t{pet}");
    }
}

//--------------------

var lnSpecies = pets
    .Select(p => p.Species) // <- propoerty projekció
    .Distinct() // <- ismétlődést szűr
    .Order(); // <- rendez ELEMI kollekciókat (nincs értelme a "by"-bak)
Console.WriteLine("állatfajták:");
foreach (var spe in lnSpecies)
{
    Console.WriteLine($"\t{spe}");
}


