
namespace Structures
{
    public class Fonctions
    {
        public static string nomFichierPrenoms = "prenoms.csv";
        public static Random rnd = new Random(DateTime.Now.Millisecond);
        public static string[] prenoms = null;
        //public static string[] prenoms = new string[] { "ARTHUR", "ARNAUD", "ALEXIS", "ADAM", "ANTOINE", "AXEL", "ANTHONY", "ALBERT", "ALEXANDRE", "AYDEN", "ADRIEN", "ALI", "ALEX", "AIDEN", "AUGUSTE", "ANDREW", "ALEXANDER", "AMIR", "ADRIAN", "ANDY", "ALEC", "AARON", "ABEL", "ANAS", "ALEXY", "ALEK", "AYLAN", "ALFRED", "ARLO", "ADRIANO", "ALESSIO", "ALEXI", "ARNO", "ALIX", "AHMED", "ABRAHAM", "AUGUSTIN", "AYOUB", "ADEM", "AIDAN", "ALAN", "ASHER", "AUGUST", "ARIS", "ANTONIO", "ADAMO", "ALESSANDRO", "AUSTIN", "AYAN", "AMINE", "AKSIL", "AKSEL", "AHMAD", "ANGELO", "ANTONIN", "ASHTON", "ANTONY", "AMADOU", "ANIS", "ALPHONSE", "AVERY", "ACHILLE", "ARMAND", "AYLANE", "ANDRE", "ANGEL", "AKRAM", "ARCHIE", "AREN", "ALEJANDRO", "ABDOULAYE", "AYMAN", "ARIEL", "ASAEL", "ADRIEL", "AMAR", "ALARIC", "ANAKIN", "ALLAN", "ALECK", "AYMEN", "AVRUM", "ARHAM", "AZIZ", "ANDRES", "AJAY", "ANASS", "ANDREA", "AEDEN", "AYAAN", "AKIM", "ALYX", "ARON", "ANTON", "ANTONI", "ALY", "ALEKSY", "ANIR", "ALIOUNE", "ALISTAIR"};

        public static string GenererChaine(int p_longueurMin, int p_longueurMax)
        {
            if (p_longueurMin < 0)
            {
                throw new ArgumentException("La longueur minimum doit être nulle ou positive", nameof(p_longueurMin));
            }
            if (p_longueurMin > p_longueurMax)
            {
                throw new ArgumentException("La longueur maximum doit être supérieure ou égale à la longueur minimale", nameof(p_longueurMax));
            }

            int longueurChaine = rnd.Next(p_longueurMin, p_longueurMax + 1);
            string chaineAleatoire = "";
            for (int numCaractere = 0; numCaractere < longueurChaine; numCaractere++)
            {
                chaineAleatoire += (char)rnd.Next('a', 'z' + 1);
            }

            return chaineAleatoire;
        }

        public static string GenererChaine2(int p_longueurMin, int p_longueurMax)
        {
            if (p_longueurMin < 0)
            {
                throw new ArgumentException("La longueur minimum doit être nulle ou positive", nameof(p_longueurMin));
            }
            if (p_longueurMin > p_longueurMax)
            {
                throw new ArgumentException("La longueur maximum doit être supérieure ou égale à la longueur minimale", nameof(p_longueurMax));
            }

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int longueurChaine = rnd.Next(p_longueurMin, p_longueurMax + 1);
            string chaineAleatoire = "";
            for (int numCaractere = 0; numCaractere < longueurChaine; numCaractere++)
            {
                chaineAleatoire += alphabet[rnd.Next(0, alphabet.Length)];
            }

            return chaineAleatoire;
        }

        public static string GenererPrenom()
        {
            if (prenoms is null)
            {
                prenoms = LirePrenomsDansFichier2(nomFichierPrenoms).ToArray();
            }

            return prenoms[rnd.Next(0, prenoms.Length)];
        }

        public static string GenererNom()
        {
            if (prenoms is null)
            {
                prenoms = LirePrenomsDansFichier2(nomFichierPrenoms).ToArray();
            }

            return prenoms[rnd.Next(0, prenoms.Length)];
        }

        public static List<string> LirePrenomsDansFichier(string p_nomFichier)
        {
            if (string.IsNullOrWhiteSpace(p_nomFichier))
            {
                throw new ArgumentException("Le fichier....", nameof(p_nomFichier));
            }

            if (!File.Exists(p_nomFichier))
            {
                throw new ArgumentException($"Le fichier {p_nomFichier} n'existe pas !", nameof(p_nomFichier));
            }

            List<string> prenoms = new List<string>();
            string contenuFichier = File.ReadAllText(p_nomFichier);
            string[] lignes = contenuFichier.Split("\r\n");

            for (int numLigne = 0; numLigne < lignes.Length; numLigne++)
            {
                //Console.Out.WriteLine($"{numLigne} : {lignes[numLigne]}");
                string ligne = lignes[numLigne];
                string[] colonnes = ligne.Split(";");
                prenoms.Add(colonnes[0]);
            }

            return prenoms;
        }

        public static List<string> LirePrenomsDansFichier2(string p_nomFichier)
        {
            if (string.IsNullOrWhiteSpace(p_nomFichier))
            {
                throw new ArgumentException("Le fichier....", nameof(p_nomFichier));
            }

            if (!File.Exists(p_nomFichier))
            {
                throw new ArgumentException($"Le fichier {p_nomFichier} n'existe pas !", nameof(p_nomFichier));
            }

            List<string> prenoms = new List<string>();
            using (StreamReader sr = new StreamReader(p_nomFichier))
            {
                while (!sr.EndOfStream)
                {
                    string ligne = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ligne))
                    {
                        string[] colonnes = ligne.Split(";");
                        prenoms.Add(colonnes[0]);
                    }
                }
                sr.Close();
            }

            return prenoms;
        }

        public static void EnregistrerPersonnes(List<Personne> p_personnes, string p_nomFichierPersonnes)
        {
            if (p_personnes is null)
            {
                throw new ArgumentException("La liste de personnes ne doit pas être nulle", nameof(p_personnes));
            }
            if (string.IsNullOrWhiteSpace(p_nomFichierPersonnes))
            {
                throw new ArgumentException("Le nom du fichier ne doit pas être vide ou null", nameof(p_nomFichierPersonnes));
            }

            using (StreamWriter sr = new StreamWriter(p_nomFichierPersonnes))
            {
                sr.WriteLine($"Nom;Prenom;Tel;Age");
                foreach (Personne personne in p_personnes)
                {
                    sr.WriteLine($"{personne.Nom};{personne.Prenom};{personne.Tel};{personne.Age}");
                }

                sr.Close();
            }
        }
    }

}