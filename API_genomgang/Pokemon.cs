using System;

namespace API_genomgang
{
    public class Pokemon
    {
        //allt vi vill plocka från json måste vara properties namngivna exakt som dem heter i json koden

        public string name { get; set; }//properties brukar vara i stor bokstav men vi måste ha exakta namnet av det som står i json
        public int id { get; set; }
        public bool is_default { get; set; }


    }
}