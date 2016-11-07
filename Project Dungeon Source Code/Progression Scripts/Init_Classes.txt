{
if(global.player_class == "Knight"){
    player_1.sprite_index = knight_spr;
    player_1.special_script = Holy_Blessing;
    player_1.meter_max = 2;
    player_1.meter = 2;
    player_1.strength = 9;
    player_1.magic = 0;
    player_1.defense = 13;
    player_1.res = 12;
    player_1.luck = 4;    
    player_1.attack_type = "physical";
    
    //Set Growth Rates
    player_1.str_rate = 85;
    player_1.mag_rate = 75;
    player_1.def_rate = 95;
    player_1.res_rate = 95;
    
    
}
else if(global.player_class == "Monk"){
    player_1.sprite_index = monk_spr_p;
    player_1.special_script = Spirit_Shift;
    player_1.meter_max = 3;
    player_1.strength = 10;
    player_1.magic    = 10;
    player_1.defense  = 10;
    player_1.res      = 10;
    player_1.luck     = 10;
    player_1.attack_type = "physical"; 
    
     //Set Growth Rates
    player_1.str_rate = 80;
    player_1.mag_rate = 80;
    player_1.def_rate = 80;
    player_1.res_rate = 80;
}
else if(global.player_class == "Mage"){
    player_1.sprite_index = wizard_spr;
    player_1.special_script = MageFlame;
    player_1.strength = 0;
    player_1.magic = 12;
    player_1.defense = 8;
    player_1.res = 14;
    player_1.luck = 8;    
    player_1.attack_type = "magic";
    
     //Set Growth Rates
    player_1.str_rate = 75;
    player_1.mag_rate = 90;
    player_1.def_rate = 80;
    player_1.res_rate = 85;
    
    
}
else if(global.player_class == "Rogue"){
    player_1.sprite_index = rogue_spr;
    player_1.special_script = Shadow_Step;
    player_1.strength = 14;
    player_1.magic = 10;
    player_1.defense = 9;
    player_1.res = 8;
    player_1.luck = 10;    
    player_1.attack_type = "physical";
    
    //Set Growth Rates
    player_1.str_rate = 95;
    player_1.mag_rate = 85;
    player_1.def_rate = 80;
    player_1.res_rate = 80;
    
}

var reset = true;

if(instance_exists(Dungeon_Endless)){
    if(Dungeon.segment > 0){
        reset = false;
    }
}
if(reset){player_1.MAX_HP = 20;}

if(player_1.HP > player_1.MAX_HP){
    player_1.HP = player_1.MAX_HP;
}



}


