{
if(ani_timer == 0){
    ani_timer = 1;
    pole_time = irandom_range(40,60);
    timer_2 = 0;
}
else{
    ani_timer += 1;
    if(ani_timer >= pole_time){
        timer_2 += 1;
        if(timer_2 == 1){
            image_index = 1;
        }
        else if(timer_2 == 5){
            image_index = 2;
        }
        else if(timer_2 == 7){
            image_index = 3;
        }
        else if(timer_2== 8){
            image_index = 4;
        }
        else if(timer_2 == 9){
            image_index = 0;
            ani_timer = 0;
        }
    }
}
}
