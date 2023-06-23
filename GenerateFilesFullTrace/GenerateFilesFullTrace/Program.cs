#region Variables
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.X86;

string filePath = @"random50%_full.asc";
string[] textFromFile = File.ReadAllLines(filePath);
string finalLine;

StreamWriter inputfile = new StreamWriter("InputFile.txt");
StreamWriter outputfile = new StreamWriter("OutputFile.txt");



bool flag = false;

List<int> Aux = new List<int>
{
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
};
List<double> FirstValues = new List<double>
{
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
};
List<double> SecondValues = new List<double>
{
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
};
List<string> IDs = new List<string>
{
    "421",
    "353",
    "505",
    "385",
    "644",
    "645",
    "580",
    "1361",
    "1297",
    "1501",
    "1628",
    "852",
};
List<double> Values = new List<double>
{
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
};
List<double> AuxValues = new List<double>
{
    0.010,
    0.010,
    0.010,
    0.010,
    0.020,
    0.020,
    0.020,
    0.100,
    0.100,
    0.100,
    0.100,
    0.040,
};
#endregion

foreach (var line in textFromFile)
{
    if (line.Contains("intrusion"))
    {

        outputfile.WriteLine("1");
        //value = FirstValues[index];
        foreach (var id in IDs)
        {
            if (line.Contains(id))
            {
                var index = IDs.IndexOf(id);
                Values[index] = FirstValues[index];
            }
        }
        flag = true;
    }
    foreach (var id in IDs)
    {
        if (!line.Contains("Statistic"))
        {
            if (line.Contains(id))
            {
                string[] splitString = line.Split(' ');
                var index = IDs.IndexOf(id);

                if (flag == true)
                {
                    Values[index] = FirstValues[index];
                }
                //string[] splitString = line.Split(' ');
                //var index = IDs.IndexOf(id);

                if (!String.IsNullOrEmpty(splitString[0]))
                {
                    if (!flag)
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[0]) - Values[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[3],16) + ",";
                        FirstValues[index] = Double.Parse(splitString[0]);
                        Values[index] = FirstValues[index];
                    }
                    else
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[0]) - FirstValues[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[3], 16) + ",";
                        FirstValues[index] = Values[index];
                    }

                    Aux[index] = Int32.Parse(splitString[20]);
                    for (int i = 1; i <= Aux[index]; i++)
                    {
                        finalLine = finalLine + Convert.ToInt32(splitString[20 + i],16) + ",";
                    }
                }
                else if (!String.IsNullOrEmpty(splitString[1]))
                {
                    if (!flag)
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[1]) - Values[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[4], 16) + ",";
                        FirstValues[index] = Double.Parse(splitString[1]);
                        Values[index] = FirstValues[index];
                    }
                    else
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[1]) - FirstValues[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[4], 16) + ",";
                        FirstValues[index] = Values[index];
                    }

                    Aux[index] = Int32.Parse(splitString[21]);
                    for (int i = 1; i <= Aux[index]; i++)
                    {
                        finalLine = finalLine + Convert.ToInt32(splitString[21 + i],16) + ",";
                    }
                }
                else if (!String.IsNullOrEmpty(splitString[2]))
                {
                    if (!flag)
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[2]) - Values[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[5], 16) + ",";
                        FirstValues[index] = Double.Parse(splitString[2]);
                        Values[index] = FirstValues[index];
                    }
                    else
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[2]) - FirstValues[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[5], 16) + ",";
                        FirstValues[index] = Values[index];
                    }

                    Aux[index] = Int32.Parse(splitString[22]);
                    for (int i = 1; i <= Aux[index]; i++)
                    {
                        finalLine = finalLine + Convert.ToInt32(splitString[22 + i], 16) + ",";
                    }
                }
                else
                {
                    if (!flag)
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[3]) - Values[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[6], 16) + ",";
                        FirstValues[index] = Double.Parse(splitString[3]);
                        Values[index] = FirstValues[index];
                    }
                    else
                    {
                        if (Values[index] == 0)
                        {
                            SecondValues[index] = AuxValues[index];
                        }
                        else
                        {
                            SecondValues[index] = Double.Parse(splitString[3]) - FirstValues[index];
                        }
                        finalLine = SecondValues[index] + "," + Convert.ToInt32(splitString[6], 16) + ",";
                        FirstValues[index] = Values[index];
                    }

                    Aux[index] = Int32.Parse(splitString[23]);
                    for (int i = 1; i <= Aux[index]; i++)
                    {
                        finalLine = finalLine + Convert.ToInt32(splitString[23 + i], 16) + ",";
                    }
                }

                for (int i = 0; i < 8 - Aux[index]; i++)
                {
                    finalLine = finalLine + "0";
                    if (i < 8 - Aux[index] - 1)
                    {
                        finalLine = finalLine + ",";
                    }
                }

                if (finalLine[finalLine.Length - 1].Equals(','))
                {
                    finalLine=finalLine.Remove(finalLine.Length - 1, 1);
                }

                inputfile.WriteLine(finalLine);

                if (!flag)
                {
                    outputfile.WriteLine("0");
                }
                flag = false;
            } 
        }
    }
}

inputfile.Close();
outputfile.Close();