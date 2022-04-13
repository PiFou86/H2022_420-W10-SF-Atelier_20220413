using Structures;


Random rnd = new Random(DateTime.Now.Millisecond);


List<Personne> personnes = new List<Personne>();


Personne pierre = new Personne() { Nom = "Nom1", Prenom = "Prenom1", Tel = "123321321", Age = 21 };
pierre.Nom = "Léon";
Console.Out.WriteLine($"Le nom de la personne est {pierre.Nom}");


//personnes.Add(pierre);

for (int i = 0; i < 100; i++)
{
    Personne personne = new Personne();
    personne.Nom = Fonctions.GenererNom();
    personne.Prenom = Fonctions.GenererPrenom();
    personne.Tel = "418 111 1111" + i.ToString();
    personne.Age = rnd.Next(0, 99);
    personnes.Add(personne);
}

foreach (Personne personne in personnes)
{
    Console.Out.WriteLine($"Prénom : {personne.Prenom} Nom : {personne.Nom} - Age : {personne.Age}");
}



Fonctions.EnregistrerPersonnes(personnes, "personnesGenerees.csv");
