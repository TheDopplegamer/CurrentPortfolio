{
    ani_timer += 1;
    if(ani_timer == 60){
        image_index = 1;
    }
    else if(ani_timer == 62){
        image_index = 2;
    }
    else if(ani_timer == 64){
        image_index = 3;
    }
    else if(ani_timer == 94){
        image_index = 2;
    }
    else if(ani_timer == 96){
        image_index = 1;
    }
    else if(ani_timer == 98){
        image_index = 0;
        ani_timer = 0;
    }
}
