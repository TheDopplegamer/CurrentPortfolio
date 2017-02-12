{
if(ani_timer == 0){
    turn_time = irandom_range(20,60);
    ani_timer = 1;
    timer_2 = 0;
    face = image_index;
}
else{
    ani_timer += 1;
    if(ani_timer >= turn_time){
        timer_2 += 1;
        if(timer_2 == 2){
            image_index += 1;
        }       
        else if(timer_2 == 7){
            if(face == 0){
                image_index = 2;
            }
            else{
                image_index = 0;
            }   
            ani_timer = 0;
        } 
    }
}
}
