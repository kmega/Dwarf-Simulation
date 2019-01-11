using System;
using barcos.Enums;

namespace barcos
{
    public class Board
    {
<<<<<<< HEAD
        public FieldsStatus[] Fields = new FieldsStatus[100];

        public Board()
        {
            int fieldCounter = 0;
            while (fieldCounter < Fields.Length)
            {
                Fields[fieldCounter] = FieldsStatus.empty;
                fieldCounter++;
            }
=======
        public FieldsStatus[] Fields;

        public Board()
        {
>>>>>>> 178937ba99ef84c06264a21e81dd026adc7c196b
        }
    }
}
