{
//Pick a monster for an endless dungeon
//Choose a random sprite index from available 
//Adjust stats based on current level from level list
//All we're doing is picking a random sprite index that comes with their own small modifiers


var monster = irandom_range(1,31);

var lvl = ds_list_find_value(level_list,current_y);

//The modi variable determines the actal value to raise or lower stats by
var modi = round(boss_level/5);

//Give fixed values for HP and luck
player_2.MAX_HP = 5;
player_2.HP = 5;
player_2.luck = 5;



//If the slime statue has been prayed to, give it a 1 in 4 chance to force a slime spawn
if(slime_prayed == true){
    monster = irandom_range(1,5);
}


//Sad Slime
if(monster == 1){
    //The Sad Slime breaks the rules by being the only monster with all stats being negative
    player_2.sprite_index = sad_slime_spr;
    player_2.name = "Sad Slime";
    player_2.strength = lvl - modi;
    player_2.magic = lvl - modi;
    player_2.defense = lvl - modi;
    player_2.res = lvl - modi; 
    player_2.attack_type = "physical";
}
//Mad Slime
else if(monster == 2){
    player_2.name = "Mad Slime";
    player_2.sprite_index = mad_slime_spr;
    player_2.strength = lvl - modi;
    player_2.magic = lvl;
    player_2.defense = lvl - modi;
    player_2.res = lvl; 
    player_2.attack_type = "physical";
}
//Glad Slime
else if(monster == 3){
player_2.name = "Glad Slime";
    player_2.sprite_index = glad_slime_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl-modi;
    player_2.res = lvl-modi; 
    player_2.attack_type = "physical";
}
//Rad Slime
else if(monster == 4){
    player_2.name = "Rad Slime";
    player_2.sprite_index = rad_slime_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl - modi;
    player_2.res = lvl - modi; 
    player_2.attack_type = "magic";
}
//Bad Slime
else if(monster == 5){
    player_2.name = "Bad Slime";
    player_2.sprite_index = bad_slime_spr;
    player_2.strength = lvl;
    player_2.magic = lvl - modi;
    player_2.defense = lvl - modi;
    player_2.res = lvl; 
    player_2.attack_type = "magic";
}
//Silas
else if(monster == 6){
    player_2.name = "Silas";
    player_2.sprite_index = silas_the_friendly_snake_spr;
    player_2.strength = lvl - modi;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl; 
    player_2.attack_type = "physical";
}
//Rabbid
else if(monster == 7){
    player_2.name = "Rabbid";
    player_2.sprite_index = rabbid_spr;
    player_2.strength = lvl + modi;
    player_2.magic = lvl;
    player_2.defense = lvl + modi;
    player_2.res = lvl - modi; 
    player_2.attack_type = "physical";
}
//Shineko
else if(monster == 8){
    player_2.name = "Shineko";
    player_2.sprite_index = shineko_spr;
    player_2.strength = lvl;
    player_2.magic = lvl - modi;
    player_2.defense = lvl;
    player_2.res = lvl; 
    player_2.attack_type = "magic";
}
//Skelebro
else if(monster == 9){
    player_2.name = "Skelebro";
    player_2.sprite_index = skelebro_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl; 
    player_2.attack_type = "physical";
}
//Skeletal Knight
else if(monster == 10){
    player_2.name = "Skeletal Knight";
    player_2.sprite_index = skeletal_knight_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl - modi; 
    player_2.attack_type = "physical";
}
//Skeletal Mage
else if(monster == 11){
    player_2.name = "Skeletal Mage";
    player_2.sprite_index = skeletal_mage_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl - modi;
    player_2.res = lvl; 
    player_2.attack_type = "magic";
}
//Vampire
else if(monster == 12){
    player_2.name = "Vampire";
    player_2.sprite_index = vampire_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl; 
    player_2.attack_type = "magic";
}
//Doppleganger
else if(monster == 13){
    player_2.name = "Doppleganger";
    //The doppleganger breaks the rules by having identical stats to the player
    if(global.player_class == "Knight"){player_2.sprite_index = doppleganger_spr;}
    else if(global.player_class == "Mage"){player_2.sprite_index = dopple_mage_spr;}
    else if(global.player_class == "Rogue"){player_2.sprite_index = dopple_rogue_spr;}
    else if(global.player_class == "Monk"){player_2.sprite_index = dopple_monk_spr;}
    player_2.strength = player_1.strength;
    player_2.magic = player_1.magic;
    player_2.defense = player_1.defense;
    player_2.res = player_1.res; 
    player_2.attack_type = player_1.attack_type;
}
//Witch
else if(monster == 14){
    player_2.name = "Witch";
    player_2.sprite_index = witch_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl + modi; 
    player_2.attack_type = "magic";
}
//Rotting Corpse
else if(monster == 15){
    player_2.name = "Rotting Corpse";
    player_2.sprite_index = rotting_corpse_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl - modi;
    player_2.res = lvl; 
    player_2.attack_type = "physical";
}
//Necromancer
else if(monster == 16){
    player_2.name = "Necromancer";
    player_2.sprite_index = necromancer_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl - modi; 
    player_2.attack_type = "magic";
}
//Parasite
else if(monster == 17){
    player_2.name = "Parasite";
    player_2.sprite_index = parasite_spr;
    player_2.strength = lvl + modi;
    player_2.magic = lvl;
    player_2.defense = lvl - modi;
    player_2.res = lvl + modi; 
    player_2.attack_type = "physical";
}
//Diamand
else if(monster == 18){
    player_2.name = "Diamand";
    player_2.sprite_index = diamand_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl + modi;
    player_2.res = lvl + modi; 
    player_2.attack_type = "physical";
}
//Emmarald
else if(monster == 19){
    player_2.name = "Emmarald";
    player_2.sprite_index = emmarald_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl + modi;
    player_2.res = lvl + modi; 
    player_2.attack_type = "magic";
}
//Golem
else if(monster == 20){
    player_2.name = "Golem";
    player_2.sprite_index = golem_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl + modi;
    player_2.res = lvl; 
    player_2.attack_type = "physical";
}
//The Drowned
else if(monster == 21){
    player_2.name = "The Drowned";
    player_2.sprite_index = the_drowned_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl + modi;
    player_2.res = lvl; 
    player_2.attack_type = "magic";
}
//Salarymander
else if(monster == 22){
    player_2.name = "Salarymander";
    player_2.sprite_index = salarymander_spr;
    player_2.strength = lvl+modi;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl; 
    player_2.attack_type = "physical";
}
//Avatar
else if(monster == 23){
    player_2.name = "Avatar";
    player_2.sprite_index = avatar_spr;
    player_2.strength = lvl;
    player_2.magic = lvl + modi;
    player_2.defense = lvl + modi;
    player_2.res = lvl + modi; 
    player_2.attack_type = "magic";
    
        player_2.earth_element = instance_create(130,12,avatar_orbs);
        player_2.earth_element.image_index = 0;
        
        player_2.fire_element = instance_create(130,58,avatar_orbs);
        player_2.fire_element.image_index = 1;
        
        player_2.air_element = instance_create(128+48,58,avatar_orbs);
        player_2.air_element.image_index = 2;
        
        player_2.water_element = instance_create(128+48,12,avatar_orbs);
        player_2.water_element.image_index = 3;
        
        player_2.earth_element.avatar = player_2;
        player_2.water_element.avatar = player_2;
        player_2.air_element.avatar = player_2;
        player_2.fire_element.avatar = player_2;
    
}
//Bob Mystery
else if(monster == 24){
    player_2.sprite_index = bob_mystery_spr;
    player_2.name = "Bob Mystery";
    player_2.strength = lvl;
    player_2.magic = lvl + modi;
    player_2.defense = lvl + modi;
    player_2.res = lvl - modi; 
    player_2.attack_type = "magic";
}
//Hamilton
else if(monster == 25){
    player_2.sprite_index = hamilton_spr;
    player_2.name = "Hamilton";
    player_2.strength = lvl;
    player_2.magic = lvl + modi;
    player_2.defense = lvl;
    player_2.res = lvl; 
    player_2.attack_type = "magic";
}
//Static Field
else if(monster == 26){ 
    player_2.name = "Static Field";
    player_2.sprite_index = static_field_spr;
    //The static field breaks the rules by having unknown lvl modifiers
    var str_mod = irandom_range(-2,2);
    var mag_mod = irandom_range(-2,2);
    var def_mod = irandom_range(-2,2);
    var res_mod = irandom_range(-2,2);
    
    player_2.strength = lvl - str_mod;
    player_2.magic = lvl - mag_mod;
    player_2.defense = lvl - def_mod;
    player_2.res = lvl - res_mod; 
    player_2.attack_type = "magic";
    var is_phys = irandom_range(0,1);
    if(is_phys == 1){player_2.attack_type = "physical";}
}
//Endless Despair
else if(monster == 27){
    player_2.name = "Endless Despair";
    player_2.sprite_index = endless_despair_spr;
    player_2.strength = lvl;
    player_2.magic = lvl;
    player_2.defense = lvl;
    player_2.res = lvl + modi; 
    player_2.attack_type = "physical";
}
//Morticus
else if(monster == 28){
    player_2.name = "Morticus";
    player_2.sprite_index = morticus_spr;
    player_2.strength = lvl + modi;
    player_2.magic = lvl;
    player_2.defense = lvl + modi;
    player_2.res = lvl; 
    player_2.attack_type = "physical";
}
//Headless Angel
else if(monster == 29){
    player_2.name = "Headless Angel";
    player_2.sprite_index = headless_angel_spr;
    player_2.strength = lvl;
    player_2.magic = lvl + modi;
    player_2.defense = lvl - modi;
    player_2.res = lvl + modi; 
    player_2.attack_type = "magic";
}
//The Idol
else if(monster == 30){
    player_2.name = "The Idol";
    player_2.sprite_index = shining_idol_spr;
    player_2.strength = lvl;
    player_2.magic = lvl + modi;
    player_2.defense = lvl + modi;
    player_2.res = lvl; 
    player_2.attack_type = "magic";
}
//UnHoly Knight
else if(monster == 31){
    player_2.name = "UnHoly Knight";
    player_2.sprite_index = holy_knight_spr;
    player_2.strength = lvl + modi;
    player_2.magic = lvl;
    player_2.defense = lvl + modi;
    player_2.res = lvl + modi; 
    player_2.attack_type = "physical";
}


player_2.level = lvl;
enemy_level = lvl;


//Make sure enemy stats are not too high or too low
if(player_2.strength < 1){player_2.strength = 1;}
if(player_2.magic < 1){player_2.magic = 1;}
if(player_2.defense < 1){player_2.defense = 1;}
if(player_2.res < 1){player_2.res = 1;}


if(player_2.strength > 90){player_2.strength = 90;}
if(player_2.magic > 90){player_2.magic = 90;}
if(player_2.defense > 90){player_2.defense = 90;}
if(player_2.res > 90){player_2.res = 90;}













}
