{
if(ani_timer == 0){
    blink_time = irandom_range(20,60);
    image_index = 0;
    timer_2 = 0;
    ani_timer += 1;
}
else if(ani_timer >= blink_time){
    timer_2 += 1;
    if(timer_2 == 3){image_index = 1;}
    else if(timer_2 == 6){image_index = 2;}
    else if(timer_2 == 9){image_index = 3;}
    else if(timer_2 == 12){image_index = 4;}
    else if(timer_2 == 15){image_index = 5;}
    else if(timer_2 == 16){
        ani_timer = -1;
    }
}
ani_timer += 1;

}
