{
///////////////////////////////////////////////////
//Special For the Knight Class, Fully Heals player
///////////////////////////////////////////////////


if(!part_system_exists(holy_blessing)){
    special_timer = 0;
    crown = instance_create(137,74,custom_particle);
    crown.type = "blessing";
    crown.sprite_index = holy_blessing_spr;
    crown.image_speed = 0;
    holy_blessing = part_system_create();
    hb_effect = part_type_create();
    part_type_sprite(hb_effect,blessing_spell_spr,false,false,true);
    part_type_scale(hb_effect,3,3);
    part_type_speed(hb_effect,2,2,-0.07,0);
    part_type_direction(hb_effect,235,305,0,0);
    part_type_life(hb_effect,40,50);
    part_type_gravity(hb_effect,0.05,270)
    Text_Box.new_text = "You use Holy Blessing!";
}
else{
    special_timer += 1;
    if(special_timer == 17){
        hb_emitter = part_emitter_create(holy_blessing);
        part_emitter_region(holy_blessing,hb_emitter,140,182,80,80,ps_shape_rectangle,ps_distr_gaussian);
        part_emitter_stream(holy_blessing,hb_emitter,hb_effect,3);
    }
    if(special_timer == 40){
        part_emitter_destroy_all(holy_blessing); 
    }
    if(special_timer > 40){
        crown.alpha -= 0.034;
    }
    if(special_timer > 90){
        part_type_destroy(hb_effect);
        with(custom_particle){
            if(id == Dungeon.crown){
                instance_destroy();
            }
        }
        part_system_destroy(holy_blessing);
        player_1.HP = player_1.MAX_HP;
        battle_phase = previous_phase;
        player_1.meter -= 1;
    }
}
}
