{
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//create a grid for Storing monster data
//Guide to creating monster entry:
//----------------------------------
// Name - Sprite - HP - Strength - Magic - Defense - Res - Luck - Attack type - Description
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//--------------------------------------------------------------------------------------
//Level 1 : The Slimes 

//The sad slime, with pitiful stats
Add_Monster_Library("Sad Slime",sad_slime_spr,5 ,1,0,1,1, 0,"physical",break_text("Sad little guy with sad little stats."));

//The mad slime, who needs to chill
Add_Monster_Library("Mad Slime",mad_slime_spr,5 ,13,0,5,9, 5,"physical",break_text("This guy needs to chill."));

//The glad slime, who's content with life
Add_Monster_Library("Glad Slime",glad_slime_spr,5 ,5,0,9,9, 5,"physical",break_text("Happy with life, nothing can go wrong."));

//The rad slime, the coolest dude around
Add_Monster_Library("Rad Slime",rad_slime_spr,5 ,0,12,7,7, 5,"magic",break_text("The coolest dude the  coolest tude."));

//The bad slime, with evil schemes in mind
Add_Monster_Library("Bad Slime",bad_slime_spr,5 ,0,11,9,9, 5,"magic",break_text("Plotting your demise, one scheme at a time."));

//--------------------------------------------------------------------------------------
//Level 2 : The Beasts

//Silas the Friendly Snake, just wants to be friends
Add_Monster_Library("Silas",silas_the_friendly_snake_spr,5 ,13,0,16,13, 5,"physical",break_text("Silas the Friendly Snake, friends with everyone."));

//The Rabbad, you're gonna need a grenade for this one
Add_Monster_Library("Rabbid",rabbid_spr,5 ,22,0,16,0, 5,"physical",break_text("Pull and throw on the count of three."));

//Shineko, dont let it cross your back
Add_Monster_Library("Shineko",shineko_spr,5 ,0,18,11,13, 10,"magic",break_text("Neko ni yoru shi de un"));

//--------------------------------------------------------------------------------------
//Level 3 : The Skeletons

//The skelebro, who's trying too hard
Add_Monster_Library("Skelebro",skelebro_spr,5 ,20,0,17,18, 5,"physical",break_text("He is working it, and he will get you!"));

//The skeletal knight, who fights for honor for all boney kind
Add_Monster_Library("Skeletal Knight",skeletal_knight_spr,5 ,26,0,22,4, 5,"physical",break_text("Fights for the honor of bones everywhere."));

//The skeletal mage, who seeks knowledge known only to the undead
Add_Monster_Library("Skeletal Mage",skeletal_mage_spr,5 ,0,26,4,19, 5,"magic",break_text("Uses his own bone marrow to cast spells."));

//--------------------------------------------------------------------------------------
//Level 4 : The Fairy Tale Classics

//Witch, what a nasty lady
Add_Monster_Library("Witch",witch_spr,5 ,0,24,20,26, 5,"magic",break_text("What a nasty lady."));

//Vampire, second verse, same as the first
Add_Monster_Library("Vampire",vampire_spr,5 ,0,25,26,23, 5,"magic",break_text("Just a vampire, no gimmicks to speak of."));

//The doppleganger,are you me?
Add_Monster_Library("Doppleganger",doppleganger_spr,5,0,0,0,0,0,"magic",break_text("Are you......me?"));

//--------------------------------------------------------------------------------------
//Level 5 : The Zombies

//Rotting Corpse, what a Thriller
Add_Monster_Library("Rotting Corpse",rotting_corpse_spr,5 ,30,0,28,28, 5,"physical",break_text("It's just a zombie..... What a thriller."));

//Necromancer, student of dead magics
Add_Monster_Library("Necromancer",necromancer_spr,5 ,0,30,29,30, 5,"magic",break_text("Student of dead magics and dead fashion."));

//Parasite, kill it with fire!
Add_Monster_Library("Parasite",parasite_spr,5 ,35,0,21,31, 10,"physical",break_text("Oh....that explains the zombies!"));

//--------------------------------------------------------------------------------------
//Level 7 : The Gems

//Diamand, what a dapper fellow
Add_Monster_Library("Diamand",diamand_spr,5 ,32,0,36,36, 5,"physical",break_text("A dapper fellow, a truer gentleman there never was."));

//Emmarald, shes got a thing for Diamand
Add_Monster_Library("Emmarald",emmarald_spr,5 ,0,36,35,33, 5,"magic",break_text("A real gem of a girl, has a thing for Diamand."));

//--------------------------------------------------------------------------------------
//Level 8 : The Elementals

//The Border Golem, none shall pass his rock hard abs
Add_Monster_Library("Golem",golem_spr,5 ,35,0,42,38,7,"physical",break_text("None shall pass his rock hard abs."));

//Undying, elemental of water
Add_Monster_Library("The Drowned",the_drowned_spr,5 ,0,37,35,38, 5,"magic",break_text("Ummmmm...shouldn't someone help that guy?"));

//Salarymander, elemental of fire and payday
Add_Monster_Library("Salarymander",salarymander_spr,5 ,0,41,34,40, 5,"magic",break_text("Elemental of Fire and Payday."));

//Avatar, master of all 4 elements
Add_Monster_Library("The Master",avatar_spr,5 ,0,40,40,40, 5,"magic",break_text("Master of an abiguous number of elements."));

//--------------------------------------------------------------------------------------
//Level 9 : The Eldritch Horrors

//Bill, the Pyramid of Mystery?
Add_Monster_Library("Bob Mystery",bob_mystery_spr,5 ,0,43,42,44, 10,"magic",break_text("He seems trustworthy."));

//Hamilton,avoid at ALL costs
Add_Monster_Library("Hamilton",hamilton_spr,5 ,0,43,40,40, 5,"magic",break_text("Kill it with Fire Kill it with Fire Kill it with Fire."));

//Static Field, unknown to man
Add_Monster_Library("Static Field",static_field_spr,5 ,0,43,42,40, 5,"magic",break_text("In everyone's homes, but still unknown to man."));

//Endless Despair, does it ever end?
Add_Monster_Library("Endless Despair",endless_despair_spr,5 ,43,0,46,42, 5,"physical",break_text("There's no way it's endless ...right?"));

//Morticus, dank god of knowledge and corruption
Add_Monster_Library("Morticus",morticus_spr,5 ,43,0,42,48, 5,"physical",break_text("Dank god of knowledge and corruption."));

//--------------------------------------------------------------------------------------
//Level 10 : The Heavenly Host

//The Headless angel, repent, headless motherfuckers
Add_Monster_Library("Headless Angel",headless_angel_spr,5 ,0,50,50,50, 5,"magic",break_text("Huh.....that's disturbing."));

//unHoly Knight, your eternal rival
Add_Monster_Library("UnHoly Knight",holy_knight_spr,5 ,50,0,50,50, 5,"physical",break_text("Your eternal rival, fears no flesh wounds."));

//The Idol, pray to it for death
Add_Monster_Library("The Idol",shining_idol_spr,5 ,0,50,50,50, 10,"magic",break_text("Pray to it for death."));



//--------------------------------------------------------------------------------------
//Bosses

//The Dark Lord, physical version
Add_Monster_Library("Dark Lord",dark_lord_spr,10,65,65,65,65,10,"physical",break_text("The Demonic King bent on world domination."));

//The Dark Lord, magic version
Add_Monster_Library("Dark Lord",dark_lord_magic_spr,10,65,65,65,65,10,"magic",break_text("The Demonic King bent on world domination, using his magical prowess."));

//Baron von Slime, king to his slimy subjects
//Add_Monster_Library("Baron von Slime",baron_slime_spr,10,50,50,50,50,10,"physical",break_text("Guardian of the Slimes, emotionally well - adjusted."));

//Avatar of Avarice, source of all greed
Add_Monster_Library("Throne of Avarice",dark_merchant_spr,10,0,0,0,0,0,"magic",break_text("Master of gold, feeds off of greed."));

//Marquis de Chaos, cannot be comprehended
Add_Monster_Library("Marquis de Chaos",lord_of_chaos_spr,10,0,0,0,0,0,"magic",break_text("Form: Unknowable. Power: Unknowable."));
}
