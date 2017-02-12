{
if(ani_timer == 0){
    dir_y = irandom_range(-2,2);
    dir_x = irandom_range(-2,2);
    og_x = cur_x;
    og_y = cur_y;   
    ani_timer += 1;
}
else if(ani_timer == 3){
    ani_timer += 1;
    if(ani_timer > 7){
    ani_timer = 1;
        dir_y = irandom_range(0,2);
        dir_x = irandom_range(0,2);
    }
    else{
        if(dir_y < 0 and cur_y > og_y-10){
            cur_y += dir_y;
        }
        else if(dir_y > 0 and cur_y < og_y+10){
            cur_y += dir_y;
        }
        if(dir_x < 0 and cur_x > og_x-10){
            cur_x += dir_x;
        }
        else if(dir_x > 0 and cur_x < og_x+10){
            cur_x += dir_x;
        }
    }
}
}
