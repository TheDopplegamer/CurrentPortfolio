{
//////////////////////////////////////////////////////////
//Rogue special move, lets unit evade next attack
/////////////////////////////////////////////////////////

if(special_timer == 0){
    Text_Box.new_text = "You use Shadow Step!";
    player_1.shadow_step = true;
    player_1.meter = 0;
    special_timer = 1;
    alpha_timer = 0;
    alpha_speed = 3;
}
else{
    special_timer += 1;
    alpha_timer += 1;
    if(alpha_timer == alpha_speed){
        alpha_timer = 0;
        if(player_1.alpha == 1){player_1.alpha = 0;}
        else{player_1.alpha = 1;}
    }    
    if(special_timer == 10){
        alpha_speed = 2;
    }
    if(special_timer == 20){
        alpha_speed = 1;
    }
    if(special_timer == 2){
        player_1.cur_x += 6;
    }
    else if(special_timer == 4){
        player_1.cur_x -= 6;
    }
    else if(special_timer == 6){
        player_1.cur_x -= 6;
    }
    else if(special_timer == 8){
        player_1.cur_x += 6;
    }
    else if(special_timer == 10){
        player_1.cur_x += 6;
    }
    else if(special_timer == 12){
        player_1.cur_x -= 6;
    }
    else if(special_timer == 14){
        player_1.cur_x -= 6;
    }
    else if(special_timer == 16){
        player_1.cur_x += 6;
    }
    else if(special_timer == 18){
        player_1.cur_x += 6;
    }
    else if(special_timer == 20){
        player_1.cur_x -= 6;
    }
    else if(special_timer == 21){
        player_1.cur_x -= 3;
    }
    else if(special_timer == 22){
        player_1.cur_x += 3;
    }
    else if(special_timer == 23){
        player_1.cur_x += 3;
    }
    else if(special_timer == 24){
        player_1.cur_x -= 3;
    }
}

if(special_timer == 30){
    player_1.alpha = 0.3;
    battle_phase = previous_phase;
}
}
