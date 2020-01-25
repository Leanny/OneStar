namespace SeedSearcherGui
{
	struct PkmnStruct
    {
		public readonly int ivs0;
		public readonly int ivs1;
		public readonly int ivs2;
		public readonly int ivs3;
		public readonly int ivs4;
		public readonly int ivs5;
		public readonly int ability;
		public readonly int nature;
		public readonly int characteristic;
		public readonly int fixedIV;
		public readonly int ID;
		public readonly int altForm;
		public readonly bool isNoGender;
		public readonly bool isEnableDream;
		public readonly int fixedIVPos;

		public PkmnStruct(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			this.ivs0 = iv0;
			this.ivs1 = iv1;
			this.ivs2 = iv2;
			this.ivs3 = iv3;
			this.ivs4 = iv4;
			this.ivs5 = iv5;
			this.ability = ability;
			this.nature = nature;
			this.characteristic = characteristics;
			this.isNoGender = isNoGender;
			this.isEnableDream = isEnableDream;
			this.ID = species;
			this.altForm = altform;
			this.fixedIV = fixedIV;
			this.fixedIVPos = fixedIVPos;
		}
	}
}
