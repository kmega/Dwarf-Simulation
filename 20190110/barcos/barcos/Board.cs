using System;
using barcos.Enums;

namespace barcos
{
    public class Board : IBoard
    {
        
        public FieldsStatus[] Fields = new FieldsStatus[100];

        public Board()
        {
            int fieldCounter = 0;
            while (fieldCounter < Fields.Length)
            {
                Fields[fieldCounter] = FieldsStatus.empty;
                fieldCounter++;
            }
        }

    }
}
