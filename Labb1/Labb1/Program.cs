//Lab1
Console.WriteLine("Enter a string or press enter to use default string:");
string input = Console.ReadLine();
Console.WriteLine();

if (input == "")
{
    input = "29535123p48723487597645723645";
}

long totalSum = 0;
long sum = 0;
string firstString = string.Empty;
string numberString = string.Empty; //som ska summeras och färgas
string secondString = string.Empty;
bool checkConv = false; //om konvertering gått igenom
bool lastPart = false; //Om sista delen ska fyllas i

for (int i = 0; i < input.Length; i++)
{
    numberString += input[i];
    
    for (int j = i + 1; j < input.Length; j++)
    {
        if (!lastPart)  //om den ska fylla på numberString eller sista delen
        {
            numberString += input[j]; 
        }

        else //Här summeras sista delen av strängen. Placeras ovan för att tilläggen ska ske efter nummersträngen är ok
        {
            secondString += input[j];
        }

        if (input[j] == input[i] && lastPart == false) //då har nästa likadana värde hittats, men letar inte efter andra delen
        {            
            checkConv = long.TryParse(numberString, out sum);

            if (checkConv) //om konvertering gick igenom
            {
                totalSum += sum;
                lastPart = true; //Då börja på sista strängen
            }

            else if (!checkConv) //Om konverteringen ej går igenom
            {
                numberString = string.Empty;
                break; //och sen börja om från början för nästa 'i'-position i yttersta loopen.
            }
        }
    }

    if (checkConv) //Om konvertering blivit lyckad vill vi skriva ut.
    {
        Console.Write($"{firstString}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{numberString}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write($"{secondString}");
        Console.WriteLine();

        numberString = string.Empty;
        secondString = string.Empty;
        lastPart = false;
        checkConv = false;

        firstString += input[i]; //Lägga till sist för att inte komma med i utskriften, men ska alltid summeras.
    }

    else
    {
        numberString = string.Empty;
        secondString = string.Empty;
        lastPart = false;
        firstString += input[i]; //summera ihop första strängen.
    }
}

Console.WriteLine("Total sum is: " + totalSum);