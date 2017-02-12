{
if(ani_timer == 0){
    index_timer = 0;
    ani_timer += 1;
    time_limit = irandom_range(30,50);
    limit_2 = irandom_range(2,4);
    pos_timer = 0;
    timer_index = 0;
    timer_timer = irandom_range(6,9);
}
else if(ani_timer < time_limit){
    ani_timer += 1;        
}
else if(ani_timer == time_limit){
    index_timer += 1;
    if(index_timer == limit_2){
        index_timer = 0;
        timer_index += 1;
        image_index += 1;
        if(timer_index == timer_timer){
            var ec = irandom_range(1,3);
            if(ec <= 2){image_index = irandom_range(0,2);}
            else{image_index = 6;}
            ani_timer = 0;
            index_timer = 0;
        }
    }   
}





}
