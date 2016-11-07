{
if(battling == true and battle_phase == "results" and game_over == false){

if(win == true){
    //If the current room was a boss room, use a more dramatic death animation
    var check_boss = ds_grid_get(Dungeon.map,current_x,current_y);
    
    if(check_boss == 9 and boss_death_timer < 90){
        boss_death_timer += 1;
        if(boss_death_timer == 1){
            death_timer_2 = 0;
        }
        else if(boss_death_timer < 90){
            if(death_timer_2 == 0){player_2.cur_x -= 1;}
            else if(death_timer_2 == 1){player_2.cur_x += 1;}
            else if(death_timer_2 == 2){player_2.cur_x += 1;}
            else if(death_timer_2 == 3){player_2.cur_x -= 1;}
            
            if(death_timer_2 < 3){death_timer_2 += 1;}
            else{death_timer_2 = 0;}
            
            if(player_2.alpha == 1.0){player_2.alpha = 0;}
            else{player_2.alpha = 1.0;}
            
            if(boss_death_timer >= 60){
                player_2.alpha = 0;
            }
        
        }
        
        if(boss_death_timer == 90){
            if(instance_exists(Dungeon_Endless)){
                timer = 0;
                init = true;
                battling = false;
                endless_transition.visible = true;
                with(Button){visible = false;}
                Text_Box.visible = false;
                audio_stop_all();
                endless_transition.done = false;
                endless_transition.done_2 = true;
                with(endless_transition){random_clouds();}
                var cy = current_y-1 + ((segment-1) * 20);
                var cy = cy - 1;
                ds_grid_add(global.endless_grid,0,cy,player_2.sprite_index);
                ds_grid_add(global.endless_grid,1,cy,"win");
                with(Unit){if(id == Dungeon.player_2){instance_destroy();}}
            }
            else{
                game_over = true;
                ds_list_add(Dungeon.foe_history,Dungeon.player_2.name);
                ds_list_add(Dungeon.result_history,"Win");
            }     
        }
    
    }
    
    
    else{
        //Fade the enemy Away
        player_2.alpha -= 0.05;
        if(player_2.alpha == 0.1){Text_Box.new_text = player_2.name + " Defeated!";} 
        //Destroy the enemy
        if(player_2.alpha <= 0){
            timer = 0;
            battling = false;
            current_y += 1;
            //Apply level up
            Level_Up();
            //Add result to history list
        
            if(instance_exists(Dungeon_Endless)){
                var cy = current_y-1 + ((segment-1) * 20);
                var cy = cy - 1;
                ds_grid_add(global.endless_grid,0,cy,player_2.sprite_index);
                ds_grid_add(global.endless_grid,1,cy,"win");
            }
            else{
                ds_list_add(Dungeon.foe_history,Dungeon.player_2.name);
                ds_list_add(Dungeon.result_history,"Win");
            }
            with(Unit){if(id == Dungeon.player_2){instance_destroy();}}
        }
    }
}

//Player Dead
else{
    //game_over = true;
    //Determine the correct ending to be displayed
    player_dead = true;
    killer = player_2.name;
    if(instance_exists(Dungeon_Endless)){
        instance_create(0,0,oval_tran);   
        globalvar final_floor;
        global.final_floor = current_y+((segment-1)*20);
        Fade_Box.type = "results";
        Fade_Box.slow = true;
        var cy = current_y + ((segment-1)*20);
        ds_grid_set(global.endless_grid,0,cy,player_2.sprite_index);
        ds_grid_set(global.endless_grid,1,cy,"killed");
    }
    else{
        Choose_Ending();
        death_fade = instance_create(0,0,oval_tran);
        death_fade.type = "death";
        Fade_Box.slow = true;
    }
    //Lower the music volume until its silent
    audio_sound_gain(theme_music,0,1500);
}

}    
}
