{
if(ani_timer == 0){
    ani_timer = 1;
    image_index = 0;
    glass_timer = irandom_range(40,80);
    timer_2 = 0;
}

else{
    ani_timer += 1;
    if(ani_timer >= glass_timer){
        timer_2 += 1;
        if(timer_2 == 4){
            timer_2 = 0;
            image_index += 1;
            if(image_index == 8){
                image_index = 0;
                ani_timer = 0;
            }
        }
    }
}

}
