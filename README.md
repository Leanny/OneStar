# Seed Finder by Lean
This tool allows you to recover the seed of a den in Pokémon Sword and Shield. All you need to do is to input IVs, Nature, Ability, and Characteristic of up to 4 Pokémon. 

# Tutorial
## Step 0 - Frame Advancements
Please read [The Advancement](https://github.com/zaksabeast/PokemonRNGGuides/blob/add/swsh/raid/guides/swsh/en/Raid%20RNG.md#the-advancement) and get familiar with how to advance frames.

## Step 1 - Catching the first Pokémon 
### A - Access to 1 and 2 Star dens
In this case you do not need to advance any frames at the beginning. Simply catch a Pokémon in the den you want to check, calculate IVs, and enter everything in the tool. Click "Check IV". If you get "Not enough info.", then you need to catch a Pokémon from the second dropdown and enter the IVs.

Note: This does not work with all IV combinations.

### B - Access to 3 to 5 star dens 
Here, you start by advancing by 3 days. Then you need to catch a Pokémon with less than 4 fixed IVs (most 2-4 star dens). After entering all information the tool either tells you that you need to catch another Pokémon with more fixed IVs from this frame, or that this Pokémon does not provide enough information. In this case repeat the process, but advance the day by one more than before. 

## Step 2 - Catch 2 more Pokémon 
Repeat the process, but catch any Pokémon from 1 days later and from 2 days later than the previous step, and enter the information.

## Step 3 - Calculate
Click "Start Search". This can take a long time, depending on the power of your PC. When a result is found, it will be printed in the textbox.

# FAQ
## What does "4/6", "5/6", or "6/6" mean?
The RNG used for raids produces a sequence of random numbers. In order to get the seed from a list of Pokémon part of the random number sequence is restored. The IVs you provide for your Day 4 Pokémon belongs to this sequence of random numbers. To get the seed as fast as possible, an IV spread that allows to reconstruct 6 consecutive random numbers works the best, which is 6/6. If the IV spread provides less numbers, then the seed finding will take longer. 

# Credits
* [Rusted Coil](https://github.com/rusted-coil/OneStar) and [Pattirudon](https://github.com/pattirudon/xoroshiro-inverse) - Providing the base for my tool and figuring out most of the Math.
* [Kaphotics](https://github.com/kwsch/PKHeX) - Providing PKHeX Core, a lib I used for language strings and getting all information for specific Pokémon.
