{
if(ani_timer == 0){
    image_index = 0;
    tongue_time = irandom_range(20,60);
    ani_timer += 1;
    timer_2 = 0;
}

else{
    ani_timer += 1;
    if(ani_timer >= tongue_time){
        timer_2 += 1;
        if(timer_2 >= 2){
            timer_2 = 0;
            image_index += 1;
            if(image_index == 15){
                image_index = 0;
                ani_timer = 0;
            }
        }
    }
}

}
