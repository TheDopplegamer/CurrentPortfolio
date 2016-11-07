{
if(in_bomb == true and animate_bomb == false and spec_enter == false){
    bomb_timer -= 1;
    
    if(bomb_timer == room_speed * 9){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 9){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 8){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 7){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 6){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 5){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 4){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 3){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 2){
        bomb_index += 1;
    }
    else if(bomb_timer == room_speed * 1){
        bomb_index += 1;
    }
    
    
    //If the timer has reached 0, the bomb goes off and hurts us
    else if(bomb_timer == 0){
        timer = 0;
        animate_bomb = true;
        bomb_ani_timer = 3;
        //Let there be a 1 in 10 chance of the bomb being a dud
        if(irandom_range(1,10) == 10){
            bomb_dud = true;
        }
        else{
            bomb_dud = false;
            audio_play_sound(boom_sound,1,false);
            audio_sound_gain(boom_sound,global.volume,0);
        }
    }
    if(bomb_wait == true){
        bomb_wait_timer -= 1;
        if(bomb_wait_timer == 0){
            bomb_wait = false;
        }
    }
}

else if(animate_bomb == true){

    if(bomb_entered[3] == true){
        //Animate Defusal
        if(instance_exists(bomb_flame)){
            //Send message to text box
            Text_Box.new_text = "Bomb Defused!";
            //Provide reward of a full Special Bar
            player_1.meter = player_1.meter_max;
            with(bomb_flame){
                instance_destroy();
            }
        }
    
        spec_alpha -= 0.05;
        //Move on to next room
        if(spec_alpha < 0){
            spec_alpha = 1;
            animate_bomb = false;
            in_bomb = false;
            current_y += 1;
        }
    }

    
    else{
        //Animate Defusal
        if(instance_exists(bomb_flame)){
            with(bomb_flame){
                instance_destroy();
            }
        }
    
        if(bomb_dud == true){
            //Animate explosion here
            bomb_index = 10;
             Text_Box.new_text = "It's a dud...";
        }
        
        else{
            Text_Box.new_text = "BOOOOOOOOOM!!!!";
            
            bomb_ani_timer += 1;    
            if(bomb_ani_timer >= 4){
                bomb_ani_timer = 0;
                bomb_index = irandom_range(11,15);
            }
        }
        timer += 1;
        spec_alpha -= 0.05;
        if(timer == 3){
            if(bomb_dud == false){
                damage = round(player_1.MAX_HP * 0.25);
                if(global.damage_display == 3 or global.damage_display == 2){
                    instance_create(134,115,hp_bar);
                    hp_bar.target = player_1;
                }
                if(global.damage_display == 3 or global.damage_display == 1){
                    damage_effect = instance_create(130,90,damage_particle);
                    damage_effect.value = damage;
                }
            }
        }
            
    if(timer == 3){
        player_1.cur_x += 3;
    }
    else if(timer == 5){
        player_1.cur_x -= 3;
    }
    else if(timer == 8){
        player_1.cur_x -= 3;
    }
    else if(timer == 10){
        player_1.cur_x += 3;
    }
    else if(timer == 13){
        player_1.cur_x += 3;
    }
    else if(timer == 15){
        player_1.cur_x -= 3;
    }
        
        //Apply damage
        if(spec_alpha < 0){
            timer = 0;
            spec_alpha = 1.0;
            if(bomb_dud == false){
            var bomb_boom = round(player_1.MAX_HP * 0.25);
            player_1.HP -= bomb_boom;
            
            
            if(has_sash == true){
                if(player_1.HP <= 0){
                    instance_create(108,78,shield);
                    player_1.HP = 1;
                    has_sash = false;
                }
            }
            
        
            //Check for Death
            if(player_1.HP <= 0){
                player_1.HP = 0;
                game_over = true;
                killer = "Bomb";
                //Determine the correct ending to be displayed
                player_dead = true;
                if(instance_exists(Dungeon_Endless)){
                    instance_create(0,0,oval_tran);   
                    Fade_Box.type = "results";
                    Fade_Box.slow = true;
                    var cy = current_y + ((segment-1)*20);
                    ds_grid_set(global.endless_grid,0,cy,bomb_spr);
                    ds_grid_set(global.endless_grid,1,cy,"killed");
                }
                else{
                Choose_Ending();
                death_fade = instance_create(0,0,Fade_Box);
                death_fade.type = "death";
                death_fade.speedf = 0.03;
                }
                //Lower the music volume until its silent
                audio_sound_gain(theme_music,0,1500);
            }    
        
            //Create damage particle
            damage_effect = instance_create(130,90,damage_particle);
            damage_effect.value = bomb_boom;
            }
            
            //Move to next room
            animate_bomb = false;
            in_bomb = false;
            current_y += 1;
        }
    }    
}

}
