
using System.Text;

class Program
{

    //2.Déplacez les quatre premiers chiffres(code de pays et deux chiffres de contrôle) à l'arrière du numéro de compte.

    //3.Convertissez les lettres du code de pays en chiffres via le système de l'alphabet romain (<>chiffres romains !!!), où A=10, B=11, C=12. Pour "BE", "B" = 11 et "E" = 14. Vous devriez maintenant avoir une chaîne de chiffres uniquement.

    //4.Effectuez un module 97 sur la chaîne de nombres.Le MOD97 doit renvoyer le reste de la dérivation.

    //5.Soustrayez 98 avec le reste de l'opération MOD97. Il s'agit du chiffre de contrôle IBAN. Si le chèque renvoie un seul chiffre, insérez un « 0 » devant.

    static void Generate_Iban_From_Bban()
    {
        string code_pays_string = string.Empty;
        string country_code_string = "BE";
        string account_number = "950153408865";
        var iban = new StringBuilder();
        long check_digit;


        for (int i = 0; i < country_code_string.Length; i++)
        {
            int code_pays_int = country_code_string[i] - 55;
            code_pays_string += code_pays_int.ToString();
        }
        var sb = new StringBuilder(account_number + code_pays_string + "00");

        bool check = long.TryParse(sb.ToString(), out long x);

        if (check)
        {
            long modulo97 = x % 97;
            check_digit = 98 - modulo97;
            if (check_digit < 10)
            {
                iban.Append(country_code_string + "0" + check_digit + account_number);
            }
            else
            {
                iban.Append(country_code_string + check_digit + account_number);
            }

            Console.WriteLine(iban);
        }
    }

    static void Main(string[] args)
    {
        
        // EXO 1 ////////////////////////////////////////////////

        Console.WriteLine("Entrez une année : ");
        Console.WriteLine();

        string? annee_string = Console.ReadLine(); ;
        int.TryParse(annee_string, out int annee_int);

        if ((annee_int % 4 == 0) && (annee_int % 100 != 0) || (annee_int % 400 == 0))
        {
            Console.WriteLine($"L'année {annee_int} est une année bisextile");
        }
        else
        {
            Console.WriteLine($"L'année {annee_int} est une année bisextile");
        }

        // EXO 2 ////////////////////////////////////////////////

        static int Calculer(int nbr_1, int nbr2)
        {
            int division_entiere = (nbr_1 / nbr2);
            int modulo = (nbr_1 % nbr2);
            double division = ((double)nbr_1 / nbr2);


            Console.WriteLine($"La division entière de {nbr_1} et {nbr2} donne : {division_entiere}");
            Console.WriteLine($"Le modulo de {nbr_1} et {nbr2} donne : {modulo}");
            Console.WriteLine($"La division de {nbr_1} et {nbr2} donne : {division}");

            return 0;
        }

        int nombreA = 5;
        int nombreB = 2;

        Calculer(nombreA, nombreB);

        //EXO 3 ////////////////////////////////////////////////

        long bban = 734061189800;
        long last_10_Digit_Long = bban / 100;

        long modulo = (last_10_Digit_Long % 97);
        string first_10_Digit_String = bban.ToString();

        int startIndex = 10;
        int lastIndex = first_10_Digit_String.Length - 10;

        string last_2_digit_string = first_10_Digit_String.Substring(startIndex, lastIndex);
        bool check = int.TryParse(last_2_digit_string, out int last_2_digit_int);

        if (check)
        {

            if (modulo == bban % 100)
            {
                Console.WriteLine("OK");
            }
            else if (last_2_digit_int == 0)
            {
                Console.WriteLine("Le BBAN termine par 97");
            }
            else

            {
                Console.WriteLine("NOK");
            }
        }
        else
        {
            Console.WriteLine("Une erreur s'est produite.");
        }

        // EXO 4 ////////////////////////////////////////////////

        Generate_Iban_From_Bban(); 

    }
}