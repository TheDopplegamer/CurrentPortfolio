{
//////////////////////////////////////////////////////////////////////
//Have player 2 attack player 1
//////////////////////////////////////////////////////////////////////

if(battle_phase == "attack 2"){

    timer += 1;
    Text_Box.new_text = player_2.name + " Attacks!";
    
    if(timer == 2){
        
        //Calculate if a crit happens
        if(irandom_range(1,200) <= player_2.luck){crit = true;}
        else{crit = false;}
    
        //Calculate damage
        //Calculate offense and defense values
        if(player_2.attack_type == "physical"){
            offense = player_2.strength + ds_grid_get(player_2.equipment,2,0) + ds_grid_get(player_2.equipment,2,1) + ds_grid_get(player_2.equipment,2,2) + ds_grid_get(player_2.equipment,2,3)
            defense = player_1.defense + ds_grid_get(player_1.equipment,4,0) + ds_grid_get(player_1.equipment,4,1) + ds_grid_get(player_1.equipment,4,2) + ds_grid_get(player_1.equipment,4,3)     
        }
        else{
            offense = player_2.magic + ds_grid_get(player_2.equipment,3,0) + ds_grid_get(player_2.equipment,3,1) + ds_grid_get(player_2.equipment,3,2) + ds_grid_get(player_2.equipment,3,3)   
            defense = player_1.res + ds_grid_get(player_1.equipment,5,0) + ds_grid_get(player_1.equipment,5,1) + ds_grid_get(player_1.equipment,5,2) + ds_grid_get(player_1.equipment,5,3)
        }
        //Apply damage
        damage = offense - defense;
        if(damage < 0){damage = 0;}
        
        
        //Make sure damage is at least 1
        if(damage <= 0){
            //BUT....If their defense is at least twice their offense, negate the damage
            if(defense > offense+35){}
            damage = 1;
        }
        
        //Check for crit to triple damage
        if(crit == true){
            if(damage == 1){damage = 5;}
            else{damage = damage * 3;}
            movement = 6;
            player_2.cur_y += 6;
        } 
        else{
            movement = 3;
            player_2.cur_y += 3;
        }
        
        
        if(player_1.shadow_step == false){
            if(global.damage_display == 3 or global.damage_display == 2){
                instance_create(134,115,hp_bar);
                hp_bar.target = player_1;
            }
            
            //Create damage particle
            if(global.damage_display == 3 or global.damage_display == 1){
                damage_effect = instance_create(130,90,damage_particle);
                damage_effect.value = damage;
            }
            
        }
        
    }
    
    
    
    if(timer == 3){
        player_1.cur_x += movement;
    }
    else if(timer == 5 and !crit){
        player_1.cur_x -= movement;
    }
    else if(timer == 5){
        player_1.cur_y -= movement*2;
    }
    else if(timer == 8){
        player_1.cur_x -= movement;
    }
    else if(timer == 10 and !crit){
        player_1.cur_x += movement;
    }
    else if(timer == 10){
        player_1.cur_x += movement*2;
    }
    else if(timer == 13 and !crit){
        player_1.cur_x += movement;
    }
    else if(timer == 15){
        player_1.cur_x -= movement;
    }
    
    
    if(player_1.shadow_step == false){
        if(player_2.attack_type == "magic"){
            player_1.color = c_fuchsia;
        }
        else{
            player_1.color = c_red;
        }
    }
    if(timer > 15){
    player_1.cur_x = 128;
    player_1.color = c_white;

    //Animate attack
    //script_execute(player_2.attack_animate);
    
    
    if(player_1.shadow_step == true){
        Text_Box.new_text = "Miss...";
        player_1.shadow_step = false;
        //player_1.meter = 0;
        player_1.alpha = 1.0;       
        battle_phase = "choose";    
        timer = 0; 
    }
    
    else{
    
    player_1.HP -= damage;   
    
    //Send Message to Text Box
    Text_Box.new_text = "You take " + string(damage) + " Damage";
    //Prepare for next phase
    
    //Check to see if a shield is used up
    if(has_sash == true){
        if(player_1.HP <= 0){
            instance_create(108,78,shield);
            player_1.HP = 1;
            has_sash = false;
        }
    }
    
    player_2.cur_y = 10;
    
    //Check to see if someone is dead
    if(player_1.HP <= 0){
        player_1.HP = 0;
        battle_phase = "results";
        win = false;
        timer = 0;
    }
    
    
    else if(player_2.HP <= 0){
        player_2.HP = 0;
        battle_phase = "results";
        win = true;
        timer = 0;
    }
    //If nobody is dead, let player 1 start his attack
    else{
        battle_phase = "choose";    
        timer = 0;
        player_2.image_index = player_2.previous_index;
    }
    }
    }
        
}

    
}
