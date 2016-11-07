{
/////////////////////////////////////////////////////////////////////////////////
//Cancel current battle and transition to next room
/////////////////////////////////////////////////////////////////////////////////

if(battle_phase == "flee"){

    //Animate Flee
    if(flee_timer == 0){
        player_1.image_index = 2;
        Text_Box.new_text = "Ran away!";
        //If we are sending a repeat message, force a text update
        if(Text_Box.new_text == Text_Box.text[0]){Update_Text();}
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
    
    
    player_2.scale -= (1/15);
    player_2.cur_x += 32/15;
    player_2.cur_y += 32/15;
    
    if(player_2.scale < 0){
        player_2.scale = 0;
    }
    
    
    flee_timer += 1;
    
    if(flee_timer >= 25){
    
        //Regen HP
        //var heal_amount = round(player_1.MAX_HP*0.25);
        var heal_amount = 3;
        player_1.HP += heal_amount;
        if(player_1.HP > player_1.MAX_HP){player_1.HP = player_1.MAX_HP;}
    
        player_1.reset_flee_image = true;
        //Exit battle
        battle_phase = "wait";
        battling = false;
        //Increment Special Meter
        if(global.player_class != "Knight"){
            player_1.meter += 1;
            if(player_1.meter > player_1.meter_max){player_1.meter = player_1.meter_max;}
        }
        
        
        
        //Add the result of this battle to the history lists
        
        if(instance_exists(Dungeon_Endless)){
            var cy = current_y + ((segment-1) * 20);
            var cy = cy - 1;
            ds_grid_add(global.endless_grid,0,cy,player_2.sprite_index);
            ds_grid_add(global.endless_grid,1,cy,"run");
        }
        else{
            ds_list_add(Dungeon.foe_history,Dungeon.player_2.name);
            ds_list_add(Dungeon.result_history,"Flee");
        }
        with(Unit){if(id == Dungeon.player_2){instance_destroy();}}
    
        //If the current room was a boss room, end the game
        var check_boss = ds_grid_get(Dungeon.map,current_x,current_y);
        if(check_boss == 9){
            game_over = true;
        }
        
        //Move to next room
        current_y += 1;
    }
}


}
