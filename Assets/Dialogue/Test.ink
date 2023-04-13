INCLUDE globals.ink

#audio:animal_crossing_low
{ pokemon_name == "": -> main1 | -> already_chose }

=== main1 ===
Which pokemon do you choose? #speaker:Pr. Blog

-> main


=== main ===
Which pokemon do you choose? #speaker:Pr. Blog
    + [Charmander]
        -> chosen("Charmander")
    + [Bulbasaur]
        -> chosen("Bulbasaur")
    + [Squirtle]
        -> chosen("Squirtle")
        
=== chosen(pokemon) ===
~ pokemon_name = pokemon
You chose {pokemon}!
-> END

=== already_chose ===
You already chose {pokemon_name}!
-> already

=== already ===
You already chose {pokemon_name}!

->END
