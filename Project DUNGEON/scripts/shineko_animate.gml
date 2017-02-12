{
if(ani_timer == 0){
    ani_timer = 1;
    blink_time = irandom_range(60,90);
    timer_2 = 0;
    image_index = 0;
}
else{
    ani_timer += 1;
    if(ani_timer >= blink_time){
        timer_2 += 1;
        if(timer_2 == 5){
            timer_2 = 0;
            image_index += 1;
            if(image_index == 4){
                image_index = 0;
                ani_timer = 0;
            }
        }
    }   
}
}
