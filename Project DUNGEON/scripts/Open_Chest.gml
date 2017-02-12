{

if(in_chest == true and chest_opened == true){


if(animate_chest == false){
    timer = 3;
    //Runs whenever a chest is opened, decides whether or not to reward stats or transform into mimic fight
    if(instance_exists(Dungeon_Standard) and floor_type[current_x] == "treasury"){
        var mimic_chance = 5;
    }
    else if(instance_exists(Dungeon_Endless)){
        var mimic_chance = 6;
    }
    else{
        var mimic_chance = 10;
    }    
    var mr = irandom_range(1,mimic_chance);
    //Spawn Mimic
    if(mr == 1){
        //Animate Transformation
        is_mimic = true;
        animate_chest = true; 
    }
    //Open Chest and give random stat boost
    else{
        //Choose a random stat to increase
        //---------------------------------
        // 1 - MAX HP
        // 2 - Strength
        // 3 - Magic
        // 4 - Defense
        // 5 - Res
        // 6 - Luck
        // 7 - Shield
        // 8 - Scouter
        // 9 - All
        if(!has_sash and irandom_range(1,2) == 1){var mi = -1;}
        else{var mi = 0;}
        
        if(!has_scouter and irandom_range(1,2) == 1){var ma = 1;}
        else{var ma = 0;}
        
        var is_item = irandom_range(mi,ma);
        if(is_item == 0){
            chest_stat = irandom_range(1,6);
        }
        else if(is_item == -1){
            chest_stat = 7;
        }
        else{
            chest_stat = 8;
        }
        //Choose amount to increase stat by
        if(chest_stat == 1){
            chest_value = 2;
        }
        else{
            chest_value = 10;
        }
        //Animate opening
        animate_chest = true;    
        is_mimic = false;
    }
}
//Start animation
else{
    if(is_mimic == true){
        timer += 1;
        if(chest_index == 0){chest_index = 2;}
        else{chest_index = 0;}
        if(timer == 15){
            player_2 = instance_create(0,0,Unit);
            Text_Box.new_text = "The Chest was a Mimic!";
            Update_Text();
            player_2.name = "Mimic";
            player_2.sprite_index = mimic_spr;
            player_2.attack_type = "physical";
            player_2.MAX_HP = 5;
            player_2.HP = 5;
            player_2.strength = 10+(current_y*2);
            player_2.magic = 10+(current_y*2);
            player_2.defense = 10+(current_y*2);
            player_2.res = 10+(current_y*2);
            player_2.luck = 20;
            player_2.cur_y = 10;
            Dungeon.enemy_level = 10+(current_y*2);
            player_2.level = 10+(current_y*2);
            player_2.idle_animate = mimic_animate;
            player_2.attack_animate = mimic_atk_animate;
            player_2.hurt_index = 0;
            player_2.enter = false;
            //Have mimic attack first
            battle_phase = "attack 2";    
            in_chest = false;
            animate_chest = false;
            battling = true;
            chest_index = 0;
            timer = 0;
        }
    }
    else{
        timer += 1;
        
        if(!instance_exists(custom_particle)){
            treasure_effect = instance_create(141,27,custom_particle);
            treasure_effect.type = "treasure";
            treasure_effect.sprite_index = treasure_spr;
            treasure_effect.image_index = chest_stat - 1;
        }
        
        chest_index = 1;
        if(timer == 30){
            if(chest_stat == 1){
                Text_Box.new_text = "MAX HP increased by " + string(chest_value) + "!";
                player_1.MAX_HP += chest_value;
                player_1.HP += chest_value;
            }
            else if(chest_stat == 2){
                Text_Box.new_text = "STR increased by " + string(chest_value) + "!";
                player_1.strength += chest_value;
            }
            else if(chest_stat == 3){
                Text_Box.new_text = "MAG increased by " + string(chest_value) + "!";
                player_1.magic += chest_value;
            }
            else if(chest_stat == 4){
                Text_Box.new_text = "DEF increased by " + string(chest_value) + "!";
                player_1.defense += chest_value;
            }
            else if(chest_stat == 5){
                Text_Box.new_text = "RES increased by " + string(chest_value) + "!";
                player_1.res += chest_value;
            }
            else if(chest_stat == 6){
                Text_Box.new_text = "LCK increased by " + string(chest_value) + "!";
                player_1.luck += chest_value;
            }
            else if(chest_stat == 7){
                Text_Box.new_text = "Found Holy Shield!";
                has_sash = true;
            }
            else if(chest_stat == 8){
                Text_Box.new_text = "Found Mystic Eye!";
                has_scouter = true;
            }
            else if(chest_stat == 9){
                Text_Box.new_text = "Everything increased by " + string(chest_value) + "!";
                player_1.MAX_HP += chest_value;
                player_1.HP += chest_value;
                player_1.strength += chest_value;
                player_1.magic += chest_value;
                player_1.defense += chest_value;
                player_1.res += chest_value;
                player_1.luck += chest_value;
            }
            if(player_1.MAX_HP > 99){player_1.MAX_HP = 99;}
            if(player_1.HP > 99){player_1.HP = 99;}
            if(player_1.strength > 99){player_1.strength = 99;}
            if(player_1.magic > 99){player_1.magic = 99;}
            if(player_1.defense > 99){player_1.defense = 99;}
            if(player_1.res > 99){player_1.res = 99;}
            if(player_1.luck > 99){player_1.luck = 99;}
            in_chest = false;
            animate_chest = false;
            current_y += 1;
            Update_Text();
            chest_index = 0;
            //Add to history
            chests_opened += 1;
        }
    }
    
}


}


}
