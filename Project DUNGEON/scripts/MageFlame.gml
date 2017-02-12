{
////////////////////////////////////////////////////////////
//Mage special move, deals a high amount of damage to enemy
////////////////////////////////////////////////////////////

if(!instance_exists(custom_particle)){
    new_particle = instance_create(128,10,custom_particle);
    new_particle.sprite_index = wizard_spell_spr;
    new_particle.end_image = 20;
    Text_Box.new_text = "You use MageFlame!";
    player_2.image_index = player_2.hurt_index;
    //Create damage particle
    damage = 7;
    if(global.damage_display == 3 or global.damage_display == 1){
        damage_effect = instance_create(130,30,damage_particle);
        damage_effect.value = damage;
    }
    if(global.damage_display == 3 or global.damage_display == 2){
            instance_create(134,12,hp_bar);
            hp_bar.target = player_2;
    }
    special_timer = 0;
}

else{
    special_timer += 1;
    if(special_timer == 3){
        player_2.cur_x += 3;
    }
    if(special_timer == 5){
        player_2.cur_x -= 3;
    }
    if(special_timer == 8){
        player_2.cur_x -= 3;
    }
    if(special_timer == 10){
        player_2.cur_x += 3;
    }
    spec_damage = 7;
    if(special_timer >= 19){
        player_2.HP -= spec_damage;
        Text_Box.new_text = "You Deal " + string(spec_damage) + " Damage";
        player_1.meter = 0;
        //Prepare for next phase
        //Check to see if someone is dead
        if(player_1.HP <= 0){
            player_1.HP = 0;
            battle_phase = "results";
            win = false;
            special_timer = 0;
            timer = 0;
        }
        else if(player_2.HP <= 0){
            player_2.HP = 0;
            battle_phase = "results";
            win = true;
            special_timer = 0;
            timer = 0;
        }
        else{
            battle_phase = previous_phase;
        }
        
    }
}

}
