namespace SeedSearcherGui
{
    public class SerializedInput
    {
        public Setup Setup { get; set; }
        public PokemonInput Pkmn1 { get; set; }
        public PokemonInput Pkmn2 { get; set; }
        public PokemonInput Pkmn3 { get; set; }
        public PokemonInput Pkmn4 { get; set; }
        public uint Checksum { get; private set; }

        public void CalculateChecksum()
        {
            string data = $"{Setup}|{Pkmn1}|{Pkmn2}|{Pkmn3}{Pkmn4}";
            Checksum = Util.CalculateChecksum(data);
        }
    }

    public class Setup
    {
        public int NestID;
        public int GameID;
        public string EventID;

        public override string ToString()
        {
            return $"{NestID}|{GameID}|{EventID}";
        }
    }

    public class PokemonInput
    {
        public int Day;
        public int Index;
        public int IVs;
        public int Nature;
        public int Ability;
        public int Characteristic;

        public override string ToString()
        {
            return $"{Day}|{Index}|{IVs}|{Nature}|{Ability}|{Characteristic}";
        }
    }
}
