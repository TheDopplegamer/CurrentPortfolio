{
if(ani_timer == 0){
    ani_timer = 1;
    ani_timer_2 = 0;
    image_index = 0;
}
else if(ani_timer == 1){
    ani_timer_2 += 1;
    if(ani_timer_2 == 10){
        image_index = 1;
    }
    else if(ani_timer_2 == 12){
        image_index = 2;
    }
    else if(ani_timer_2 == 14){
        image_index = 3;
    }
    else if(ani_timer_2 == 16){
        image_index = 4;
    }
    else if(ani_timer_2 == 18){
        image_index = 5;
    }
    else if(ani_timer_2 == 20){
        image_index = 6;
    }
    else if(ani_timer_2 == 22){
        image_index = 7;
    }
    else if(ani_timer_2 == 24){
        image_index = 8;
    }
    else if(ani_timer_2 == 26){
        image_index = 9;
    }
    else if(ani_timer_2 == 28){
        image_index = 10;
    }
    else if(ani_timer_2 == 30){
        image_index = 11;
    }
    else if(ani_timer_2 == 60){
        ani_timer = 0;
    }
    
}



}
