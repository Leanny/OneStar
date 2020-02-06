# Seed Searcher Import/Export Format
Result is saved as Base64-Encoded Json file.

## General Format 
``{Setup = SETUP, Pkmn1 = DATA1, Pkmn2 = DATA2, Pkmn3 = DATA3, Pkmn4 = DATA4, Checksum=CHECKSUM}``

### Setup Format 
Here, the general information about the tool are stored:
* Nest ID - The Nest ID to look up the encounter table
* Game ID - 0 for sword, 1 for shield 
* Event ID - only present if NestID is 0 (Event). This is the filename of the json file used for the event (*startdate.json*)

### Pokémon Format 
Pokémon are stored as array in JSON format. Keys:
* Day - The day this mon was caught. 
* Index - Index in nest table 
* IVs - IV for this mon. 5 bit per IV value.
* Nature - Nature Index, value between 0 and 24 (inclusive)
* Ability - 0 for Ability 0, 1 for Ability 1, 2 for Ability 2 (HA), -1 for "normal", -2 for "Unspecified"
* Characteristic - Value between -1 and 6.

### Checksum Calculation
The 8-Bit-Checksum is the sum of every char in the json string. In this case it is the concatenated string of each data field. Each attribute is concatenated by ``|``