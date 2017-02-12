{
    if(ani_timer == 0){
        dir_timer = 0;
        dir = 0;
        ani_timer = 1;
        dir_start_timer = irandom_range(10,30);
        dir_go = false;
        z_timer = 0;
        s_timer = 0;
    }
    else{
        ani_timer += 1;
        if(ani_timer == 4){
            image_index += 1;
            if(image_index == hurt_index){
                image_index = 0;
            }
            ani_timer = 1;
        }
    }
    
    
}
