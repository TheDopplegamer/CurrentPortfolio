{
//////////////////////////////////////////////////////////////////////
//Have player 1 attack player 2
//////////////////////////////////////////////////////////////////////

if(battle_phase == "attack 1"){

    player_1.image_index = 1;
    Text_Box.new_text = "You Attack!";
    if(!instance_exists(custom_particle)){
        player_2.previous_index = player_2.image_index;
        player_2.image_index = player_2.hurt_index;
        new_particle = instance_create(130,10,custom_particle);
        if(global.player_class == "Knight"){
            new_particle.sprite_index = slash_spr;
            //audio_play_sound(slash_sound,1,false);
            //audio_sound_gain(slash_sound,global.volume,0);
        }  
        else if(global.player_class == "Monk"){
            new_particle.sprite_index = bash_spr;
            new_particle.rand = true;
            //audio_play_sound(slash_sound,1,false);
            //audio_sound_gain(slash_sound,global.volume,0);
        }  
        else if(global.player_class == "Mage"){new_particle.sprite_index = spell_blast_spr;} 
        else if(global.player_class == "Rogue"){
            new_particle.sprite_index = dual_slash_spr;
            //audio_play_sound(slash_sound,1,false);
            //audio_sound_gain(slash_sound,global.volume,0);
        }   
        new_particle.end_image = 11;
        
        //Calculate if a crit happens
        if(irandom_range(1,200) <= player_1.luck){crit = true;}
        else{crit = false;}
    
        //Calculate damage
        //Calculate offense and defense values
        if(player_1.attack_type == "physical"){
            offense = player_1.strength + ds_grid_get(player_1.equipment,2,0) + ds_grid_get(player_1.equipment,2,1) + ds_grid_get(player_1.equipment,2,2) + ds_grid_get(player_1.equipment,2,3)
            defense = player_2.defense + ds_grid_get(player_2.equipment,4,0) + ds_grid_get(player_2.equipment,4,1) + ds_grid_get(player_2.equipment,4,2) + ds_grid_get(player_2.equipment,4,3)     
        }
        else{
            offense = player_1.magic + ds_grid_get(player_1.equipment,3,0) + ds_grid_get(player_1.equipment,3,1) + ds_grid_get(player_1.equipment,3,2) + ds_grid_get(player_1.equipment,3,3)    
            defense = player_2.res + ds_grid_get(player_2.equipment,5,0) + ds_grid_get(player_2.equipment,5,1) + ds_grid_get(player_2.equipment,5,2) + ds_grid_get(player_2.equipment,5,3)
        }
    
    
        if(offense <= defense){
            damage = 1;
        }
        else{
            damage = 1 + offense - defense;
        }
        
        //Check for crit to triple damage
        if(crit == true){
            if(damage == 1){damage = 5;}
            else{damage = damage * 3;}
        } 
        
        
        
        if(global.damage_display == 3 or global.damage_display == 2){
            instance_create(134,12,hp_bar);
            hp_bar.target = player_2;
        }
        
        
    }

    timer += 1;
    
    if(timer == 3){
        player_2.cur_x += 3;
        //Create damage particle
    if(global.damage_display == 3 or global.damage_display == 1){
        damage_effect = instance_create(130,30,damage_particle);
        damage_effect.value = damage;
    }
    }
    if(timer == 5){
        player_2.cur_x -= 3;
    }
    if(timer == 8){
        player_2.cur_x -= 3;
    }
    if(timer == 10){
        player_2.cur_x += 3;
    }
    
    
    if(timer > 10){
    player_1.image_index = 0;    
    
    
    
    
    //Send Message to Text Box
    Text_Box.new_text = "You Deal " + string(damage) + " Damage";
    
    //Increment Special Meter
    if(global.player_class != "Knight"){
        player_1.meter += 1;
        if(player_1.meter > player_1.meter_max){player_1.meter = player_1.meter_max;}
    }
    
    if(damage < 0){damage = 0;}
    player_2.HP -= damage;
    
    
    //Check to see if a shield is used up
    if(enemy_shield == true){
        if(player_2.HP <= 0){
            instance_create(108,20,shield);
            player_2.HP = 1;
            enemy_shield = false;
        }
    }
    
    
    //Prepare for next phase
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
    //If nobody is dead, let player 2 start his attack
    else{
        battle_phase = "goto 2";
        timer = 0;    
        player_2.image_index = player_2.previous_index;
    }
    }    
}

    
}
