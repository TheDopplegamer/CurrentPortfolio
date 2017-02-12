{
    ani_timer += 1;
    if(ani_timer == 60){
        image_index = 1;
    }
    else if(ani_timer == 90){
        image_index = 0;
        ani_timer = 0;
    }
}
