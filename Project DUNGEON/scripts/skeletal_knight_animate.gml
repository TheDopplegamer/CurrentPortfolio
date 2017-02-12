{
    ani_timer += 1;
    if(ani_timer == 30){
        image_index = 1;
    }
    else if(ani_timer == 40){
        image_index = 0;
        ani_timer = 0;
    }
}
