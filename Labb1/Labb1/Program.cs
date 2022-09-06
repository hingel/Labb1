//Console.WriteLine("Enter input or press enter to use default string.");

//string input = Console.ReadLine();

string input = "29535123p48723487597645723645";
char searchChar;

long totalSum = 0;
long sum = 0;

string firstString = string.Empty;
string numberString = string.Empty; //som ska summeras och färgas
string secondString = string.Empty;
bool checkConv = false; //om konvertering gått igenom
bool lastPart= false; //Om sista delen ska fyllas i

//Loop för att gå igenom alla indexering av strängen
for (int i = 0; i < input.Length; i++)
{
    searchChar = input[i]; //Vad som ska letas efter
    numberString += input[i];
    
    for (int j = i + 1; j < input.Length; j++)
    {
        if (!lastPart)  //
        {
            numberString += input[j]; //lägger till delar till siffersträngen
        }

        //Här måste den sista sträng delen göras, om vi fått ok på variabeln nedan. Placeras ovan checken nedan för att få utskriften ok.
        if (lastPart)
        {
            secondString += input[j];
        }

        if (input[j] == searchChar && lastPart == false) //då har nästa likadana värde hittats, inte samma som första siffran
        {            
            checkConv = long.TryParse(numberString, out sum); //Kör try parse här om det går att konvertera texten.

            if (checkConv) //om konvertering gick igenom
            {
                totalSum += sum; //lägg sum till totalsumman
                lastPart = true; //Då börja på sista strängen
            }

            else if (!checkConv) //Om konverteringen ej går igenom
            {
                numberString = string.Empty;
                //och sen börja om från början för nästa i position. i position med ett nytt sökvärde
                break;
            }
        }
    }

    if (checkConv) //Om konvertering blivit lyckad vill vi skriva ut.
    {
        lastPart = false;
        //Här nere ska strängen skrivas ut
        Console.WriteLine("{0},{1},{2} i: {3} searchChar: {4}", firstString, numberString, secondString, i, searchChar);
        numberString = string.Empty;
        secondString = string.Empty;
        checkConv = false;
        firstString += input[i]; //Lägga till sist för att inte komma med i utskriften, men ska alltid summeras.
    }

    else
    {
        numberString = string.Empty;
        secondString = string.Empty;
        lastPart = false;
        firstString += input[i]; //summera ihop strängen.
    }
}

Console.WriteLine("Summan är: " + totalSum);