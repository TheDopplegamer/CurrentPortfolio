{
//////////////////////////////////////////////////////////////////////////////
//Runs whenever an enemy is defeated, raises the player's stats accordingly
//////////////////////////////////////////////////////////////////////////////

var in_data = false;

var endless_base = 15;
var endless_scale = 3;

var story_base = 10;
var story_scale = 6;


if(instance_exists(Dungeon_Endless)){
    var level_up_base = endless_base;
    var level_up_scale = endless_scale;
}
else{
    var level_up_base = story_base;
    var level_up_scale = story_scale;
}




//Generate values based on enemy and player levels

var el = Dungeon.player_2.level;
var pl = Dungeon.player_1.level;


var tier1 = round(pl/2);
var tier2 = round(el/2);

//Calulate Level Up based on tier difference
var tier_dif = tier2 - tier1;

if(instance_exists(Dungeon_Endless)){
    if(tier_dif < 0){
        var xp_gain = segment_xp + (tier_dif*0.25*level_up_scale);
    }
    else{
        var xp_gain = segment_xp + (tier_dif*level_up_scale);    
    }    
}

else{
    if(tier_dif == 0){var xp_gain = 10;}
    else if(tier_dif < 0){
        var xp_gain = level_up_base + (tier_dif * 2);
        if(xp_gain <= 0){xp_gain = 1;}
    }
    else if(tier_dif > 0){var xp_gain = level_up_base + (tier_dif * level_up_scale);}
}




var num_increases = 0;

var strength_N = 0;
var magic_N = 0;
var defense_N = 0;
var res_N = 0;

while(num_increases < xp_gain){
    var new_increase = irandom_range(1,4);
    if(new_increase == 1){
        if(irandom_range(1,100) <= Dungeon.player_1.str_rate){
            strength_N += 1;
            num_increases += 1;    
        }
    }
    else if(new_increase == 2){
        if(irandom_range(1,100) <= Dungeon.player_1.def_rate){
            defense_N += 1;
            num_increases += 1;  
        }
    }
    else if(new_increase == 3){
        if(irandom_range(1,100) <= Dungeon.player_1.res_rate){
            res_N += 1;
            num_increases += 1;  
        }
    }
    else if(new_increase == 4){
        if(irandom_range(1,100) <= Dungeon.player_1.mag_rate){
            magic_N += 1;
            num_increases += 1;  
        }
    }
}

//Apply Level Up
Dungeon.player_1.strength += strength_N;
if(Dungeon.player_1.strength > 99){Dungeon.player_1.strength = 99;}

Dungeon.player_1.magic += magic_N;
if(Dungeon.player_1.magic > 99){Dungeon.player_1.magic = 99;}

Dungeon.player_1.defense += defense_N;
if(Dungeon.player_1.defense > 99){Dungeon.player_1.defense = 99;}

Dungeon.player_1.res += res_N;
if(Dungeon.player_1.res > 99){Dungeon.player_1.res = 99;}

//Create Level up particles
lvl_up = instance_create(130,90,level_up_particle);

if(strength_N != 0){
    lvl_up.stat = "STR";
    lvl_up.value = strength_N;
    lvl_up.mag_value = magic_N;
    lvl_up.def_value = defense_N;
    lvl_up.res_value = res_N;
    lvl_up.lck_value = 0;
}
else if(magic_N != 0){
    lvl_up.stat = "MAG";
    lvl_up.value = magic_N;
    lvl_up.def_value = defense_N;
    lvl_up.res_value = res_N;
    lvl_up.lck_value = 0;
}
else if(defense_N != 0){
    lvl_up.stat = "DEF";
    lvl_up.value = defense_N;
    lvl_up.res_value = res_N;
    lvl_up.lck_value = 0;
}
else if(res_N != 0){
    lvl_up.stat = "RES";
    lvl_up.value = res_N;
    lvl_up.lck_value = 0;
}
else{
    lvl_up.value = 0;
    lvl_up.stat = "NONE";
}


//Calculate New player level

if(Dungeon.player_1.attack_type == "physical"){var noff = Dungeon.player_1.strength;}
else{var noff = Dungeon.player_1.magic;}

var ndef = Dungeon.player_1.defense;
var nres = Dungeon.player_1.res;
var tdeff = round((ndef+nres)/2);

Dungeon.player_1.level = round((noff+tdeff)/2);


}
