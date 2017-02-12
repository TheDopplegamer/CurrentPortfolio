{
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//create a grid for Storing monster data
//Guide to creating monster entry:
//----------------------------------
// Name - Sprite - HP - Strength - Magic - Defense - Res - Luck - Attack type
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
num_of_monsters = 31;
monster_data = ds_grid_create(num_of_monsters,9);

var mn = 0;
while(mn < num_of_monsters){
    ds_grid_set(monster_data,mn,0,"");
    mn += 1;
}

//--------------------------------------------------------------------------------------
//Level 1 : The Slimes (Levels 1 - 10)

//The sad slime, with pitiful stats
Add_Monster(monster_data,"Sad Slime",sad_slime_spr,5 ,1,0,1,1, 0,"physical");

//The mad slime, who needs to chill
Add_Monster(monster_data,"Mad Slime",mad_slime_spr,5 ,13,0,5,9, 5,"physical");

//The glad slime, who's content with life
Add_Monster(monster_data,"Glad Slime",glad_slime_spr,5 ,5,0,9,9, 5,"physical");

//The rad slime, the coolest dude around
Add_Monster(monster_data,"Rad Slime",rad_slime_spr,5 ,0,12,7,7, 5,"magic");

//The bad slime, with evil schemes in mind
Add_Monster(monster_data,"Bad Slime",bad_slime_spr,5 ,0,11,9,9, 5,"magic");

//--------------------------------------------------------------------------------------
//Level 2 : The Beasts (Levels 11-15)

//Silas the Friendly Snake, just wants to be friends
Add_Monster(monster_data,"Silas",silas_the_friendly_snake_spr,5 ,13,0,16,13, 5,"physical");

//The Rabbid, you're gonna need a grenade for this one
Add_Monster(monster_data,"Rabbid",rabbid_spr,5 ,22,0,16,0, 5,"physical");

//Shineko, dont let it cross your back
Add_Monster(monster_data,"Shineko",shineko_spr,5 ,0,18,11,13, 10,"magic");

//--------------------------------------------------------------------------------------
//Level 3 : The Skeletons (Level 16-20)

//The skelebro, who's trying too hard
Add_Monster(monster_data,"Skelebro",skelebro_spr,5 ,20,0,17,18, 5,"physical");

//The skeletal knight, who fights for honor for all boney kind
Add_Monster(monster_data,"Skeletal Knight",skeletal_knight_spr,5 ,26,0,22,4, 5,"physical");

//The skeletal mage, who seeks knowledge known only to the undead
Add_Monster(monster_data,"Skeletal Mage",skeletal_mage_spr,5 ,0,26,4,19, 5,"magic");

//--------------------------------------------------------------------------------------
//Level 4 : The Fairy Tale Classics (20-25)

//Witch, what a nasty lady
Add_Monster(monster_data,"Witch",witch_spr,5 ,0,24,20,26, 5,"magic");

//Vampire, second verse, same as the first
Add_Monster(monster_data,"Vampire",vampire_spr,5 ,0,25,26,23, 5,"magic");

//The doppleganger,are you me?
Add_Monster(monster_data,"Doppleganger",doppleganger_spr,5 ,0,0,0,0,0,"magic");

//--------------------------------------------------------------------------------------
//Level 5 : The Zombies (Level 26-30)

//Rotting Corpse, what a Thriller
Add_Monster(monster_data,"Rotting Corpse",rotting_corpse_spr,5 ,30,0,28,28, 5,"physical");

//Necromancer, student of dead magics
Add_Monster(monster_data,"Necromancer",necromancer_spr,5 ,0,30,29,30, 5,"magic");

//Parasite, kill it with fire!
Add_Monster(monster_data,"Parasite",parasite_spr,5 ,35,0,21,31, 10,"physical");

//--------------------------------------------------------------------------------------
//Level 6 : The Gems (Levels 31-35)

//Diamand, what a dapper fellow
Add_Monster(monster_data,"Diamand",diamand_spr,5 ,32,0,36,36, 5,"physical");

//Emmarald, shes got a thing for Diamand
Add_Monster(monster_data,"Emmarald",emmarald_spr,5 ,0,36,35,33, 5,"magic");


//--------------------------------------------------------------------------------------
//Level 7 : The Elementals (levels 36-40)

//The Border Golem, none shall pass his rock hard abs
Add_Monster(monster_data,"Golem",golem_spr,5 ,35,0,42,38,7,"physical");

//Undying, elemental of water
Add_Monster(monster_data,"The Drowned",the_drowned_spr,5 ,0,37,35,38, 5,"magic");

//Salarymander, elemental of fire and payday
Add_Monster(monster_data,"Salarymander",salarymander_spr,5 ,0,41,34,40, 5,"magic");

//Avatar, master of all 4 elements
Add_Monster(monster_data,"Avatar",avatar_spr,5 ,0,40,40,40, 5,"magic");

//--------------------------------------------------------------------------------------
//Level 8 : The Eldritch Horrors (41-45)

//Bill, the Pyramid of Mystery?
Add_Monster(monster_data,"Bob Mystery",bob_mystery_spr,5 ,0,43,42,44, 10,"magic");

//Hamilton,avoid at ALL costs
Add_Monster(monster_data,"Hamilton",hamilton_spr,5 ,0,43,40,40, 5,"magic");

//Static Field, unknown to man
Add_Monster(monster_data,"Static Field",static_field_spr,5 ,0,43,42,40, 5,"magic");

//Endless Despair, does it ever end?
Add_Monster(monster_data,"Endless Despair",endless_despair_spr,5 ,43,0,46,42, 5,"physical");

//Morticus, dank god of knowledge and corruption
Add_Monster(monster_data,"Morticus",morticus_spr,5 ,43,0,42,48, 5,"physical");

//--------------------------------------------------------------------------------------
//Level 9 : The Heavenly Host (46-50)

//The Headless angel, repent, headless motherfuckers
Add_Monster(monster_data,"Headless Angel",headless_angel_spr,5 ,0,50,50,50, 5,"magic");

//unHoly Knight, your eternal rival
Add_Monster(monster_data,"UnHoly Knight",holy_knight_spr,5 ,50,0,50,50, 5,"physical");

//The Idol, pray to it for death
Add_Monster(monster_data,"The Idol",shining_idol_spr,5 ,0,50,50,50, 10,"magic");


//--------------------------------------------------------------------------------------
//Secret Monsters



}
