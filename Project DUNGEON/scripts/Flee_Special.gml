{
/////////////////////////////////////////////////////////////////////////////////
//Cancel current battle and transition to next room
/////////////////////////////////////////////////////////////////////////////////

if(player_1.fleeing == true){


    //Animate Flee
    if(flee_timer == 0){
        player_1.image_index = 2;
    }
    else if(flee_timer == 2){
        player_1.image_index = 3;
    }
    else if(flee_timer == 4){
        player_1.image_index = 4;
    }
    else if(flee_timer == 5){
        player_1.image_index = 5;
    }
    else if(flee_timer == 7){
        player_1.image_index = 6;
    }
    else if(flee_timer == 9){
        player_1.image_index = 7;
    }
    else if(flee_timer == 11){
        player_1.image_index = 8;
    }
    else if(flee_timer == 13){
        player_1.image_index = 9;
    }
    else if(flee_timer == 15){
        player_1.image_index = 10;
    }
    else if(flee_timer == 17){
        player_1.image_index = 11;
    }
    
    
    
    spec_scale -= (1/15);
    spec_x += 32/15;
    spec_y += 32/15;
    s1x -= 32/15;
    s2x -= 32/15;
    s1y -= 32/15;
    s2y -= 32/15;
    
    if(spec_scale < 0){
        spec_scale = 0;
    }
    
    
    
    
    flee_timer += 1;
    
    if(flee_timer >= 25){
    
        spec_scale = 1;
        spec_x = 128;
        spec_y = 10;
        s1x = -4;
        s1y = 12;
        s2x = 56;
        s2y = 12;
    
    
        //Regen HP
        //var heal_amount = round(player_1.MAX_HP*0.25);
        var heal_amount = 0;
        player_1.HP += heal_amount;
        if(player_1.HP > player_1.MAX_HP){player_1.HP = player_1.MAX_HP;}
    
        player_1.reset_flee_image = true;
        //Exit special rooms
        Dungeon.in_trap = false;
        Dungeon.in_shop = false;
        player_1.fleeing = false;
        Dungeon.in_chest = false;
        Dungeon.in_slot = false;
        Dungeon.in_prayer = false;
        //Increment Special Meter
        player_1.meter += 1;
        if(player_1.meter > player_1.meter_max){player_1.meter = player_1.meter_max;}
    
        //Move to next room
        current_y += 1;
    }
}


}
