{
    ani_timer += 1;
    if(ani_timer == 5){
        image_index = 1;
    }
    else if(ani_timer == 10){
        image_index = 2;
    }
    else if(ani_timer == 15){
        image_index = 3;
    }
    else if(ani_timer == 20){
        image_index = 0;
        ani_timer = 0;
    }
}
