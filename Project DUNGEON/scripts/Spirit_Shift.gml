{
if(special_timer == 0){
    Text_Box.new_text = "You use Spirit Shift!";
    special_timer = 1;
    shift = instance_create(128,82,custom_particle);
    shift.sprite_index = spirit_shift_spr;
    shift.end_image = 30;
}

else{
    special_timer += 1;
}

if(special_timer == 21){
    //Swap Stats
    if(player_1.attack_type == "magic"){
        player_1.attack_type = "physical";
        player_1.sprite_index = monk_spr_p;
    }
    else{
        player_1.attack_type = "magic";
        player_1.sprite_index = monk_spr_m;
    }
}


if(special_timer >= 30){
    //Swap Stats
    if(player_1.attack_type == "physical"){
        var qqq = "Physical";
        Stat_Screen.image_index = 3;
    }
    else{
        var qqq = "Magical";
        Stat_Screen.image_index = 4;
    }
    
    Text_Box.new_text = "Became "+qqq+"!";
    
    var t_s = player_1.strength;
    var t_m = player_1.magic;
    var t_d = player_1.defense;
    var t_r = player_1.res;
    
    player_1.strength = t_m;
    player_1.magic = t_s;
    player_1.defense = t_r;
    player_1.res = t_d;
    player_1.meter = 0;
    battle_phase = previous_phase;
    
}

}
