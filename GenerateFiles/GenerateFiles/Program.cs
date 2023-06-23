#region Variables
string filePath = @"replay50%_10ms.asc";
string ID = "ID = 353";
string finalLine;
string[] textfromfile = File.ReadAllLines(filePath);

bool flag = false;
int aux;
double value = 0;
double firstValue = 0;
double secondValue;
int p = 0;
double auxValue = 0.010101000000000002;

StreamWriter inputfile = new StreamWriter("InputFile.txt");
StreamWriter outputfile = new StreamWriter("OutputFile.txt");
#endregion


foreach (var line in textfromfile)
{
    if (line.Contains("intrusion"))
    {
        outputfile.WriteLine("1");
        value = firstValue;
        flag = true;
    }
    if (line.Contains(ID))
    {
        p++;
        string[] splitString = line.Split(' ');

        if (!String.IsNullOrEmpty(splitString[0]))
        {
            if (!flag)
            {
                if(value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[0]) - value;
                }
                finalLine = secondValue + "," + Convert.ToInt32(splitString[3],16) + ",";
                firstValue = Double.Parse(splitString[0]);
                value = firstValue;
            }
            else
            {
                if (value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[0]) - firstValue;
                }
                finalLine = secondValue + "," + Convert.ToInt32(splitString[3],16) + ",";
                firstValue = value;
            }

            aux = Int32.Parse(splitString[20]);
            for (int i = 1; i <= aux; i++)
            {
                finalLine = finalLine + Convert.ToInt32(splitString[20 + i],16) + ",";
            }
        }
        else if (!String.IsNullOrEmpty(splitString[1]))
        {
            if (!flag)
            {
                if (value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[1]) - value;
                }
                finalLine = secondValue + "," + splitString[4] + ",";
                firstValue = Double.Parse(splitString[1]);
                value = firstValue;
            }
            else
            {
                if (value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[1]) - firstValue;
                }
                finalLine = secondValue + "," + Convert.ToInt32(splitString[4],16) + ",";
                firstValue = value;
            }

            aux = Int32.Parse(splitString[21]);
            for (int i = 1; i <= aux; i++)
            {
                finalLine = finalLine + Convert.ToInt32(splitString[21 + i],16) + ",";
            }
        }
        else if (!String.IsNullOrEmpty(splitString[2]))
        {
            if (!flag)
            {
                if (value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[2]) - value;
                }
                finalLine = secondValue + "," + Convert.ToInt32(splitString[5],16) + ",";
                firstValue = Double.Parse(splitString[2]);
                value = firstValue;
            }
            else
            {
                if (value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[2]) - firstValue;
                }
                finalLine = secondValue + "," + Convert.ToInt32(splitString[5],16) + ",";
                firstValue = value;
            }

            aux = Int32.Parse(splitString[22]);
            for (int i = 1; i <= aux; i++)
            {
                finalLine = finalLine + Convert.ToInt32(splitString[22 + i],16) + ",";
            }
        }
        else
        {
            if (!flag)
            {
                if (value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[3]) - value;
                }
                finalLine = secondValue + "," + Convert.ToInt32(splitString[6],16) + ",";
                firstValue = Double.Parse(splitString[3]);
                value = firstValue;
            }
            else
            {
                if (value == 0)
                {
                    secondValue = auxValue;
                }
                else
                {
                    secondValue = Double.Parse(splitString[3]) - firstValue;
                }
                finalLine = secondValue + "," + Convert.ToInt32(splitString[6],16) + ",";
                firstValue = value;
            }

            aux = Int32.Parse(splitString[23]);
            for (int i = 1; i <= aux; i++)
            {
                finalLine = finalLine + Convert.ToInt32(splitString[23 + i],16) + ",";
            }
        }

        for (int i = 0; i < 8 - aux; i++)
        {
            finalLine = finalLine + "0";
            if (i < 8 - aux - 1)
            {
                finalLine = finalLine + ",";
            }
        }

        inputfile.WriteLine(finalLine);
        

        if (!flag)
        {
            outputfile.WriteLine("0");
        }
        flag = false;
    }
}
inputfile.Close();
outputfile.Close();

