using System;

namespace Tea_Data
{
    internal class ExecuteTask
    {
        internal string ReverseRecords(string[] teaData)
        {
            string message = "";
            for (int i = teaData.Length; i > 0; i--)
            {
                message += teaData[i - 1] + Environment.NewLine;
            }
            return message;
        }


        internal string SortRecords(string[] teaData)
        {
            string teaType = "", message = teaData[0] + Environment.NewLine + Environment.NewLine;
            for (int i = 2; i < teaData.Length; i++)
            {
                try
                {
                    teaType = teaData[i].Split(',')[1].Replace(",", "");
                    for (int j = 2; j < teaData.Length; j++)
                    {
                        if (teaData[j].Contains(teaType) == true)
                        {
                            message += teaData[j] + Environment.NewLine;
                            teaData[j] = "";
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
            return message;
        }
    }
}