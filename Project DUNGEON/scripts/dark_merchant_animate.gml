{
if(ani_timer < 30){
    ani_timer += 1;
    if(ani_timer == 30){
        image_index = 2;
        ani_timer_2 = 0;
    }
}
else if(ani_timer == 30){
    ani_timer_2 += 1;
    if(ani_timer_2 == 2){
        ani_timer_2 = 0;
        image_index += 1;
        if(image_index == 9){
            ani_timer = 31;
            ani_timer_2 = 0;            
        }
    }

}
else if(ani_timer > 30){
    ani_timer += 1;
    if(ani_timer > 60){
        ani_timer_2 += 1;
        if(ani_timer_2 == 2){
            image_index += 1;
            ani_timer_2 = 0;
            if(image_index == 18){
                image_index = 0;
                ani_timer = 0;
                ani_timer_2 = 0;
            }
        }
    }
}
}
